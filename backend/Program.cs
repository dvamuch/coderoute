using CodeRoute.Auth;
using CodeRoute.DAL;
using CodeRoute.DAL.Repositories;
using CodeRoute.ExceptionWare;
using CodeRoute.Logs;
using CodeRoute.Services;
using CodeRoute.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Prometheus;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: ApiController]
namespace CodeRoute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddLogging(builder);

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "API V1", Version = "V1.0" });
                options.SwaggerDoc("v2", new OpenApiInfo() { Title = "API V1", Version = "V2.0" });
            });

            AddContext(builder);

            AddServices(builder);
            AddJWT(builder);

            var app = builder.Build();

            ConfigureContext(app);

            app.UseMiddleware<ExceptionMiddleware>();

            AddMetrics(app);
            AddSwagger(app);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            
            

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.Run();
        }

        private static void AddLogging(WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddFile(Path.Combine(Environment.CurrentDirectory, "logs.txt"));
            //builder.Logging.AddConsole();
        }

        private static void AddContext(WebApplicationBuilder builder)
        {
            //������� ������ ����������� �� ������������
            var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("ConnectionStrings: " + connectionStrings);
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseNpgsql(connectionStrings);
            }, ServiceLifetime.Singleton);

            //�������� �����������
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionStrings);
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Success open postgreSQL connection.");
                else
                    Console.WriteLine("Failed open postgreSQL connection.");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<RouteService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<VertexService>();

            builder.Services.AddScoped<RouteRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<VertexRepository>();

            builder.Services.AddScoped<Logger<RouteRepository>>();
            builder.Services.AddScoped<Logger<UserRepository>>();

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        private static void AddJWT(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // ���������, ����� �� �������������� �������� ��� ��������� ������
                        ValidateIssuer = true,
                        // ����� �� �������������� ����������� ������
                        ValidateAudience = true,
                        // ����� �� �������������� ����� �������������
                        ValidateLifetime = true,
                        // ��������� ����� ������������
                        ValidateIssuerSigningKey = true,


                        // ������, �������������� ��������
                        ValidIssuer = AuthOptions.ISSUER,
                        // ��������� ����������� ������
                        ValidAudience = AuthOptions.AUDIENCE,
                        // ��������� ����� ������������
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    };
                });
        }

        private static void ConfigureContext(WebApplication app)
        {
            //Need to create context and using migration before starting the server
            //var context = app.Services.GetRequiredService<Context>();

            using var scope = app.Services.CreateScope();
            var uRep = scope.ServiceProvider.GetRequiredService<UserRepository>();

            //Create special user for anonim visiting routes
            //uRep.AddUser(new Models.User { UserName = "", Email = "", Password = "", IsAdmin = true });


            //Create special vertex for begin of graph
            var vRep = scope.ServiceProvider.GetRequiredService<VertexRepository>();
            //vRep.AddVertex(new Models.Vertex() { Name = "", MarkdownPage = "" });
        }

        //������� ����������
        private static void AddMetrics(WebApplication app)
        {
            app.UseMetricServer();
            app.UseHttpMetrics();
            app.MapMetrics();
        }

        //�������� ��������
        private static void AddSwagger(WebApplication app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/v1/swagger.json", "v1");
                options.SwaggerEndpoint("/v2/swagger.json", "v2");
            });
        }
    }
}
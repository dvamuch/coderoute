using CodeRoute.Auth;
using CodeRoute.DAL;
using CodeRoute.DAL.Repositories;
using CodeRoute.ExceptionWare;
using CodeRoute.Logs;
using CodeRoute.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Prometheus;

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
            builder.Services.AddSwaggerGen();

            AddContext(builder);
            //AddTestContext(builder);


            AddServices(builder);
            AddJWT(builder);

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                Console.WriteLine("Development");
            }
            else
            {
                Console.WriteLine("not a Development");
            }

            app.UseMiddleware<ExceptionMiddleware>();

            AddMetrics(app);
            AddSwagger(app);

            //�������������� HTTP �� HTTPS
            app.UseHttpsRedirection();
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
            });

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

        private static void AddTestContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TestContext>(options =>
            {
                options.UseInMemoryDatabase("code_route");
            });
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<RouteService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<RouteRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<VertexRepository>();

            builder.Services.AddScoped<Logger<RouteRepository>>();
            builder.Services.AddScoped<Logger<UserRepository>>();
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
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/v1/swagger.json", "v1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
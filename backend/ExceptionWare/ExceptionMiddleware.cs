using System.Diagnostics;

namespace CodeRoute.ExceptionWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var path = context.Request.Path;

                WriteError(path, ex.Message, ex.StackTrace);

                context.Response.StatusCode = 500;

                await Results.Problem(
                    title: "я где-то проебался, сорри",
                    statusCode: StatusCodes.Status500InternalServerError,
                    extensions: new Dictionary<string, object>
                    {
                        { "error", ex.Message },
                        { "traceId", Activity.Current?.Id },
                    }).ExecuteAsync(context);
            }
        }

        private async void WriteError(string path, string exceptionMessage, string stackTrace = "")
        {
            await Console.Out.WriteLineAsync("Пиздец. Я обосрался!");
            await Console.Out.WriteAsync(DateTime.Now.ToString() + "  |  ");
            await Console.Out.WriteLineAsync("Произошла ошибка по пути: " + path);
            await Console.Out.WriteLineAsync(exceptionMessage);
            await Console.Out.WriteLineAsync(stackTrace);
        }
    }
}

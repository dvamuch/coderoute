namespace CodeRoute.Logs
{
    public class FileLogger : ILogger, IDisposable
    {
        string filePath;
        static object _lock = new object();

        public FileLogger(string path)
        {
            filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel, EventId eventId,
            TState state, Exception? exception, 
            Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                string log = DateTime.Now + " :: ";

                Console.Write(log);
                switch (logLevel)
                {
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case LogLevel.Error:
                    case LogLevel.Critical:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;

                    case LogLevel.Information:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case LogLevel.Trace:
                    case LogLevel.Debug:
                    case LogLevel.None:
                    default:
                        break;
                }

                log += logLevel.ToString();
                Console.Write(logLevel.ToString());
                Console.ForegroundColor = ConsoleColor.White;

                log += ": " + state + Environment.NewLine;
                Console.Write(": " + state + Environment.NewLine);
                if (exception != null)
                {
                    log += exception.Message + exception.Message;
                    Console.Write(exception.Message + exception.StackTrace);

                    Console.Write(Environment.NewLine + "Exception data: " + Environment.NewLine);
                    foreach (var item in exception.Data)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                Console.WriteLine();
                File.AppendAllText(filePath, log);
            }
        }
    }
}

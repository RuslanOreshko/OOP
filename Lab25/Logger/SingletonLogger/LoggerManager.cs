using System.Net;

public sealed class LoggerMenager
{
    private static readonly object _lock = new object();
    private static LoggerMenager? _instance;

    private ILogger _logger;

    private LoggerMenager(ILogger logger)
    {
        _logger = logger;
    }

    public static void Initialize(LoggerFactory factory)
    {
        lock (_lock)
        {
            if(_instance == null)
            {
                _instance = new LoggerMenager(factory.CreateLogger());
            }
            else
            {
                _instance._logger = factory.CreateLogger();
            }
        }
    }

    public static LoggerMenager Instance
    {
        get
        {
            if(_instance == null)
            {
                throw new InvalidOperationException("Логер менеджер не інізіалізований");
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        _logger.Log(message);
    }
}
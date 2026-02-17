public class FileLogger : ILogger
{
    // Просто імітація логування у файл
    public void Log(string message) => Console.WriteLine($"[FILE] {message}");
}
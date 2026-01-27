using Models;

public class ConsoleLogger : ITransactionLogger
{
    public void Log(Payment payment, string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
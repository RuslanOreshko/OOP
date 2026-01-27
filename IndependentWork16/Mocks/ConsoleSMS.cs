using Models;

public class ConsoleSMS : ISmsService
{
    public void SendMessage(Payment payment, string message)
    {
        Console.WriteLine($"[SMS to {payment.PhoneNumber}]: {message}");
    }
}
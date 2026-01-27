using Models;

public interface ISmsService
{
    void SendMessage(Payment payment, string message);
}
using Models;

public interface ITransactionLogger
{
    void Log(Payment payment, string message);
}
using Models;

public interface IPaymentValidator
{
    bool IsValid(Payment payment);
}
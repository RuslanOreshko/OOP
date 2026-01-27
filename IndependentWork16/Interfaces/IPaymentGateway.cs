using Models;

public interface IPaymentGateway
{
    decimal Charge(Payment payment);
}
using Models;

public class Geteway : IPaymentGateway
{
    public decimal Charge(Payment payment)
    {
        return payment.Amount;
    }
}
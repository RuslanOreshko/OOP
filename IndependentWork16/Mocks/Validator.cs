using Models;

public class Validator : IPaymentValidator
{
    public bool IsValid(Payment payment)
    {
        if(payment.Amount <= 0)
        {
            throw new Exception("Invalid payment amount!");
        }

        if (string.IsNullOrWhiteSpace(payment.CardNumber))
        {
            throw new Exception("Invalid card number");
        }

        if(string.IsNullOrWhiteSpace(payment.PhoneNumber))
        {
            throw new Exception("Invalid phone number");
        }

        return true;
    }
}
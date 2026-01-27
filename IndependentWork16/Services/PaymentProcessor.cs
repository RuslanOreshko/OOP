using Models;

public class PaymentProcessor // Приклад порушення SPR.
{
    public void ProcessorPayment(Payment payment)
    {
        // Валідація
        if(payment.Amount <= 0)
            throw new Exception("Invalid payment amount!");

        if(string.IsNullOrWhiteSpace(payment.CardNumber))
            throw new Exception("Invalid card number");

        // Списання коштів
        Console.WriteLine($"Charging {payment.Amount} UAH from card {payment.CardNumber}");

        // Логування
        Console.WriteLine($"[LOG] Payment of {payment.Amount} UAH was successful at {DateTime.Now}");

        // Відправлення SMS
        Console.WriteLine($"Sending SMS to {payment.PhoneNumber}: Payment successful");
    }
}
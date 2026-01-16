public class ConsoleEmailService : IEmailService
{
    public void SendOrderConfirmation(Order order)
    {
        Console.WriteLine($"[Email] Лист відправлено, ваше замовлення: {order.Id}, сума до сплати {order.TotalAmount} грн.");
    }
}
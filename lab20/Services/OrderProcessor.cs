public class OrderProcessor // Не відповідає патерну
{
    public void ProcessorOrder(Order order)
    {
        if(order.TotalAmount > 0)
        {
            Console.WriteLine("Замовлення прийнято!\n");

            Console.WriteLine("[DataBase] - Замовлення збережено!\n");

            Console.WriteLine("[Email] - Важе замовлення успішно оформленно\n");

            order.Status = OrderStatus.PendingValidation;
            Console.WriteLine($"Статус замовлення {order.Status}");
        }
    }
}
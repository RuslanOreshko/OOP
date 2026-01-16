public class Validator : IOrderValidator
{
    public bool IsValid(Order order)
    {
        if (order.TotalAmount <= 0)
        {
            Console.WriteLine("[Validator] Помилка - Сума замовлення меньша за 0!");
            return false;
        }

        return true;
    }
}
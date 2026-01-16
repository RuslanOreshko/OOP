public class InMemoryRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();


    public void Save(Order order)
    {
        _orders.Add(order);

        Console.WriteLine("[Repository] Замовлення успішно збережено в БД!");
    }

    public Order GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);

        if(order == null)
        {
            Console.WriteLine("[Repository] Помилка - продукту із таким Id немає!\n");
            return null!;
        }

        Console.WriteLine($"[Repository] Ваше замовлення: {order.CustomerName}");

        return order;
    }
}
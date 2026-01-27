public class OrderService // Збірка програми, яка відповідає SRP.
{
    private readonly IOrderValidator _orderValidator;
    private readonly IEmailService _emailService;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        IOrderValidator orderValidator,
        IEmailService emailService,
        IOrderRepository orderRepository
    )
    {
        _orderValidator = orderValidator;
        _emailService = emailService;
        _orderRepository = orderRepository;
    }

    public void ProccesorOrder(Order order)
    {
        if (!_orderValidator.IsValid(order))
        {
            Console.WriteLine("[Service] Помилка валідації, обробку завершено");
            return; // Якщо IsValid повертає false, тоді програма зупиняється
        }

        _orderRepository.Save(order); 
        var saveOrder = _orderRepository.GetById(order.Id); 

        if(saveOrder != null)
        {
            _emailService.SendOrderConfirmation(order);
            Console.WriteLine("[Service] Обробка успішно завершена!\n");
        }
    }
}



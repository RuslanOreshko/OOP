using Microsoft.Extensions.DependencyInjection;


IServiceCollection services = new ServiceCollection(); // Контейнер 

// Реєстрація життєвого циклу
services.AddSingleton<IOrderRepository, InMemoryRepository>(); // Singleton тому що InMemoryRepository має зберігати в собі колекцію із об'ктами Order.
services.AddTransient<IEmailService, ConsoleEmailService>();
services.AddTransient<IOrderValidator, Validator>();
services.AddScoped<OrderService>();

var serviceProvaider = services.BuildServiceProvider();

var myOrder1 = new Order(id: 1, totalAmount: 200, customerName: "RTX 5090");
var myOrder2 = new Order(id: 2, totalAmount: 150, customerName: "Ryzen 5 7500f");
var myOrder3 = new Order(id: 3, totalAmount: 0, customerName: "64gb ddr5"); // навмисно не правильна ціна для перевірки валідації


var orderServiceProvider = serviceProvaider.GetRequiredService<OrderService>();
orderServiceProvider.ProccesorOrder(myOrder1);
orderServiceProvider.ProccesorOrder(myOrder2);
orderServiceProvider.ProccesorOrder(myOrder3); // Не валідне замовлення




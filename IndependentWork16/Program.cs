using Models;
using Microsoft.Extensions.DependencyInjection;


// Збірка через DI

IServiceCollection services = new ServiceCollection(); // контейнер

services.AddScoped<PaymentService>();

services.AddScoped<IPaymentGateway, Geteway>();
services.AddScoped<IPaymentValidator, Validator>();

services.AddTransient<ISmsService, ConsoleSMS>();
services.AddSingleton<ITransactionLogger, ConsoleLogger>();

var serviceProvider = services.BuildServiceProvider(); // сервіс провайдер

// Прау об'єктів для тестів
var payment_1 = new Payment(id: 1, amount: 100, cardNumber: "0123456789", phoneNumber: "0987654321");
var payment_2 = new Payment(id: 2, amount: 0, cardNumber: "645647578", phoneNumber: "668567548");
var payment_3 = new Payment(id: 3, amount: 299, cardNumber: "", phoneNumber: "0987654321");


var paymentServiceProvider = serviceProvider.GetRequiredService<PaymentService>();

paymentServiceProvider.ProccesorPayment(payment_1);
Console.WriteLine();
paymentServiceProvider.ProccesorPayment(payment_2);
Console.WriteLine();
paymentServiceProvider.ProccesorPayment(payment_3);




















// class Program
// {
//     static void Main()
//     {
//         Payment payment = new(id: 1, amount: 99, cardNumber: "1111444488888888", phoneNumber: "9842379374");

//         PaymentProcessor paymentProcessor = new();
//         paymentProcessor.ProcessorPayment(payment);


//     }
// }
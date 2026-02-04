using Interface;
using Mock;
using Services;

using Microsoft.Extensions.DependencyInjection;

// За допомгою бібліотки DI можна контейнеризувати DI

IServiceCollection services = new ServiceCollection(); // Контейнер DI

// Житєвий цикл програми
services.AddSingleton<IDataBaseConnections, DbConnections>(); // Якщо просять IDataBaseConnections то використовуємо DbConnections
services.AddSingleton<ISmsGateway, SmsSend>();
services.AddSingleton<ISmtpClient, EmailSendSms>();

services.AddTransient<UserAccountMenager>();

var serviceProvider = services.BuildServiceProvider();

var userMenager = serviceProvider.GetRequiredService<UserAccountMenager>();

userMenager.RegisterUser("test@test.com", "123456", "+380123456789");
userMenager.SendEmailNotification("test@test.com", "Ви підписалися", "Дякуємо за підписку на нашому сервісі");
userMenager.SendSmsNotification("+380123456789", "Дякуємо за те що підписались");

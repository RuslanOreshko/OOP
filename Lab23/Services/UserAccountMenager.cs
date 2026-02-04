using Interface;

namespace Services;

public class UserAccountMenager
{
    // Поля
    private readonly IDataBaseConnections _dbConnect;
    private readonly ISmsGateway _sms;
    private readonly ISmtpClient _smtp;

    // Впровадження ін'єкцій через конструктор
    public UserAccountMenager(
        IDataBaseConnections dbConnect,
        ISmsGateway sms,
        ISmtpClient smtp
    )
    {
        _dbConnect = dbConnect;
        _sms = sms;
        _smtp = smtp;
    }

    // Викликання методів
    public void RegisterUser(string email, string password, string number)
    {
        _dbConnect.Register(email, password);
        _sms.SendSms(number, "Дякуємо за реєстрацію");
        _smtp.SendEmail(email, "Дякуємо", "Дякуюмо за успішну реєстрацію");
    }

    public void SendEmailNotification(string email, string subject, string body)
    {
        _smtp.SendEmail(email, subject, body);
    }

    public void SendSmsNotification(string number, string message)
    {
        _sms.SendSms(number, message);
    }
}
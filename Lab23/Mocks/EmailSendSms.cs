using Interface;

namespace Mock;

public class EmailSendSms : ISmtpClient
{
    public void SendEmail(string email, string subject, string body)
    {
        Console.WriteLine($"{email} Заголовок: {subject}\nПовідомлення: {body}");
    }
}


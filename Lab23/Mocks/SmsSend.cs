using Interface;

namespace Mock;

public class SmsSend : ISmsGateway
{
    public void SendSms(string number, string message)
    {
        Console.WriteLine($"на номер {number} відправлено повідомлення: {message}");
    }
}
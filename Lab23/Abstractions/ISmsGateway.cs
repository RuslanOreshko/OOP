namespace Interface;

public interface ISmsGateway
{
    void SendSms(string number, string message);
}
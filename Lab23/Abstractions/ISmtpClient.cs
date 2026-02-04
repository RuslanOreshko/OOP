namespace Interface;

public interface ISmtpClient
{
    void SendEmail(string email, string subject, string body);
}
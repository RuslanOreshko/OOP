// var menager = new UserAccountMenager();

// menager.Register("Ruslan@1488", "12345678");

// // // Поганий варіант використання SIP та DIP

// public interface IUserAccountMenager
// {
//    void Register(string email, string password);
//    void SendEmail(string email, string subject, string body);
//    void SendSms(string number, string message);
// }

// public class UserAccountMenager : IUserAccountMenager
// {
//     private DataBaseConnections _db = new DataBaseConnections();
//     private SmtpClient  _smpt = new SmtpClient();
//     private SmsGateway _sms = new SmsGateway();

//     public void Register(string email, string password)
//     {
//         _db.SaveUser(email, password);
//         _smpt.SendEmail(email, "Дякуємо за реєстрацію", "Дуже дякуємо за реєстрацію на нашому сервісі");
//     }

//     public void SendEmail(string email, string subject, string body)
//     {
//         _smpt.SendEmail(email, subject, body);
//     }

//     public void SendSms(string number, string message)
//     {
//         _sms.SendSms(number, message);
//     }
// }

// public class DataBaseConnections
// {
//     public void SaveUser(string email, string password)
//     {
//         Console.WriteLine($"Email: {email}, Password: {password}. Збережено в БД");
//     }
// }

// public class SmsGateway
// {
//     public void SendSms(string number, string message)
//     {
//         Console.WriteLine($"на номер {number} відправлено повідомлення: {message}");
//     }
// }

// public class SmtpClient
// {
//     public void SendEmail(string email, string subject, string body)
//     {
//         Console.WriteLine($"На Email {email} відправлено повідомлення.\nЗаголовок: {subject}, повідомлення: {body}");
//     }
// }
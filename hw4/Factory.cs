namespace PracticFacroty;

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Вам прийшло повідомлення на Email: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"На ваш номер прийшло повідомлення: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Повідомлення: {message}");
}

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();
}

public class EmailNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SmsNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

public class PushNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}

// class Program
// {
//     static void Main()
//     {
//         NotificationFactory emailNotification = new EmailNotificationFactory();
//         var notification = emailNotification.CreateNotification();
//         notification.Send("Дякуємо за підписку");

//         // NotificationFactory pushNotification = new PushNotificationFactory();
//         // pushNotification.SendNotification("Дякуємо...");
//     }
// }

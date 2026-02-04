using Interface;

namespace Mock;

// Проста імітація збереження в бд
public class DbConnections : IDataBaseConnections
{
    public void Register(string email, string password)
    {
        Console.WriteLine($"Email: {email}, Password: {password}. Збережено в БД");
    }
}
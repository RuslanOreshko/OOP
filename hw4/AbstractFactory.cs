
namespace AbstractFactoryPratic;

public interface ILogger
{
    void Log(string message);
}

public interface IDatabase
{
    void SaveDb(string value);
}

public interface IAppFactory
{
    ILogger CreateLogger();
    IDatabase CreateDatabase();
}


// Development реалізації
public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}

public class InMemoryDatabase : IDatabase
{
    public void SaveDb(string value) => Console.WriteLine($"Дані {value} збережено в памяті*");
}

public class DevFactory : IAppFactory
{
    private ILogger? logger;
    private IDatabase? database;

    public ILogger CreateLogger()
    {
        if(logger == null)
        {
            logger = new ConsoleLogger();
        }
        return logger;
    }

    public IDatabase CreateDatabase()
    {
        if(database == null)
        {
            database = new InMemoryDatabase();
        }
        return database;
    }
}

// Production Реалізації 
public class FileLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[FILE LOG] {message}");
}

public class SqlDatabase : IDatabase
{
    public void SaveDb(string value) => Console.WriteLine($"Дані {value} збережено в базі даних*");
}

public class ProdFactory : IAppFactory
{
    private ILogger? logger;
    private IDatabase? database;

    public ILogger CreateLogger()
    {
        if(logger == null)
        {
            logger = new FileLogger();
        }
        return logger;
    }

    public IDatabase CreateDatabase()
    {
        if(database == null)
        {
            database = new SqlDatabase();
        }
        return database;
    }

}

public class App
{
    private readonly ILogger _logger;
    private readonly IDatabase _database;

    public App(IAppFactory factory)
    {
        _logger = factory.CreateLogger();
        _database = factory.CreateDatabase();
    }

    public void Run()
    {
        _logger.Log("Ready");
        _database.SaveDb("Name: Ruslan");
    }
}

class Program
{
    static void Main()
    {
        IAppFactory factory = new DevFactory();
        var app = new App(factory);
        app.Run();
    }
}
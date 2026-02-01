// Приклад поганого ISP
interface IWorked
{
    void Work();
    void Eat();
    void Sleep();
}

// Рефакторинг
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}


// Реалізація IWorkable
public class HumanWorker : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Людина працює");
    }
}

public class RobotWorker : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Робот працює");
    }
}

// Сервіс для Work
public class WorkService
{
    private readonly IWorkable _worker;

    public WorkService(IWorkable worker)
    {
        _worker = worker;
    }

    public void Menager()
    {
        _worker.Work();
    }
}





class Program
{
    static void Main()
    {
        // Ініціалізація LoggerMenager
        LoggerMenager.Initialize(new ConsoleLoggerFactory());
        LoggerMenager.Instance.Log("Система стартує!");


        var publisher = new DataPublisher();

        var dataContext = new DataContext(new EncryptDataStrategy(), publisher);


        var loggerObserver = new ProcessingLoggerObserver();

        // Підписуємо його на івент
        loggerObserver.Subscribe(publisher);


        // Визаваємо метод який передає параметер конкретному творцю, який у свою чергу створює EncryptDataStrategy()
        dataContext.Process("Тест");
        

        // Динамічна зміна фабрики
        LoggerMenager.Initialize(new FileLoggerFactory());

        // Динамічна зміна стратегії
        dataContext.SetStrategy(new CompressDataStrategy());

        dataContext.Process("Тест 1");
    }
}
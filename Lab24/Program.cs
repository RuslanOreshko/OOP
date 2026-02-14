class Program
{
    static void Main()
    {
        var publisher = new ResultPublisher();

        // Спостерігачі
        var ConsoleLogger = new ConsoleLoggerObserver();
        var historyLogger = new HistoryLoggerObserver();
        var thresgoldNotifier = new ThresholdNotifierObserver(threshold: 50);

        // Підписка 
        ConsoleLogger.Subscribe(publisher);
        historyLogger.Subscribe(publisher);
        thresgoldNotifier.Subscribe(publisher);

        // Процесор із патерну Strategy
        var processor = new NumericProcessor(new SquareOperationStrategy(), publisher);

        // При визові Process будуть використані спостерігачі які підписані на івенти
        processor.Process(5);
        // Можна використати SetStrategy для зміни стратегії
        processor.SetStrategy(new CubeOperationStrategy());
        processor.Process(5); 
        processor.SetStrategy(new SquareRootOperationStrategy());
        processor.Process(25);

        // Перегляд історії логування
        foreach(var item in historyLogger.History)
        {
            Console.WriteLine(item);
        }
    }
}
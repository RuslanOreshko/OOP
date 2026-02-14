public sealed class ConsoleLoggerObserver
{
    public void Subscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated += OnResultCalculated;

    public void Unuscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated -= OnResultCalculated;

    private void OnResultCalculated(double result, string operationName)
    {
        Console.WriteLine($"[ConsoleLogger] {operationName} - {result}");
    }
}
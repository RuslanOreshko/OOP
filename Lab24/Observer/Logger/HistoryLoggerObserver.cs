public sealed class HistoryLoggerObserver
{
    // Тут сберігаються логи
    private readonly List<string> _history = new();

    public IReadOnlyList<string> History => _history;

    public void Subscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated += OnResultCalculated;

    public void Unuscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated -= OnResultCalculated;

    private void OnResultCalculated(double result, string operationName)
    {
        _history.Add($"{DateTime.Now:HH.mm.ss} | {operationName} - {result}");
    }
}
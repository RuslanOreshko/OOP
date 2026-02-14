public sealed class ThresholdNotifierObserver
{
    private readonly double _threshold;

    public ThresholdNotifierObserver(double threshold)
    {
        _threshold = threshold;
    }

    public void Subscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated += OnResultCalculated;

    public void Unuscribe(ResultPublisher publisher) 
        => publisher.ResultCalculated -= OnResultCalculated;

    private void OnResultCalculated(double result, string operationName)
    {
        if (result > _threshold)
        {
            Console.WriteLine($"[ThresholdNotifier]  Попередження {operationName} result {result} більший за поріг: {_threshold}");
        }
    }
}
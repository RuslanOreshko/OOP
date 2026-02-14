public sealed class ResultPublisher
{
    // Івент на який можуть підписатись
    public event Action<double, string>? ResultCalculated; 

    public void PublishResult(double result, string operationName)
    {
        ResultCalculated?.Invoke(result, operationName);
    }
}
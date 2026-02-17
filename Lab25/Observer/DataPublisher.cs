public sealed class DataPublisher
{
    public event Action<string>? DataProcessed;

    public void Publish(string processedData)
    {
        DataProcessed?.Invoke(processedData);
    }
}


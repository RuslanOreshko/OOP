public sealed class DataContext
{
    private IDataProcessorStrategy _strategy;
    private readonly DataPublisher _publisher;

    public DataContext(
        IDataProcessorStrategy strategy,
        DataPublisher publisher
        )
    {
        _strategy = strategy;
        _publisher = publisher;
    }

    public void SetStrategy(IDataProcessorStrategy strategy)
    {
        _strategy = strategy;
    }

    public string Process(string input)
    {
        var result =  _strategy.Process(input);

        _publisher.Publish(result); // тут викликаються класи які підписанні на івент
        return result;
    }
}
// Об'єднання Strategy та Observer
using System.Security.Cryptography.X509Certificates;

public sealed class NumericProcessor
{
    private INumericOperationStrategy _strategy;
    private readonly ResultPublisher _publisher;

    public NumericProcessor(
        INumericOperationStrategy strategy,
        ResultPublisher publisher
    )
    {
        _strategy = strategy;
        _publisher = publisher;
    }

    public void SetStrategy(INumericOperationStrategy strategy) // Завдяки цьому можна міняти стратегії 
    {
        _strategy = strategy;
    }

    public double Process(double input)
    {
        double result = _strategy.Execute(input);

        _publisher.PublishResult(result, _strategy.Name);

        return result;
    }
}
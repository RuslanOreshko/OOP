public class SquareRootOperationStrategy : INumericOperationStrategy
{
    public string Name => "SquareRoot";
    public double Execute(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Для вирахування кореню число не можу бути від'ємним.");

        return Math.Sqrt(value);
    }
}
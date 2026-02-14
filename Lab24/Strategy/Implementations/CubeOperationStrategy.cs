public class CubeOperationStrategy : INumericOperationStrategy
{
    public string Name => "Cube";
    public double Execute(double value) => value * value * value;
}
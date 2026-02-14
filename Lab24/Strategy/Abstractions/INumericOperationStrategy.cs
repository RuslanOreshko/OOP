public interface INumericOperationStrategy
{
    // Добавлено поле Name для виводу назви операції в патерні Observer
    string Name { get; }
    double Execute(double value);
}
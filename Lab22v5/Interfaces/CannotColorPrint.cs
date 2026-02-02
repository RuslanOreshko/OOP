public class CannotColorPrint : IColorPrintBehavior
{
    public void ColorPrint() => Console.WriteLine("Я НЕ можу друкувати кольоровим!");
}
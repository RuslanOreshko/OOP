public class BlackAndWhitePrinter : Printer
{
    public BlackAndWhitePrinter() : base(new CannotColorPrint()) {}
}
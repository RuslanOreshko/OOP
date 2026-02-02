public abstract class Printer
{
    protected IColorPrintBehavior colorPrint;
    
    protected Printer(IColorPrintBehavior colorPrint)
    {
        this.colorPrint = colorPrint;
    }

    public void PerformColorPrint()
    {
        colorPrint.ColorPrint();
    }
}
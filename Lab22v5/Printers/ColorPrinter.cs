// Наслідуваня від абстрактного базового класу.
public class ColorPrinter : Printer 
{
    public ColorPrinter() : base(new CanColorPrint()) {}
}
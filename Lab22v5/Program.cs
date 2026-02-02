// Поганий варіант

// class Program
// {
//     static void MakePrinterPrint(Printer print)
//     {
//         print.PrintColorImage();
//     }

//     static void Main()
//     {
//         // Буде викинуто NotImplementedException()
//         Printer printer = new BlackAndWhitePrinter();
//         MakePrinterPrint(printer);
//     }
// }



// Правильний варіант.
class Program
{
    static void Main()
    {
        // Обєкт створюється через Printer
        Printer colorPrinter = new ColorPrinter();
        colorPrinter.PerformColorPrint();

        // Підміна на об'єкт підкласу
        ColorPrinter colorPrinter1 = new ColorPrinter();
        colorPrinter1.PerformColorPrint();

        Printer blackAndWhitePrinter = new BlackAndWhitePrinter();
        blackAndWhitePrinter.PerformColorPrint();

        BlackAndWhitePrinter blackAndWhitePrinter1 = new BlackAndWhitePrinter();
        blackAndWhitePrinter1.PerformColorPrint();
    }
}
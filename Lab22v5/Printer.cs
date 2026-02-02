// Поганий варіант


// public class Printer
// {
//     public virtual void PrintColorImage() => Console.WriteLine("Кольорове зображення надруковано!");
// }

// public class BlackAndWhitePrinter : Printer
// {
//     // Кидаю Exception тому що чорнобілий принтер не можу роздрукувати кольоворе зображення.
//     public override void PrintColorImage() => throw new NotImplementedException();
// }
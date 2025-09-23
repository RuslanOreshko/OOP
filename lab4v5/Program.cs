using System;

namespace Lab_4
{
    // інтерфейс Istorable
    interface IStorable
    {
        string Title { get; }
        int Pages { get; }
        void ShowInfo();
    }


    // Унаслідування інтерфейсу
    abstract class Publication : IStorable
    {
        public string Title { get; }
        public int Pages { get; }

        // конструктор через яекий додається назва, та кількість сторінок
        protected Publication(string title, int pages)
        {
            Title = title;
            Pages = pages;
        }
        public abstract void ShowInfo();
    }

    // Клас Book наслідує абстрактний клас Publication
    class Book : Publication
    {
        public string Author { get; }

        // конструктор дає змогу зручніше добавляти видання
        public Book(string title, int pages, string author) : base(title, pages)
        {
            Author = author;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Книга: {Title}, Автор: {Author} Кількість сторінок{Pages}");
        }
    }

    // Клас Magazine наслідує абстрактний клас Publication
    class Magazine : Publication
    {
        public int IssueNumber { get; }

        public Magazine(string title, int pages, int issueNumber) : base(title, pages)
        {
            IssueNumber = issueNumber;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Журнал: {Title}, Видання: {IssueNumber}, Кількість сторінок: {Pages}");

        }
    }


    // клас Library це агрегація. Він містить колекцію всіх видань, які ми додали (Book, Magazine)
    class Library
    {
        // Сам масив із всіма виданнями
        List<IStorable> storables = new List<IStorable>();

        // Метод для додавання видання
        public void AddItem(IStorable storable)
        {
            storables.Add(storable);
        }

        // Метод для показу суми всіх виданнь
        public void GetTotalPages()
        {
            int totalPages = 0;

            foreach (var s in storables)
            {
                int pages = s.Pages;
                totalPages += pages;
            }
            Console.WriteLine($"Сума сторінок всіх виданнь: {totalPages}");
        }

        // Метод для показу середнього обсягу всіх виданнь
        public void GetAveragePages()
        {
            int totalPages = 0;

            foreach (var s in storables)
            {
                int pages = s.Pages;
                totalPages += pages;
            }

            int averagePages = totalPages / storables.Count;

            Console.WriteLine($"Середнія обсяг видань: {averagePages}");
        }

        // Метод для показу всіх виданнь
        public void ShowAll()
        {
            foreach (var s in storables)
            {
                s.ShowInfo();
            }
        }
    }

    class Prgoram
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Для прикладу додам пару видань
            Book book1 = new Book("Пригоди Шерлока Холмса", 250, "Артур Конан Дойл");
            Magazine magazine1 = new Magazine("National Geographic", 100, 5);

            library.AddItem(book1);
            library.AddItem(magazine1);

            // Основні методи
            library.ShowAll();
            library.GetTotalPages();
            library.GetAveragePages();
        }
    }
}
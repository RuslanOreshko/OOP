using System;
using RatingSpace;
using ExceptionSpace;


namespace MovieSpace
{
    class Movie
    {
        // Агрегація
        // Властивість Title та список властивіть rating в якому зберігаються рейтинги
        public string? Title { get; }
        private List<Rating> ratings { get; } = new();

        // Конструктор для зручного введеня назви фільма 
        public Movie(string title)
        {
            Title = title;
        }

        // Метод для додавання нового рейтингу у список 
        public void AddRating(Rating rating)
        {
            ratings.Add(rating);
        }

        // Метод який повертає середній рейтинг фільму
        public double GetAverageRating()
        {
            // Якщо в списку нічого немає, то повертає 0
            if (ratings.Count == 0)
            {
                return 0;
            }

            // Поміщаємо в values тільки сам рейтинг, без користувачів
            var values = ratings.Select(r => r.Value).ToList();

            // Якщо в values меньше або 5 записів, тоді відсікаємо 1 мін. та 1 макс.
            if (values.Count <= 5)
            {
                values.Remove(values.Min());
                values.Remove(values.Max());
            }

            
            return values.Average();
        }
    }
}
using System;
using ExceptionSpace;
using RatingSpace;
using MovieSpace;
using UtilsCpace;


namespace MainSpace
{
    class Program
    {
        static void Main()
        {

            try
            {
                // Колекція із фільмами
                var movies = new List<Movie>
            {
                new Movie("Інтерстеллер"),
                new Movie("Біжучий по лезу"),
                new Movie("Матриця")
            };
                // Додаємо рейтинги до фільмів, для перевірки
                movies[0].AddRating(new Rating("Макс", 9));
                movies[0].AddRating(new Rating("Ілля", 8));
                movies[0].AddRating(new Rating("Костя", 3));
                movies[0].AddRating(new Rating("Денис", 7));
                movies[0].AddRating(new Rating("Марія", 9));
                movies[0].AddRating(new Rating("Григорій", 7));

                movies[1].AddRating(new Rating("Макс", 6));
                movies[1].AddRating(new Rating("Валерія", 8));
                movies[1].AddRating(new Rating("Кристіна", 6));

                movies[2].AddRating(new Rating("Ілля", 9));
                movies[2].AddRating(new Rating("Дмитрій", 6));
                movies[2].AddRating(new Rating("Марія", 3));
                movies[2].AddRating(new Rating("Віталій", 11));
                movies[2].AddRating(new Rating("Костя", 6));

                // Повертаємо фільм із самим більший середнім значенням, за допомогою MaxBy<T> 
                // items = movies, selector = GetAverageRating();
                var bestMovie = Utils.MaxBy(movies, m => m.GetAverageRating());
                Console.WriteLine($"Найкращий фільм: {bestMovie.Title}");
                Console.WriteLine($"Середній рейтинг: {bestMovie.GetAverageRating():F2}");
            }
            // Власний виняток буде викликатись, коли ми вийдемо за межі 1-10, або якщо колекція фільмів буде пуста
            catch (InvalidRatingException ex)
            {
                Console.WriteLine($"Помилка рейтингу: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Інша помилка {ex.Message}");
            }
        }
    }
}
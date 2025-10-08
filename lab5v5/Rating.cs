using System;
using ExceptionSpace;


namespace RatingSpace
{
    class Rating
    {
        // Властивості Name та Value, Value це рейтинг
        public string Name { get; }
        public int Value { get; }


        // Конструкотр
        public Rating(string name, int value)
        {
            // Якщо value виходить за межі, тоді викликаємо власний метод
            if (value < 0 || value > 10)
            {
                throw new InvalidRatingException($"{value} недопустимо, має бути 1-10");
            }

            Name = name;
            Value = value;
        }
    }
}
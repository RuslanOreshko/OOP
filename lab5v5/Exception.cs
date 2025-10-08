using System;


namespace ExceptionSpace
{
    // Створення власного винятка
    class InvalidRatingException : Exception
    {
        public InvalidRatingException(string message) : base(message) { }
    }
}
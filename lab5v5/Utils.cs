using System;
using ExceptionSpace;


namespace UtilsCpace
{
    class Utils
    {
        // Generic метод
        public static T MaxBy<T>(IEnumerable<T> items, Func<T, double> selector)
        {
            // Ящко items пустий тоді визиваємо власний виняток
            if (!items.Any())
            {
                throw new InvalidRatingException("Колекція порожня");
            }

            // Знаходим саме більше значення
            
            T maxItem = items.First();
            double maxValue = selector(maxItem);
            foreach (var item in items)
            {
                double value = selector(item);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxItem = item;
                }
            }
            return maxItem;
        }
    }
}
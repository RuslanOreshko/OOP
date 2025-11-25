using System;


namespace Retry_helper
{
    public static class RetryHelper
    {
        public static T ExecuteWithRetry<T>(
            Func<T> operation,
            int retryCount = 3,
            TimeSpan initialDelay = default,
            Func<Exception, bool> shouldRetry = null!)
        {
            // Кількість повторів
            int attempt = 0;
            
            // Застримка між спробами 
            TimeSpan delay = initialDelay == default ? TimeSpan.FromSeconds(1) : initialDelay;

            while (true)
            {
                // Обробка винятків
                try
                {
                attempt++;
                // Логування, кількість спроб
                Console.WriteLine($"[RetryHelper] Спроба #{attempt}");

                // Повертає обрану операцію (визиває метод)
                return operation();
                }
                catch(Exception ex)
                {   
                    Console.WriteLine($"[RetryHelper] Помилка: {ex.Message}");

                    // Якщо немає shouldRetry буде повтор
                    if(shouldRetry != null && !shouldRetry(ex))
                    {
                        Console.WriteLine("[RetryHelper] Цей тип помилки не підлягає повтору - настпуна спроба");
                        throw;
                    }

                    // якщо досягнуто ліміту
                    if(attempt > retryCount)
                    {
                        Console.WriteLine("[RetryHelper] досягнута максимальна кількість спроб");
                        throw;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"[RetryHelper] Очікування {delay.TotalSeconds} сек перед повтором...");
                    Thread.Sleep(delay);
                    Console.WriteLine();

                    // експоненційна затримка
                    delay = TimeSpan.FromMilliseconds(delay.TotalMilliseconds * 2);
                }
            }
        }
    }
}
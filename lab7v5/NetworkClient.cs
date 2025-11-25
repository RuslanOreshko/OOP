using System;
using System.Net.Http;

namespace Http_Request_Exception
{
    public class NetworkClient
    {
        // Рахунок спроб
        private int _attemptCount = 0;

        public bool SendConfigUpdate(string url, string configJson)
        {
            _attemptCount ++;

            // Логування 
            Console.WriteLine($"[NetworkClient] Спроба відправки #{_attemptCount} на {url}");
            Console.WriteLine($"Дані: {configJson}");
            
            // Невдалі спроби
            if (_attemptCount <= 3)
            {
                Console.WriteLine("[NetworkClient] Симуляція: генеруємо HttpRequestException");
                throw new HttpRequestException("Сталась тимчасова помилка мережі");
            }

            // Успішно
            Console.WriteLine("[NetworkClient] Успіх - Конфіг успішно відправлено");
            return true;
        }

    }
}
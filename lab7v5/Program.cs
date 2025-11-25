using System;
// Імпорутую всі потрібно файли
using IO_Exception;
using Http_Request_Exception;
using Retry_helper;


class Program
{
    static void Main()
    {   
        // об'єкти класів
        FileProcessor fp = new FileProcessor();
        NetworkClient nk = new NetworkClient();

        // Перший виклик для FileProcessor
        RetryHelper.ExecuteWithRetry(
            operation: () =>
            {
                fp.UpdateConfig("config.txt", "theme", "dark");
                return true;
            },
            retryCount: 3,
            initialDelay: TimeSpan.FromMilliseconds(300),
            shouldRetry: (ex) =>
            {
                return ex is IOException;
            }
        );
        
        // Для візуальної зручності
        Console.WriteLine();
        Console.WriteLine("Файл успішно оновленно");
        Console.WriteLine();

        // Другий виклик для NetworkClient
        RetryHelper.ExecuteWithRetry(
            operation: () =>
            {
                return nk.SendConfigUpdate(
                    "https://server.com/update",
                    "{ \"theme\": \"dark\" }"
                );
            },
            retryCount: 4,
            initialDelay: TimeSpan.FromMilliseconds(300),
            shouldRetry: (ex) =>
            {
                return ex is HttpRequestException;
            }
        );

        Console.WriteLine("\nКонфіг відправлено на сервер!");
    }
}

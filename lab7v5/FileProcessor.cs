using System;
using System.IO;

namespace IO_Exception
{
    public class FileProcessor
    {
        // Рахунок спроб
        private int _fileCount = 0;
        public void UpdateConfig(string path, string key, string value)
        {
            // Додавання при виклику методу
            _fileCount ++;

            // Логування
            Console.WriteLine($"[FileProcessor] спроба #{_fileCount} оновлення конфігурації");
            Console.WriteLine($"Параметри: {path}, ключ = {key}, значення = {value}");
            
            // Невдалі спроби
            if(_fileCount <= 2)
            {
                Console.WriteLine("[FileProcessor] симуляція: Генеруємо IOException");
                throw new IOException("Сталася IO-помилка при оновленні файлу");
            }
            
            // Успішна спроба
            Console.WriteLine($"[FileProxessor] Успіх - файл успішно оновлено");
        }
    }
}
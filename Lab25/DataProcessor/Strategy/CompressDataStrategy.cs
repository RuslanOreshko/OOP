public class CompressDataStrategy : IDataProcessorStrategy
{
    // Для прикладу просто прибираємо пробілии
    public string Process(string data)
    {
        return data.Replace(" ", "");
    }
}
public class EncryptDataStrategy : IDataProcessorStrategy
{ 
    public string Process(string data)
    {
        return Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(data)
        );
    }
}
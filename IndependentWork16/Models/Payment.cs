namespace Models;


public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public Payment(int id, decimal amount, string cardNumber, string phoneNumber)
    {
        Id = id;
        Amount = amount;
        CardNumber = cardNumber;
        PhoneNumber = phoneNumber;
    }
}
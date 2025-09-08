using System;
using System.Collections.Generic;

namespace lab2_1;

class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
            {
                balance = value;
            }
            else
            {
                Console.WriteLine("Error: Баланс не може бути від'ємним.");
            }
        }
    }

    private List<decimal> transactions = new List<decimal>();

    public decimal this[int index]
    {
        get
        {
            if (index >= 0 && index < transactions.Count)
            {
                return transactions[index];
            }
            else
            {
                Console.WriteLine("Error: Неправильний індекс");
                return 0;
            }
        }
    }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
        transactions.Add(initialBalance);
    }

    public static BankAccount operator +(BankAccount acc, decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Error: Неможливо додати від'ємну суму.");
            return acc;
        }

        acc.Balance += amount;
        acc.transactions.Add(amount);
        return acc;
    }

    public static BankAccount operator -(BankAccount acc, decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Error: Неможливо відняти від'ємну суму.");
            return acc;
        }

        if (acc.Balance - amount < 0)
        {
            Console.WriteLine("Error: Недостаньо коштів!");
            return acc;
        }

        acc.Balance -= amount;
        acc.transactions.Add(amount);
        return acc;
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Поточний баланс: {Balance}");
    }


}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Вітаємо у банку!");
        Console.WriteLine("Введіть ваш початковий баланс:");
        int firstBalance = Convert.ToInt32(Console.ReadLine());

        BankAccount account = new BankAccount(firstBalance);
        account.ShowBalance();

        account += 500;
        account.ShowBalance();

        account -= 200;
        account.ShowBalance();

        Console.WriteLine($"Перша транзакція: {account[0]}");
        Console.WriteLine($"Друга транзакція: {account[1]}");
        Console.WriteLine($"Третя транзакція: {account[2]}");
    }
}

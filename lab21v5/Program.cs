using Services;
using Factories;

class Program
{
    static void Main()
    {
        var gymService = new GymService();

        var morning = GymStrategyFactory.CreateStrategy("MorningPass");
        var day = GymStrategyFactory.CreateStrategy("DayPass");
        var full = GymStrategyFactory.CreateStrategy("FullPass");
        var premium = GymStrategyFactory.CreateStrategy("PremiumPass");

        Console.WriteLine("MorningPass: " + gymService.CalculateGymCost(4, true, morning)); // Із басейном.
        Console.WriteLine("MorningPass without basin: " + gymService.CalculateGymCost(4, false, morning)); // Без.
        Console.WriteLine("DayPass: " + gymService.CalculateGymCost(4, true, day));
        Console.WriteLine("FullPass: " + gymService.CalculateGymCost(4, true, full));
        Console.WriteLine("PremiumPass: " + gymService.CalculateGymCost(4, false, premium));
    }
}

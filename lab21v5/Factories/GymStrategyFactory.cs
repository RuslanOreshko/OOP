using Mocks;
using Interface;

namespace Factories;

public class GymStrategyFactory
{
    public static IGymStrategy CreateStrategy(string deliveryType)
    {
        switch (deliveryType)
        {
            case "DayPass":
                return new DayPassStrategy();
            case "MorningPass":
                return new MorningPassStrategy();
            case "FullPass":
                return new FullPassStrategy();
            case "PremiumPass":
                return new PremiumPass();
            default:
                throw new ArgumentException("Unknown delivery type");
        }
    }
}
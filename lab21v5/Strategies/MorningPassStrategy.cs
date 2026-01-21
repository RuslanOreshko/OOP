using Interface;

namespace Mocks;

public class MorningPassStrategy : IGymStrategy
{
    private const int MORNING_PASS_PRICE = 115;

    public decimal CalculateCost(decimal hours, bool basin)
    {
        if (basin)
        {
            decimal resultWithBasin = hours * MORNING_PASS_PRICE + 100;
            return resultWithBasin;
        }
        else
        {
            decimal result = hours * MORNING_PASS_PRICE;
            return result;
        }
    }
}
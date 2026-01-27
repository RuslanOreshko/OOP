using Interface;

namespace Mocks;


public class PremiumPass : IGymStrategy
{
    private const int PREMIUM_PASS_PRICE = 240;

    public decimal CalculateCost(decimal hours, bool basin)
    {
        if (basin)
        {
            decimal ResultWithBasin = hours * PREMIUM_PASS_PRICE + 130;
            return ResultWithBasin;
        }
        else
        {
            decimal ResultWithoutBasin = hours * PREMIUM_PASS_PRICE;
            return ResultWithoutBasin;
        }
    }
}
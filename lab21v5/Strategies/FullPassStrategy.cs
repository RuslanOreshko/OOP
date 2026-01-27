using Interface;

namespace Mocks;

public class FullPassStrategy : IGymStrategy
{
    private const int FULL_PASS_PRICE = 190;

    public decimal CalculateCost(decimal hours, bool basin)
    {
        if (basin)
        {
            decimal resultWithBasin = hours * FULL_PASS_PRICE + 130;
            return resultWithBasin;
        }
        else
        {
            decimal resultWithoutBasin = hours * FULL_PASS_PRICE;
            return resultWithoutBasin;
        }
    }
}
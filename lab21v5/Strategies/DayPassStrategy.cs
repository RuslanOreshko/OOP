using Interface;

namespace Mocks;

public class DayPassStrategy : IGymStrategy
{
    private const int DAY_PASS_PRICE = 150;

    public decimal CalculateCost(decimal hours, bool basin)
    {
        if (basin)
        {
            decimal resultWithBasin = DAY_PASS_PRICE * hours + 115;
            return resultWithBasin;
        }
        else
        {
            decimal resultWithoutBasin = DAY_PASS_PRICE * hours;
            return resultWithoutBasin;
        }
    }
}
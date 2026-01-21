using Interface;

namespace Services;

public class GymService
{
    public decimal CalculateGymCost(decimal hours, bool basin, IGymStrategy strategy)
    {
        return strategy.CalculateCost(hours, basin);
    }
}
namespace Interface;

public interface IGymStrategy
{
    decimal CalculateCost(decimal hours, bool basin);
}
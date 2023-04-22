using Battleships.Domain;

namespace Battleships;

public class RandomGenerator : IRandom
{
    private static readonly Random InstanceValue = new();

    public int Next(int min, int max)
    {
        return InstanceValue.Next(min, max);
    }
}
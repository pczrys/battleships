namespace Battleships.Domain;

public interface IRandom
{
    int Next(int min, int max);
}
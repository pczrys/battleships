using Battleships.Domain.Ships;

namespace Battleships.Domain.GameGrid;

public sealed class HitResult : IShotResult
{
    public HitResult(Ship ship)
    {
        Ship = ship;
    }

    public Ship Ship { get; }
}
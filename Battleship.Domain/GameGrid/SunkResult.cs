using Battleships.Domain.Ships;

namespace Battleships.Domain.GameGrid;

public sealed class SunkResult : IShotResult
{
    public SunkResult(Ship ship)
    {
        Ship = ship;
    }

    public Ship Ship { get; }
}
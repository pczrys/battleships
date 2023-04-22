namespace Battleships.Domain.ShotResults;

public sealed class SunkResult : IShotResult
{
    public SunkResult(IShip ship)
    {
        Ship = ship;
    }

    public IShip Ship { get; }
}
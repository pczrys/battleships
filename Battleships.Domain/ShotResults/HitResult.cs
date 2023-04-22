namespace Battleships.Domain.ShotResults;

public sealed class HitResult : IShotResult
{
    public HitResult(IShip ship)
    {
        Ship = ship;
    }

    public IShip Ship { get; }
}
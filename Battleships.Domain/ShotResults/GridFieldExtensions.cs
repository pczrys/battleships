using Battleships.Domain.GameGrid;

namespace Battleships.Domain.ShotResults;

public static class GridFieldExtensions
{
    public static IShotResult ToShotResult(this GridField field)
    {
        if (field.IsHit)
            return new HitResult(field.Ship!);

        if (field.IsMissed)
            return new MissResult();
            
        if (field.IsSunk)
            return new SunkResult(field.Ship!);

        throw new ArgumentException();
    }
}
using Battleships.Domain.ShotResults;

namespace Battleships.UserInterface;

internal static class ShotResultExtensions
{
    public static string ToMessage(this IShotResult result)
    {
        var message = result switch
        {
            MissResult => "Miss.",
            HitResult r => $"Hit. {r.Ship}.",
            SunkResult r => $"Hit and sunk. {r.Ship}.",
            _ => throw new ArgumentOutOfRangeException(nameof(result))
        };

        return message;
    }
}
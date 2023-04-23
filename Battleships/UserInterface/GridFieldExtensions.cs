using Battleships.Domain.GameGrid;

namespace Battleships.UserInterface;

internal static class GridFieldExtensions
{
    public static string ToPrintable(this GridField field) =>
        field switch
        {
            { IsHit: true } => "X",
            { IsMissed: true } => "O",
            { IsSunk: true } => "S",
            _ => "_"
        };
}
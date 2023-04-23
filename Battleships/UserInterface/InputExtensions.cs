using Battleships.Domain;
using Battleships.Domain.GameGrid;

namespace Battleships.UserInterface;

public static class InputExtensions
{
    public static bool? AsYesNo(this string? input)
    {
        input = input?.ToUpperInvariant();

        if (input != "Y" && input != "N")
            return null;

        return input == "Y";
    }

    public static Coordinates? AsCoordinates(this string? input)
    {
        if (input == null || input.Length < 2)
            return null;

        var col = input.ToUpperInvariant()[0];

        if (!int.TryParse(input[1..], out var row))
            return null;

        return new Coordinates(col, row);
    }
}
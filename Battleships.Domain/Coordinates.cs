using Battleships.Domain.GameGrid;

namespace Battleships.Domain;

public record struct Coordinates(char Column, int Row)
{
    private const char AChar = 'A';

    public bool Validate(int gridSize)
    {
        if (Column < AChar || Column > (char)(AChar + gridSize - 1))
            return false;

        return Row >= 1 && Row <= gridSize;
    }

    public static implicit operator GridCoordinates(Coordinates coordinates) =>
        new(coordinates.Column - AChar, coordinates.Row - 1);
}
using Battleships.Domain.GameGrid;
using Battleships.Domain.UserInterface;

namespace Battleships;

internal class GameConsole : IGameOutput, IGameInput
{
    public void PrintPoint(GridField field)
    {
        var value = field switch
        {
            { IsHit: true } => "X",
            { IsMissed: true } => "O",
            { IsSunk: true } => "S",
            { IsEmpty: false } => "B",
            _ => "_"
        };

        Console.Write($"| {value,-1} ");
    }

    public void PrintRowEnd()
    {
        Console.Write("|");
        PrintEmptyLine();
    }

    public void PrintEmptyLine()
    {
        Console.WriteLine();
    }

    public void PrintRowHeader(int row)
    {
        Console.Write($"{row,2} ");
    }

    public void PrintColumnHeader(int columnsCount)
    {
        Console.Write($"{" ",2}  ");
        for (var i = 0; i < columnsCount; i++)
        {
            var columnHeader = (char)(i + 65);
            Console.Write($" {columnHeader,-2} ");
        }
        PrintEmptyLine();
    }

    public void PrintShotResult(IShotResult result)
    {
        var message = result switch
        {
            MissResult => "Miss.",
            HitResult r => $"Hit. {r.Ship}.",
            SunkResult r => $"Hit and sunk. {r.Ship}",
            _ => throw new ArgumentOutOfRangeException(nameof(result))
        };

        Console.WriteLine(message);
    }

    public void PrintCoordinateInstruction()
    {
        Console.WriteLine("Enter shot coordinates:");
    }

    public void PrintCongratulations()
    {
        Console.WriteLine("Congratulations! You sank all the battleships.");
    }

    public void PrintNewGameQuestion()
    {
        Console.WriteLine("Do you want to play again? [Y]es/[N]o?");
    }

    public void PrintInvalidCoordinates()
    {
        Console.WriteLine("Shot coordinates are invalid. Please try again:");
    }

    public void PrintInvalidAnswer()
    {
        Console.WriteLine("Answer is invalid. Please try again:");
    }

    public (char Column, int Row)? ReadShotCoordinates() => ParseCoordinates(Console.ReadLine());

    private static (char Column, int Row)? ParseCoordinates(string? result)
    {
        if (result == null || result.Length < 2)
            return null;

        var col = result.ToUpperInvariant()[0];
        
        if (!int.TryParse(result[1..], out var row))
            return null;

        return (col, row);
    }

    public bool? ReadYesNoAnswer()
    {
        var result = Console.ReadLine()?.ToUpperInvariant();
        if(result != "Y" && result != "N")
        {
            return null;
        }

        return result == "Y";
    }
}
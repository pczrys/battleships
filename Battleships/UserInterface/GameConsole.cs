using Battleships.Domain.GameGrid;

namespace Battleships.UserInterface;

internal sealed class GameConsole : IGameInput, IGameOutput
{
    public string? Read() => Console.ReadLine();

    public void PrintEmptyLine()
    {
        Console.WriteLine();
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintGrid(GridField[,] grid)
    {
        var columnsCount = grid.GetLength(0);
        var rowsCount = grid.GetLength(1);

        PrintColumnHeader(columnsCount);

        for (var row = 0; row < rowsCount; row++)
        {
            PrintRowHeader(row + 1);
            for (var column = 0; column < columnsCount; column++)
            {
                PrintField(grid[column, row]);
            }
            PrintRowEnd();
        }
    }

    private static void PrintField(GridField field)
    {
        Console.Write($"| {field.ToPrintable(),-1} ");
    }

    private static void PrintRowHeader(int row)
    {
        Console.Write($"{row,2} ");
    }

    private void PrintColumnHeader(int columnsCount)
    {
        Console.Write($"{" ",2}  ");
        for (var i = 0; i < columnsCount; i++)
        {
            var columnHeader = (char)(i + 65);
            Console.Write($" {columnHeader,-2} ");
        }
        PrintEmptyLine();
    }

    private void PrintRowEnd()
    {
        Console.Write("|");
        PrintEmptyLine();
    }
}
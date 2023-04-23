using Battleships.Domain.GameGrid;

namespace Battleships.UserInterface;

public interface IGameOutput
{
    void PrintGrid(GridField[,] grid);
    void PrintMessage(string message);
}
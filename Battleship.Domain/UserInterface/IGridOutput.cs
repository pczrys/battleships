using Battleships.Domain.GameGrid;

namespace Battleships.Domain.UserInterface;

public interface IGridOutput
{
    void PrintPoint(GridField field);
    void PrintRowEnd();
    void PrintEmptyLine();
    void PrintRowHeader(int row);
    void PrintColumnHeader(int columnsCount);
}
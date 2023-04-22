using Battleships.Domain.GameGrid;

namespace Battleships.Domain;

public interface IShip
{
    string Name { get; }

    int BlocksNumber { get; }

    IEnumerable<GridField> GridFields { get; }

    void AddGridField(GridField field);

    bool HasSunk();

    void Hit(GridField field);
}
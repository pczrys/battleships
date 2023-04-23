namespace Battleships.Domain.GameGrid;

public interface IGrid
{ 
    IEnumerable<IShip> Ships { get; }

    GridField[,] Fields { get; }

    void SetShip(IShip ship);

    GridField SetShot(GridCoordinates coordinates);

    int Size { get; }
}
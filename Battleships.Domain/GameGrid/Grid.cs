namespace Battleships.Domain.GameGrid;

public sealed class Grid : IGrid
{
    private readonly IRandom _random;
    private readonly List<IShip> _ships = new();

    public Grid(int size, IRandom random)
    {
        _random = random;
        Size = size;
        Fields = new GridField[Size, Size];

        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                Fields[i, j] = new GridField(new GridCoordinates(i, j));
            }
        }
    }

    public IEnumerable<IShip> Ships => _ships;

    public GridField[,] Fields { get; }

    public int Size { get; }

    public void SetShip(IShip ship)
    {
        while (true)
        {
            var randomPoint = RandomGridField();

            var horizontal = _random.Next(0, 1) == 0;

            if (CanSetShip(ship, randomPoint, horizontal))
            {
                SetShipAt(ship, randomPoint, horizontal);
                return;
            }

            if (CanSetShip(ship, randomPoint, !horizontal))
            {
                SetShipAt(ship, randomPoint, !horizontal);
                return;
            }
        }
    }

    public GridField SetShot(GridCoordinates coordinates)
    {
        var gridField = Fields[coordinates.Column, coordinates.Row];

        if (gridField.Ship == null)
        {
            gridField.State = GridFieldState.Missed;
            return gridField;
        }

        gridField.Ship.Hit(gridField);
        return gridField;
    }

    private GridField RandomGridField()
    {
        var column = _random.Next(0, Size);
        var row = _random.Next(0, Size);

        return new GridField(new GridCoordinates(column, row));
    }

    private void SetShipAt(IShip ship, GridField startField, bool horizontal)
    {
        var startIndex = StartIndexFor(startField, horizontal);
        for (var index = startIndex; index < startIndex + ship.BlocksNumber; index++)
        {
            Fields[ColumnFor(startField, horizontal, index), RowFor(startField, horizontal, index)].Ship = ship;
        }
        _ships.Add(ship);
    }

    private bool CanSetShip(IShip ship, GridField startField, bool horizontal)
    {
        var startIndex = StartIndexFor(startField, horizontal);
        for (var index = startIndex; index < startIndex + ship.BlocksNumber; index++)
        {
            if (index == Size)
                return false;

            if (!Fields[ColumnFor(startField, horizontal, index), RowFor(startField, horizontal, index)].IsEmpty)
                return false;
        }
        return true;
    }

    private static int ColumnFor(GridField startField, bool horizontal, int index) => 
        horizontal ? index : startField.Coordinates.Column;

    private static int RowFor(GridField startField, bool horizontal, int index) => 
        horizontal ? startField.Coordinates.Row : index;

    private static int StartIndexFor(GridField startField, bool horizontal) => 
        horizontal ? startField.Coordinates.Column : startField.Coordinates.Row;
}
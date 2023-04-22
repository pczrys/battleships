using Battleships.Domain.Ships;
using Battleships.Domain.UserInterface;

namespace Battleships.Domain.GameGrid;

public sealed class Grid
{
    private readonly int _size;

    private readonly GridField[,] _grid;

    private readonly List<Ship> _ships = new();

    public IEnumerable<Ship> Ships => _ships;

    public Grid(int size)
    {
        _size = size;
        _grid = new GridField[_size, _size];

        for (var i = 0; i < _size; i++)
        {
            for (var j = 0; j < _size; j++)
            {
                _grid[i, j] = new GridField(i + 1, j + 1);
            }
        }
    }

    public void SetShip(Ship ship)
    {
        while (true)
        {
            var randomPoint = GridField.Random(_size);

            var horizontal = RandomGenerator.Instance.Next(0, 1) == 0;

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

    public GridField SetShot(GridField field)
    {
        var gridField = _grid[field.Column, field.Row];

        if (gridField.Ship == null)
        {
            gridField.State = GridFieldState.Missed;
            return gridField;
        }

        gridField.State = GridFieldState.Hit;

        gridField.Ship.UpdateIfSunk();

        return gridField;
    }

    public void Print(IGridOutput gridOutput)
    {
        gridOutput.PrintColumnHeader(_size);

        for (var row = 0; row < _size; row++)
        {
            gridOutput.PrintRowHeader(row + 1);
            for (var column = 0; column < _size; column++)
            {
                gridOutput.PrintPoint(_grid[column, row]);
            }

            gridOutput.PrintRowEnd();
        }
    }

    private void SetShipAt(Ship ship, GridField startField, bool horizontal)
    {
        var startIndex = horizontal ? startField.Column : startField.Row;
        for (var index = startIndex; index < startIndex + ship.BlockNumber; index++)
        {
            _grid[horizontal ? index : startField.Column, horizontal ? startField.Row : index].Ship = ship;
        }
        _ships.Add(ship);
    }

    private bool CanSetShip(Ship ship, GridField startField, bool horizontal)
    {
        var startIndex = horizontal ? startField.Column : startField.Row;
        for (var index = startIndex; index < startIndex + ship.BlockNumber; index++)
        {
            if (index == _size)
                return false;
            if (!_grid[horizontal ? index : startField.Column, horizontal ? startField.Row : index].IsEmpty)
                return false;
        }
        return true;
    }
}
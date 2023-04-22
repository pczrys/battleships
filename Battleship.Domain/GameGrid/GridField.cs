using Battleships.Domain.Ships;

namespace Battleships.Domain.GameGrid;

public record GridField
{
    private const int AInAscii = 65;
    private Ship? _ship;

    public GridField(int column, int row)
    {
        (Column, Row) = (column - 1, row - 1);
        State = GridFieldState.None;
    }

    public GridField(char column, int row)
        : this(column - AInAscii + 1, row)
    { }

    public static GridField Random(int max)
    {
        var column = RandomGenerator.Instance.Next(1, max + 1);
        var row = RandomGenerator.Instance.Next(1, max + 1);

        return new GridField(column, row);
    }

    public int Column { get; }

    public int Row { get; }

    public GridFieldState State { get; set; }

    public Ship? Ship
    {
        get => _ship;
        set
        {
            _ship = value;
            _ship?.AddFieldPoint(this);
        }
    }

    public bool IsEmpty => Ship == null;

    public bool IsHit => State == GridFieldState.Hit;

    public bool IsMissed => State == GridFieldState.Missed;

    public bool IsSunk => State == GridFieldState.Sunk;
}
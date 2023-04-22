namespace Battleships.Domain.GameGrid;

public record GridField
{
    private const int AInAscii = 65;
    private IShip? _ship;

    public GridField(int column, int row)
    {
        (Column, Row) = (column - 1, row - 1);
        State = GridFieldState.Intact;
    }

    public GridField(char column, int row)
        : this(column - AInAscii + 1, row)
    { }

    public int Column { get; }

    public int Row { get; }

    public GridFieldState State { get; set; }

    public IShip? Ship
    {
        get => _ship;
        set
        {
            _ship = value;
            _ship?.AddGridField(this);
        }
    }

    public bool IsEmpty => Ship == null;

    public bool IsHit => State == GridFieldState.Hit;

    public bool IsMissed => State == GridFieldState.Missed;

    public bool IsSunk => State == GridFieldState.Sunk;

    public bool IsIntact => State == GridFieldState.Intact;
}
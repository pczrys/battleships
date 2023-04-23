namespace Battleships.Domain.GameGrid;

public record GridField
{
    private IShip? _ship;

    public GridField(Coordinates coordinates)
        : this((GridCoordinates)coordinates)
    { }

    internal GridField(GridCoordinates coordinates)
    {
        Coordinates = coordinates;
    }

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

    internal GridCoordinates Coordinates { get; }

    public bool IsEmpty => Ship == null;

    public bool IsHit => State == GridFieldState.Hit;

    public bool IsMissed => State == GridFieldState.Missed;

    public bool IsSunk => State == GridFieldState.Sunk;

    public bool IsIntact => State == GridFieldState.Intact;
}
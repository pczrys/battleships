using Battleships.Domain.GameGrid;

namespace Battleships.Domain.Ships;

public abstract class Ship
{
    private readonly IList<GridField> _gridFields;

    public int BlockNumber { get; }

    public IEnumerable<GridField> GridFields => _gridFields;

    protected Ship(int blockNumber)
    {
        _gridFields = new List<GridField>(blockNumber);
        BlockNumber = blockNumber;
    }

    public void AddFieldPoint(GridField point)
    {
        _gridFields.Add(point);
    }

    public bool HasSunk() => _gridFields.Any(gp => gp.IsSunk);

    public void UpdateIfSunk()
    {
        if (GridFields.Any(f => !f.IsHit))
            return;

        foreach (var shipField in GridFields)
        {
            shipField.State = GridFieldState.Sunk;
        }
    }
}
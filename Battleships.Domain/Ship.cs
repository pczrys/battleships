using Battleships.Domain.GameGrid;

namespace Battleships.Domain;

internal sealed class Ship : IShip
{
    private readonly IList<GridField> _gridFields;

    public Ship(string name, int blocksNumber)
    {
        Name = name;
        _gridFields = new List<GridField>(blocksNumber);
        BlocksNumber = blocksNumber;
    }

    public IEnumerable<GridField> GridFields => _gridFields;

    public int BlocksNumber { get; }

    public string Name { get; }

    public void AddGridField(GridField field) 
        => _gridFields.Add(field);

    public bool HasSunk() =>
        _gridFields.Any(gp => gp.IsSunk);

    public void Hit(GridField field)
    {
        field.State = GridFieldState.Hit;

        if (GridFields.Any(f => f.IsIntact))
            return;

        foreach (var shipField in GridFields)
        {
            shipField.State = GridFieldState.Sunk;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}
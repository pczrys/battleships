namespace Battleships.Domain.Ships;

public class Battleship : Ship
{
    public Battleship() : base(5)
    {
    }

    public override string ToString()
    {
        return nameof(Battleship);
    }
}
namespace Battleships.Domain.Ships;

public class Destroyer : Ship
{
    public Destroyer() : base(2)
    {
    }

    public override string ToString()
    {
        return nameof(Destroyer);
    }
}
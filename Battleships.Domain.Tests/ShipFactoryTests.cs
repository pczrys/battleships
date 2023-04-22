using Shouldly;

namespace Battleships.Domain.Tests;

public class ShipFactoryTests
{
    [Fact]
    public void Destroyer_ReturnsShipWith4Blocks()
    {
        ShipFactory.Destroyer()
            .BlocksNumber.ShouldBe(4);
    }

    [Fact]
    public void Destroyer_ReturnsShipWithCorrectName()
    {
        ShipFactory.Destroyer()
            .Name.ShouldBe("Destroyer");
    }

    [Fact]
    public void Battleship_ReturnsShipWith5Blocks()
    {
        ShipFactory.Battleship()
            .BlocksNumber.ShouldBe(5);
    }

    [Fact]
    public void Battleship_ReturnsShipWithCorrectName()
    {
        ShipFactory.Battleship()
            .Name.ShouldBe("Battleship");
    }
}
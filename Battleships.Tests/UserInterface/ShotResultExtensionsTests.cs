using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;
using Battleships.UserInterface;
using Moq;
using Shouldly;

namespace Battleships.Tests.UserInterface;

public class GridFieldExtensionsTests
{
    [Theory]
    [MemberData(nameof(GridFieldTestData))]
    public void ToPrintable_ReturnsCorrectValue(GridField field, string expected)
    {
        field.ToPrintable().ShouldBe(expected);
    }

    public static IEnumerable<object[]> GridFieldTestData()
    {
        yield return new object[] { new GridField(new Coordinates('A', 2)) { State = GridFieldState.Hit }, "X" };
        yield return new object[] { new GridField(new Coordinates('G', 6)) { State = GridFieldState.Missed }, "O" };
        yield return new object[] { new GridField(new Coordinates('D', 7)) { State = GridFieldState.Sunk }, "S" };
        yield return new object[] { new GridField(new Coordinates('C', 4)) { State = GridFieldState.Intact }, "_" };
    }

}

public class ShotResultExtensionsTests
{
    [Theory]
    [MemberData(nameof(ShotResultTestData))]
    public void ToMessage_ReturnsCorrectMessage(IShotResult shotResult, string expected)
    {
        shotResult.ToMessage().ShouldBe(expected);
    }

    [Fact]
    public void ToMessage_WhenShotResultNonPrintable_ThrowsException()
    {
        Should.Throw<ArgumentOutOfRangeException>(
            () => new InvalidCoordinatesResult().ToMessage());
    }

    public static IEnumerable<object[]> ShotResultTestData()
    {
        var ship = new Mock<IShip>();
        ship.Setup(s => s.ToString()).Returns("some-name");

        yield return new object[] { new MissResult(), "Miss." };
        yield return new object[] { new HitResult(ship.Object), "Hit. some-name." };
        yield return new object[] { new SunkResult(ship.Object), "Hit and sunk. some-name." };
    }
}
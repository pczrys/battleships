using Battleships.Domain.GameGrid;
using Shouldly;

namespace Battleships.Domain.Tests;

public class CoordinatesTests
{
    [Theory]
    [InlineData('K', 1, false)]
    [InlineData('A', 11, false)]
    [InlineData('@', 1, false)]
    [InlineData('C', 0, false)]
    [InlineData('C', 2, true)]
    public void Validate_ReturnsCorrectResult(char column, int row, bool expected)
    {
        new Coordinates(column, row).Validate(10)
            .ShouldBe(expected);
    }

    [Fact]
    public void ImplicitCast_ReturnsGridCoordinates()
    {
        GridCoordinates result = new Coordinates('B', 10);
        result.ShouldBe(new GridCoordinates(1, 9));
    }
}
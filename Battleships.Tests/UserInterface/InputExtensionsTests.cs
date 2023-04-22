using Battleships.UserInterface;
using Shouldly;

namespace Battleships.Tests.UserInterface;

public class InputExtensionsTests
{
    [Theory]
    [InlineData("Y", true)]
    [InlineData("N", false)]
    [InlineData("invalid-data", null)]
    public void AsYesNo_ReturnsCorrectValue(string input, bool? expected)
    {
        input.AsYesNo().ShouldBe(expected);
    }

    [Theory]
    [MemberData(nameof(CoordinatesTestData))]
    public void AsCoordinates_ReturnsCorrectValue(string input, (char, int)? expected)
    {
        input.AsCoordinates().ShouldBe(expected);
    }

    public static IEnumerable<object[]> CoordinatesTestData()
    {
        yield return new object[] { "C1", ('C', 1) };
        yield return new object[] { "K11", ('K', 11) };
        yield return new object[] { "d2", ('D', 2) };
        yield return new object[] { "", null! };
        yield return new object[] { "K_", null! };
        yield return new object[] { "B", null! };
    }
}
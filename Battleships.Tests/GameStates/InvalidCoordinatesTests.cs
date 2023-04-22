using Battleships.Game;
using Battleships.GameStates;
using Battleships.UserInterface;
using Moq;
using Shouldly;

namespace Battleships.Tests.GameStates;

public class InvalidCoordinatesTests
{
    [Fact]
    public void Move_ReturnsWaitForMove()
    {
        new InvalidCoordinates().Move(new GameContext
            {
                Output = new Mock<IGameOutput>().Object
            })
            .ShouldBeOfType<WaitForMove>();
    }
}
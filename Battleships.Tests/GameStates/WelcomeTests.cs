using Battleships.Game;
using Battleships.GameStates;
using Battleships.UserInterface;
using Moq;
using Shouldly;

namespace Battleships.Tests.GameStates;

public class WelcomeTests
{
    [Fact]
    public void Move_ReturnStarting()
    {
        new Welcome().Move(new GameContext
            {
                Output = Mock.Of<IGameOutput>()
            })
            .ShouldBeOfType<Starting>();
    }
}
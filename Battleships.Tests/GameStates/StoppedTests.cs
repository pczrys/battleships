using Battleships.Game;
using Battleships.GameStates;
using Shouldly;

namespace Battleships.Tests.GameStates;

public class StoppedTests
{
    [Fact]
    public void Move_ReturnsStopped()
    {
        new Stopped().Move(new GameContext())
            .ShouldBeOfType<Stopped>();
    }
}
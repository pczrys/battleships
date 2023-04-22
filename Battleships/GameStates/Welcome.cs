using Battleships.Game;

namespace Battleships.GameStates;

internal sealed class Welcome : IGameState
{
    public IGameState Move(GameContext context)
    {
        context.Output.PrintMessage("Welcome to BATTLESHIP!");
        context.Output.PrintMessage("You need to hit and sink one Battleship [5 blocks] and two Destroyers [4 blocks].");
        context.Output.PrintMessage("To hit enter coordinates in the form of 'C5' where 'C' is column and '5' is row.");

        return new Starting();
    }
}
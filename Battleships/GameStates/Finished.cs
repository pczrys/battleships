using Battleships.Game;
using Battleships.UserInterface;

namespace Battleships.GameStates;

internal sealed class Finished : IGameState
{
    public IGameState Move(GameContext context)
    {
        context.Output.PrintGrid(context.Game.Grid);
        context.Output.PrintEmptyLine();
        context.Output.PrintMessage("Congratulations! You sank all the battleships.");
        context.Output.PrintMessage("Do you want to play again? [Y]es/[N]o?");

        var playAgain = context.Input.Read().AsYesNo();
        while (playAgain == null)
        {
            context.Output.PrintMessage("Answer is invalid. Please try again:");
            playAgain = context.Input.Read().AsYesNo();
        }

        return playAgain == true 
            ? new Starting()
            : new Stopped();
    }
}
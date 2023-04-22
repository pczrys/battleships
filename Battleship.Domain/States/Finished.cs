namespace Battleships.Domain.States;

internal sealed class Finished : IGameState
{
    public IGameState Move(Game game)
    {
        game.Output.PrintCongratulations();
        game.Output.PrintNewGameQuestion();

        var playAgain = game.Input.ReadYesNoAnswer();
        while (playAgain == null)
        {
            game.Output.PrintInvalidAnswer();
            playAgain = game.Input.ReadYesNoAnswer();
        }
        return playAgain == true 
            ? new Starting()
            : new Stopped();
    }
}
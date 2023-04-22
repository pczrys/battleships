namespace Battleships.Domain.States;

internal sealed class WaitForMove : IGameState
{
    public IGameState Move(Game game)
    {
        game.PrintGrid();
        game.Output.PrintEmptyLine();

        game.Output.PrintCoordinateInstruction();

        var coordinates = game.Input.ReadShotCoordinates();
        while (coordinates == null || !game.ValidateCoordinates(coordinates.Value))
        {
            game.Output.PrintInvalidCoordinates();
            coordinates = game.Input.ReadShotCoordinates();
        }
        
        return new Shooting(coordinates.Value.Column, coordinates.Value.Row);
    }
}
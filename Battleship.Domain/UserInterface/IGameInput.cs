namespace Battleships.Domain.UserInterface;

public interface IGameInput
{
    (char Column, int Row)? ReadShotCoordinates();
    bool? ReadYesNoAnswer();
}
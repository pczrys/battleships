using Battleships.Domain.GameGrid;

namespace Battleships.Domain.UserInterface;

public interface IGameOutput : IGridOutput
{
    void PrintShotResult(IShotResult result);
    void PrintCoordinateInstruction();
    void PrintCongratulations();
    void PrintNewGameQuestion();
    void PrintInvalidCoordinates();
    void PrintInvalidAnswer();
}
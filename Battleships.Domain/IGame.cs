using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;

namespace Battleships.Domain;

public interface IGame
{
    GridField[,] Grid { get; }

    bool IsFinished { get; }

    IShotResult Shoot(char column, int row);

}
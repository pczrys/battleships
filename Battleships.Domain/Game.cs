using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;

namespace Battleships.Domain;

public sealed class Game : IGame
{
    private readonly IGrid _grid;

    public Game(IGrid grid, IEnumerable<IShip> ships)
    {
        _grid = grid;
        foreach (var ship in ships)
        {
            _grid.SetShip(ship);
        }
    }

    public GridField[,] Grid => _grid.Fields;

    public bool IsFinished => _grid.Ships.All(s => s.HasSunk());

    public IShotResult Shoot(Coordinates coordinates)
    {
        if (!coordinates.Validate(_grid.Size))
            return new InvalidCoordinatesResult();

        return _grid.SetShot(coordinates)
            .ToShotResult();
    }
}
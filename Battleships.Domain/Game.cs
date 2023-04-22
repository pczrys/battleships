using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;

namespace Battleships.Domain
{
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

        public IShotResult Shoot(char column, int row)
        {
            if (!ValidateCoordinates((column, row)))
                return new InvalidCoordinatesResult();

            return _grid.SetShot(new GridField(column, row))
                .ToShotResult();
        }

        private bool ValidateCoordinates((char Column, int Row) coordinates)
        {
            if (coordinates.Column < 'A' 
                || coordinates.Column > (char)('A' + _grid.Size - 1))
                return false;
            
            return coordinates.Row >= 1 && coordinates.Row <= _grid.Size;
        }
    }
}
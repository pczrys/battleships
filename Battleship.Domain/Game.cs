using Battleships.Domain.GameGrid;
using Battleships.Domain.Ships;
using Battleships.Domain.States;
using Battleships.Domain.UserInterface;

namespace Battleships.Domain
{
    public sealed class Game
    {
        private const int GridSize = 10;
        private IGameState _gameState;
        private Grid _grid = null!;

        public Game(IGameOutput output, IGameInput input)
        {
            Output = output;
            Input = input;
            _gameState = new Starting();
        }

        public bool IsStopped { get; private set; }

        public IGameOutput Output { get; }

        public IGameInput Input { get; }

        public bool IsFinished => _grid.Ships.All(s => s.HasSunk());

        public IShotResult Shoot(char column, int row)
        {
            var field = _grid.SetShot(new GridField(column, row));
            return field.ToShotResult();
        }

        public void Move()
        {
            _gameState = _gameState.Move(this);

            if (_gameState is Stopped)
                IsStopped = true;
        }

        public void SetupGrid()
        {
            _grid = new Grid(GridSize);
            //grid.SetShip(new Battleship());
            //grid.SetShip(new Destroyer());
            _grid.SetShip(new Destroyer());
        }

        public void PrintGrid() => _grid.Print(Output);

        public bool ValidateCoordinates((char Column, int Row) coordinates)
        {
            if (coordinates.Column is < 'A' or > (char)('A' + GridSize))
                return false;
            
            return coordinates.Row is >= 1 and <= GridSize;
        }
    }
}
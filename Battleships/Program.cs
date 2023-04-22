using Battleships.Game;

var game = new BattleshipGame();

while (!game.IsStopped)
{
    game.Move();
}
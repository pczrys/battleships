using Battleships;
using Battleships.Domain;

var gameConsole = new GameConsole();
var game = new Game(gameConsole, gameConsole);

while (!game.IsStopped)
{
    game.Move();
}
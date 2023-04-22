using Battleships.Domain;
using Battleships.UserInterface;

namespace Battleships.Game;

internal sealed class GameContext
{
    public IGame Game { get; set; } = null!;

    public IGameInput Input { get; init; } = null!;

    public IGameOutput Output { get; init; } = null!;
}
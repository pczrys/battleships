namespace Battleships.Domain;

public static class ShipFactory
{
    private const int DestroyerBlocksNumber = 4;
    private const int BattleshipBlocksNumber = 5;

    public static IShip Destroyer() => 
        new Ship(nameof(Destroyer), DestroyerBlocksNumber);

    public static IShip Battleship() => 
        new Ship(nameof(Battleship),BattleshipBlocksNumber);
}
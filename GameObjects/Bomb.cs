using BombsOrTreatsHell.Controllers;

namespace BombsOrTreatsHell.GameObjects
{
    public class Bomb : GameObject, IGameItem
    {
        public Bomb(Game game) : base("bomb", "Cherry_Bomb.png", game)
        {
        }

        public void OnPlayerInteract()
        {
            Console.WriteLine("Бадум");
            Game.LoseGame();
        }
    }
}

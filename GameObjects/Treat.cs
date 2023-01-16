using BombsOrTreatsHell.Controllers;

namespace BombsOrTreatsHell.GameObjects
{
    public class Treat : GameObject, IGameItem
    {
        public Treat(Game game) : base("treat", "Cookie.png", game)
        {
        }

        public void OnPlayerInteract()
        {
            Console.WriteLine("УРААА");
            Game.UpScore();
        }
    }
}

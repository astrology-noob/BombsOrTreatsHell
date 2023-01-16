using BombsOrTreatsHell.Controllers;

namespace BombsOrTreatsHell.GameObjects
{
    public abstract class GameObject
    {
        public string Type { get; set; }
        public string Image { get; set; }
        protected Game Game { get; set; }
        public GameObject(string type, string image, Game game)
        {
            Type = type;
            Image = image;
            Game = game;
        }
    }
}

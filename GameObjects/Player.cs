using BombsOrTreatsHell.Controllers;

namespace BombsOrTreatsHell.GameObjects
{
    public class Player : GameObject
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public Player(Game game, int posX, int posY) : base("player", "The_Player_Icon.png", game)
        {
            PosX = posX;
            PosY = posY;
        }

        public void MoveUp()
        {
            if (PosX == 0) return;
            PosX--;
            OnMove?.Invoke(PosY, PosX);
        }

        public void MoveDown()
        {
            if (PosX == Game.BoardSize - 1) return;
            PosX++;
            OnMove?.Invoke(PosY, PosX);
        }

        public void MoveLeft()
        {
            if (PosY == 0) return;
            PosY--;
            OnMove?.Invoke(PosY, PosX);
        }

        public void MoveRight()
        {
            if (PosY == Game.BoardSize - 1) return;
            PosY++;
            OnMove?.Invoke(PosY, PosX);
        }

        public event Action<int, int>? OnMove;
    }
}

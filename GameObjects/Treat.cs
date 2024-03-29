﻿using BombsOrTreatsHell.Controllers;

namespace BombsOrTreatsHell.GameObjects
{
    public class Treat : GameObject, IGameItem
    {
        public Treat(Game game) : base("treat", "Cookie.png", game)
        {
        }

        public void OnPlayerInteract()
        {
            Game.UpScore();
            if (Game.TreatAmount == 0)
                Game.WinGame();
        }
    }
}

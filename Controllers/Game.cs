using BombsOrTreatsHell.GameObjects;

namespace BombsOrTreatsHell.Controllers
{
	public class Game
	{
        public int MaxTime { get; private set; } = 60000;
        public int Score { get; private set; }
        public int BestScore { get; private set; }
        public GameStatusEnum Status { get; private set; }
        public int BoardSize { get; private set; } = 7;
        public int BombAmount { get; private set; } = 20;
        public int TreatAmount { get; private set; } = 15;
        public static int SucessfulGames { get; private set; }
        public static int BadGames { get; private set; }
        public Random rnd = new();

        public Player player = null!;
        public List<List<GameObject?>> GameBoard = null!;

        public Game()
        {
            GameBoard = new();
            player = new Player(this, BoardSize / 2, BoardSize / 2);
            GenerateGameBoardInitially();
        }

        public void UpScore()
        {
            Score++;
            TreatAmount--;
        }

        public void LoseGame()
        {
            Status = GameStatusEnum.Defeat;
            BestScore = Math.Max(BestScore, Score);
            BadGames++;
        }

        public void WinGame()
        {
            Status = GameStatusEnum.Victory;
            BestScore = Math.Max(BestScore, Score);
            SucessfulGames++;
        }

        public void Restart()
        {
            Status = GameStatusEnum.InProcess;
            Score = 0;
            GameBoard.Clear();
            TreatAmount = 2;
            player.MoveToInitialPosition();
            GenerateGameBoardInitially();
        }

        public void GenerateGameBoardInitially()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                GameBoard.Add(new List<GameObject?>());
                for (int j = 0; j < BoardSize; j++)
                {
                    GameBoard[i].Add(null);
                }
            }

            GameBoard[player.PosY][player.PosX] = player;

            for (int i = 0; i < BombAmount; i++)
            {
                while (true)
                {
                    int posX = rnd.Next(0, BoardSize);
                    int posY = rnd.Next(0, BoardSize);

                    if (GameBoard[posY][posX] is null)
                    {
                        GameBoard[posY][posX] = new Bomb(this);
                        break;
                    }
                }
            }

            for (int i = 0; i < TreatAmount; i++)
            {
                while (true)
                {
                    int posX = rnd.Next(0, BoardSize);
                    int posY = rnd.Next(0, BoardSize);

                    if (GameBoard[posY][posX] is null)
                    {
                        GameBoard[posY][posX] = new Treat(this);
                        break;
                    }
                }
            }
        }

        // кол-во объектов меняется, неправильно мешаются объекты
        public void MixGameObjects()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (GameBoard[i][j] is GameObject gameObject)
                    {
                        if (gameObject is Player)
                        {
                            GameBoard[i][j] = null;
                        }
                        else
                        {
                            while (true)
                            {
                                int posX = rnd.Next(0, BoardSize);
                                int posY = rnd.Next(0, BoardSize);

                                if (GameBoard[posY][posX] is null)
                                {
                                    GameBoard[i][j] = null;
                                    GameBoard[posY][posX] = gameObject;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            GameBoard[player.PosY][player.PosX] = player;
        }

        public void PlacePlayer()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (GameBoard[i][j] is Player)
                    {
                        GameBoard[i][j] = null;
                    }
                }
            }

            GameBoard[player.PosY][player.PosX] = player;
        }
    }
}

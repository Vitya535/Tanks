using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public class Game : IGame, IObserver// сущность игра, которая видит все на поле и что-то делает при определенных действиях в игре
    {
        public static GameField Field { get; private set; } // игровое поле, оно одно будет - поэтому static (для него тоже будет "Одиночка")
        public List<Tank> TanksInGame { get; private set; } // танки в игре
        public List<Obstacles> ObstaclesInGame { get; private set; } // препятствия в игре
        public List<Artifact> ArtifactsInGame { get; private set; } // артефакты в игре
        public List<CartridgeOnField> CartridgeInGame { get; private set; }

        private static Game instance;        
        // при генерации поля добавлять обьекты не только на поле, но и как наблюдаемые обьекты
        private Game(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
            Field = GameField.InitializeField();
            // также должна быть генерация поля игры

            Builder A = new AttackTankBuilder();
            Builder D = new DefenseTankBuilder();
            Builder P = new BuilderForPlayerTank();
            Director Att = new Director(A);
            Director Def = new Director(D);
            Director Pl = new Director(P);
            Pl.Construct();
            Tank ForPlayer = P.GetResult();

            TanksInGame = new List<Tank>();
            TanksInGame.Add(ForPlayer);
            Random rnd = new Random();
            // разобраться с координатами
            for (int i = 0; i < CountTanks - 1; i++)
            {
                Tank BotTank = null;
                switch (rnd.Next(1,3))
                {
                    case 1:
                        Def.Construct();
                        BotTank = D.GetResult();
                        break;
                    case 2:
                        Att.Construct();
                        BotTank = A.GetResult();
                        break;
                }
                BotTank.AddObserver(instance); // а хорошо ли так делать?
                TanksInGame.Add(BotTank);
            }

            ObstaclesInGame = new List<Obstacles>();
            for (int i = 0; i < CountObstacles; i++)
            {
                Obstacles MyObstacle = null;
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        MyObstacle = new UnDestructibleObstacle(); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyObstacle = new DestructibleObstacle(); // рандомная или конкретная координата на поле
                        break;
                }
                MyObstacle.AddObserver(instance);
                ObstaclesInGame.Add(MyObstacle);
            }

            ArtifactsInGame = new List<Artifact>();
            for (int i = 0; i < CountArtifacts; i++)
            {
                Artifact MyArt = null;
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        MyArt = new RepairKit(); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyArt = new IncreaseDamage(); // рандомная или конкретная координата на поле
                        break;
                    case 3:
                        MyArt = new IncreaseRange(); // рандомная или конкретная координата на поле
                        break;
                }
                MyArt.AddObserver(instance);
                ArtifactsInGame.Add(MyArt);
            }

            CartridgeInGame = new List<CartridgeOnField>();
            for (int i = 0; i < CountCartridges; i++)
            {
                CartridgeOnField MyCart = null;
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Light, 20, 4); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Medium, 25, 4); // рандомная или конкретная координата на поле
                        break;
                    case 3:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Heavy, 30, 4); // рандомная или конкретная координата на поле
                        break;
                }
                MyCart.AddObserver(instance);
                CartridgeInGame.Add(MyCart);
            }
        }

        public static Game Initialize(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
            if (instance == null)
                instance = new Game(CountTanks, CountObstacles, CountCartridges, CountArtifacts);
            // после инициализации - методы типа "создать поле", "создать танки в игре" и т. д.
            return instance;
        }

        public void UpdateMoveRight(Tank ob) // типа как делегат
        {
            ob.MoveRight();
        }

        public void UpdateMoveLeft(Tank ob) // типа как делегат
        {
            ob.MoveLeft();
        }

        public void UpdateMoveUp(Tank ob) // типа как делегат
        {
            ob.MoveUp();
        }

        public void UpdateMoveDown(Tank ob) // типа как делегат
        {
            ob.MoveDown();
        }

        public void UpdateShoot(Tank ob) // типа как делегат
        {
            ob.Shoot();
        }
    }
}

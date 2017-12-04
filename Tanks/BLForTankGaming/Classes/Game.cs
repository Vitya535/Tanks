using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class Game : IGame, IObserver// сущность игра, которая видит все на поле и что-то делает при определенных действиях в игре
    {
        // возможно будет лучше другие контейнеры взять
        public List<Tank> TanksInGame { get; private set; } // танки в игре
        public List<Obstacles> ObstaclesInGame { get; private set; } // препятствия в игре
        public List<Artifact> ArtifactsInGame { get; private set; } // артефакты в игре
        public List<CartridgeOnField> CartridgeInGame { get; private set; }      

        private static Game instance;        
        // при генерации поля добавлять обьекты не только на поле, но и как наблюдаемые обьекты
        private Game(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
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
            // разобраться с координатами (в танке и вообще в генерации)
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
                        MyObstacle = new UnDestructibleObstacle(rnd.Next(1, 31), rnd.Next(1, 21)); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyObstacle = new DestructibleObstacle(rnd.Next(1, 31), rnd.Next(1, 21)); // рандомная или конкретная координата на поле
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
                        MyArt = new RepairKit(rnd.Next(1, 31), rnd.Next(1, 21)); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyArt = new IncreaseDamage(rnd.Next(1, 31), rnd.Next(1, 21)); // рандомная или конкретная координата на поле
                        break;
                    case 3:
                        MyArt = new IncreaseRange(rnd.Next(1, 31), rnd.Next(1, 21)); // рандомная или конкретная координата на поле
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
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Light, 20, 4, rnd.Next(1, 31), rnd.Next(1, 21), Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/LightCartridges.jpg"));
                        break;
                    case 2:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Medium, 25, 4, rnd.Next(1, 31), rnd.Next(1, 21), Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/MediumCartridges.jpg")); 
                        break;
                    case 3:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Heavy, 30, 4, rnd.Next(1, 31), rnd.Next(1, 21), Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/HeavyCartridges.jpg")); 
                        break;
                }
                //MyCart.AddObserver(instance);
                CartridgeInGame.Add(MyCart);
            }
        }

        public static Game Initialize(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
            if (instance == null)
                instance = new Game(CountTanks, CountObstacles, CountCartridges, CountArtifacts);
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

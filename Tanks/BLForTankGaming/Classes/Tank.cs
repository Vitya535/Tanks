using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public partial class Tank : ITanks, IObservableTank, IDamagable // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        private int x;
        private int y;
        private Image image;
        private int health = 100;
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return image; } }
        public int Health { get { return health; } set { health = value; } }
        public Cartridge TankCartridge { get; private set; }
        public IStrategy Strategy { private get; set; }
        public Direction GetDirection { get { return direct; } } 
        Direction direct = Direction.Down;
        IObserver observer;

        List<object> parts = new List<object>();
        public void Add(object part)
        {
            parts.Add(part);
        }

        public void CreateResult()
        {
            TankCartridge = (Cartridge)parts[0];
            Strategy = (IStrategy)parts[1];
            x = (int)parts[2];
            y = (int)parts[3];
            image = (Image)parts[4];
            parts.Clear();
        }

        public void UseStrategy()
        {
            Strategy.TacticAlgorithm();
        }

        public void AddObserver(IObserver o)
        {
            observer = o;
        }

        public void NotifyObserverForMove(Direction dir)
        {
            observer.UpdateMove(this, dir);
        }

        public void NotifyObserverForShoot()
        {
            observer.UpdateShoot(this);
        }

        private void GetArtifact(Artifact art)
        {
            art.CauseEffect(this);
        }

        private void TakeCartridgeOrArtifact(IObjectsOnField Object)
        {
            if (Object is CartridgeOnField)
            {
                TankCartridge = (CartridgeOnField)Object;
                Game.ReturnInstance().StaticObjectsInGame.Remove(Object);
            }
            else if (Object is Artifact)
            {
                GetArtifact((Artifact)Object);
                Game.ReturnInstance().StaticObjectsInGame.Remove(Object);
            }
        }

        public void Move(Direction Path)
        {
            direct = Path;
            IObjectsOnField f;
            switch (Path)
            {
                case Direction.Down:
                    if (Strategy is StrategyForPlayer)
                        image = ImagesForGame.GetTankPlayerDown;
                    else
                        image = ImagesForGame.GetTankAIDown;
                    if (y < 24)
                    {
                        f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y + 1);
                        if (f is Artifact || f is CartridgeOnField || f is null)
                            y++;
                        TakeCartridgeOrArtifact(f);
                    }
                    break;
                case Direction.Left:
                    if (Strategy is StrategyForPlayer)
                        image = ImagesForGame.GetTankPlayerLeft;
                    else
                        image = ImagesForGame.GetTankAILeft;
                    if (x > 0)
                    {
                        f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x - 1, y);
                        if (f is Artifact || f is CartridgeOnField || f is null)
                            x--;
                        TakeCartridgeOrArtifact(f);
                    }
                    break;
                case Direction.Up:
                    if (Strategy is StrategyForPlayer)
                        image = ImagesForGame.GetTankPlayerUp;
                    else
                        image = ImagesForGame.GetTankAIUp;
                    if (y > 0)
                    {
                        f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y - 1);
                        if (f is Artifact || f is CartridgeOnField || f is null)
                            y--;
                        TakeCartridgeOrArtifact(f);
                    }
                    break;
                case Direction.Right:
                    if (Strategy is StrategyForPlayer)
                        image = ImagesForGame.GetTankPlayerRight;
                    else
                        image = ImagesForGame.GetTankAIRight;
                    if (x < 24)
                    {
                        f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x + 1, y);
                        if (f is Artifact || f is CartridgeOnField || f is null)
                            x++;
                        TakeCartridgeOrArtifact(f);
                    }
                    break;
            }
        }

        public void Shoot()
        {
            IObjectsOnField obj = null;
            for (int i = 1; i <= TankCartridge.Range; i++)
            {
                switch (direct)
                {
                    case Direction.Up:
                        obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX, GetY - i);
                        break;
                    case Direction.Down:
                        obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX, GetY + i);
                        break;
                    case Direction.Left:
                        obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX - i, GetY);
                        break;
                    case Direction.Right:
                        obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX + i, GetY);
                        break;
                }
                if (obj == null)
                    continue;
                else if (obj is IDamagable)
                {
                    CauseDamage((IDamagable)obj);
                    break;
                }
                else
                    break;
            }
        }

        private void CauseDamage(IDamagable To)
        {
            To.Health -= TankCartridge.Damage;
            if (To.Health <= 0)
            {
                Game.ReturnInstance().StaticObjectsInGame.Remove(To);
                Game.ReturnInstance().DamagableObjectsInGame.Remove(To);
            }
        }
    }
}
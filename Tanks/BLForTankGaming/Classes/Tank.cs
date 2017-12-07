using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public partial class Tank : ITanks, IObservableTank // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        private int x;
        private int y;
        private Image image;
        private int health = 100;
        private StateOfTank state = new StateAlive();
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return image; } }
        public int Health { get { return health; } set { health = value; } }
        public Cartridge TankCartridge { get; private set; }
        public IStrategy Strategy { private get; set; }
        public StateOfTank State { get { return state; } set { state = value; } }
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

        public void RemoveObserver()
        {
            observer = null;
        }

        public void NotifyObserverForMoveRight() // это событие для танка в наблюдателе
        {
            observer.UpdateMoveRight(this); // добавить в Update все что нужно
        }

        public void NotifyObserverForMoveLeft() // это событие для танка в наблюдателе
        {
            observer.UpdateMoveLeft(this); // добавить в Update все что нужно
        }

        public void NotifyObserverForMoveDown() // это событие для танка в наблюдателе
        {
            observer.UpdateMoveDown(this); // добавить в Update все что нужно
        }

        public void NotifyObserverForMoveUp() // это событие для танка в наблюдателе
        {
            observer.UpdateMoveUp(this); // добавить в Update все что нужно
        }

        public void NotifyObserverForShoot()
        {
            observer.UpdateShoot(this);
        }

        public void GetArtifact(Artifact art)
        {
            art.CauseEffect(this);
        }

        public void MoveRight() // перемещение танка
        {
            if (Strategy is StrategyForPlayer)
                image = ImagesForGame.GetTankPlayerRight;
            else
                image = ImagesForGame.GetTankAIRight;
            direct = Direction.Right;
            if (x < 24)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x + 1, y);
                if (f is Artifact || f is CartridgeOnField || f is null)
                    x++;
                if (f is CartridgeOnField)
                    TankCartridge = (CartridgeOnField)f;
                if (f is Artifact)
                    GetArtifact((Artifact)f);
            }
        }

        public void MoveLeft() // перемещение танка
        {
            if (Strategy is StrategyForPlayer)
                image = ImagesForGame.GetTankPlayerLeft;
            else
                image = ImagesForGame.GetTankAILeft;
            direct = Direction.Left;
            if (x > 0)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x - 1, y);
                if (f is Artifact || f is CartridgeOnField || f is null)
                    x--;
                if (f is CartridgeOnField)
                    TankCartridge = (CartridgeOnField)f;
                if (f is Artifact)
                    GetArtifact((Artifact)f);
            }
        }

        public void MoveDown() // перемещение танка
        {
            if (Strategy is StrategyForPlayer)
                image = ImagesForGame.GetTankPlayerDown;
            else
                image = ImagesForGame.GetTankAIDown;
            direct = Direction.Down;
            if (y < 24)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y + 1);
                if (f is Artifact || f is CartridgeOnField || f is null)
                    y++;
                if (f is CartridgeOnField)
                    TankCartridge = (CartridgeOnField)f;
                if (f is Artifact)
                    GetArtifact((Artifact)f);
            }
        }

        public void MoveUp() // перемещение танка
        {
            if (Strategy is StrategyForPlayer)
                image = ImagesForGame.GetTankPlayerUp;
            else
                image = ImagesForGame.GetTankAIUp;
            direct = Direction.Up;
            if (y > 0)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y - 1);
                if (f is Artifact || f is CartridgeOnField || f is null)
                    y--;
                if (f is CartridgeOnField)
                    TankCartridge = (CartridgeOnField)f;
                if (f is Artifact)
                    GetArtifact((Artifact)f);
            }
        }

        public void Shoot()
        {
            for (int i = 1; i <= TankCartridge.Range; i++)
            {
                IObjectsOnField obj = null;
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
                if (obj is Tank || obj is DestructibleObstacle)
                {
                    if (obj is Tank)
                        CauseDamageToTank((Tank)obj);
                    if (obj is DestructibleObstacle)
                        CauseDamageToObstacle((DestructibleObstacle)obj);
                    break;
                }
            }
        }

        private void CauseDamageToTank(Tank To)
        {
            To.health -= TankCartridge.Damage;
            if (To.health <= 0)
                Game.ReturnInstance().TanksInGame.Remove(To);
        }

        private void CauseDamageToObstacle(DestructibleObstacle To)
        {
            To.TakeDamage(this);
        }
    }
}
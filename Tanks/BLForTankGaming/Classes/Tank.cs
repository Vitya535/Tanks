using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class Tank : ITanks, IObservableTank // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        private int x;
        private int y;
        private Image image;
        private int health;
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return image; } }
        public int Health { get { return health; } set { health = value; } }
        public Cartridge TankCartridge { get; private set; }
        public IStrategy Strategy { private get; set; }
        public StateOfTank State { get; set; }
        IObserver observer;

        List<object> parts = new List<object>();
        public void Add(object part)
        {
            parts.Add(part);
        }

        public void CreateResult()
        {
            health = (int)parts[0];
            TankCartridge = (Cartridge)parts[1];
            Strategy = (IStrategy)parts[2];
            State = (StateOfTank)parts[3];
            x = (int)parts[4];
            y = (int)parts[5];
            image = (Image)parts[6];
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
            if (x < 24)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x + 1, y);
                if (f is Artifact || f is CartridgeOnField || f is null)
                {
                    x++;
                    if (f is CartridgeOnField)
                        TankCartridge = (CartridgeOnField)f;
                    if (f is Artifact)
                        GetArtifact((Artifact)f);
                }
            }
            if (Strategy is StrategyForPlayer)
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PlayRight.jpg");
            else
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIRight.jpg");
        }

        public void MoveLeft() // перемещение танка
        {
            if (x > 0)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x - 1, y);
                if (f is Artifact || f is CartridgeOnField || f is null)
                {
                    x--;
                    if (f is CartridgeOnField)
                        TankCartridge = (CartridgeOnField)f;
                    if (f is Artifact)
                        GetArtifact((Artifact)f);
                }
            }
            if (Strategy is StrategyForPlayer)
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PLayLeft.jpg");
            else
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AILeft.jpg");
        }

        public void MoveDown() // перемещение танка
        {
            if (y < 24)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y + 1);
                if (f is Artifact || f is CartridgeOnField || f is null)
                {
                    y++;
                    if (f is CartridgeOnField)
                        TankCartridge = (CartridgeOnField)f;
                    if (f is Artifact)
                        GetArtifact((Artifact)f);
                }
            }
            if (Strategy is StrategyForPlayer)
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PLayDown.jpg");
            else
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIdown.jpg");
        }

        public void MoveUp() // перемещение танка
        {
            if (y > 0)
            {
                IObjectsOnField f = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), x, y - 1);
                if (f is Artifact || f is CartridgeOnField || f is null)
                {
                    y--;
                    if (f is CartridgeOnField)
                        TankCartridge = (CartridgeOnField)f;
                    if (f is Artifact)
                        GetArtifact((Artifact)f);
                }
            }
            if (Strategy is StrategyForPlayer)
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PlayUp.jpg");
            else
                image = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIUp.jpg");
        }

        public void Shoot() // стрельба танка (не работает из-за условий)
        {
            if (image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PlayUp.jpg") || image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIUp.jpg"))
            {
                for (int i = 0; i <= TankCartridge.Range; i++)
                {
                    IObjectsOnField obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX, GetY - i);
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
            else if (image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PLayDown.jpg") || image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIdown.jpg"))
            {
                for (int i = 0; i <= TankCartridge.Range; i++)
                {
                    IObjectsOnField obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX, GetY + i);
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
            else if (image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PLayLeft.jpg") || image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AILeft.jpg"))
            {
                for (int i = 0; i <= TankCartridge.Range; i++)
                {
                    IObjectsOnField obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX - i, GetY);
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
            else if (image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/PlayRight.jpg") || image == Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIRight.jpg"))
            {
                for (int i = 0; i <= TankCartridge.Range; i++)
                {
                    IObjectsOnField obj = Utils.FindObjectOnNearbyCell(Game.ReturnInstance(), GetX + i, GetY);
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
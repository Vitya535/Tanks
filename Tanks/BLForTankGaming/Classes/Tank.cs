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

        // наверное в передвижении и стрельбе должна быть перерисовка (можно ее в апдейт у игры засунуть и вызывать 2 метода последовательно)
        // для каждого Move добавить, что если он идет на клетку с артефактом или снарядом, то он оказывает эффект на танк (или танк берет артефакт на этой клетке), и артефакт или снаряд исчезают
        // не позволять заезжать при передвижении на другие танки и препятствия
        // но все вышеперечисленное - только когда Саша сделает поле (ну и форму вообще наверное)
        public void MoveRight() // перемещение танка
        {
            
            x++;
        }

        public void MoveLeft() // перемещение танка
        {
            //if (на клетке, на которую перемещаемся есть артефакт или снаряды или ничего нет и если она не за пределами поля, то мы на нее идем, иначе не идем на нее вообще)
            // если это артефакт - переходим в метод CauseEffect, если это снаряды - переприсваиваем снаряды, соответственно потом удаляем с поля и из игры данный обьект
            x--;
            // перерисовка изображения на текущую клетку, если мы переместились и удаление его с прошлой клетки
        }

        public void MoveDown() // перемещение танка
        {
            //if (на клетке, на которую перемещаемся есть артефакт или снаряды или ничего нет и если она не за пределами поля, то мы на нее идем, иначе не идем на нее вообще)
            // если это артефакт - переходим в метод CauseEffect, если это снаряды - переприсваиваем снаряды, соответственно потом удаляем с поля и из игры данный обьект
            y--;
            // перерисовка изображения на текущую клетку, если мы переместились и удаление его с прошлой клетки
        }

        public void MoveUp() // перемещение танка
        {
            //if (на клетке, на которую перемещаемся есть артефакт или снаряды или ничего нет и если она не за пределами поля, то мы на нее идем, иначе не идем на нее вообще)
            // если это артефакт - переходим в метод CauseEffect, если это снаряды - переприсваиваем снаряды, соответственно потом удаляем с поля и из игры данный обьект
            y++;
            // перерисовка изображения на текущую клетку, если мы переместились и удаление его с прошлой клетки
        }

        public void Shoot() // стрельба танка
        {
            // с клетки, на которой танк находится - отправляется запрос на обработку к другим клеткам
            // если на конечной клетке находился танк или разрушаемое препятствие, то 
        }
    }
}
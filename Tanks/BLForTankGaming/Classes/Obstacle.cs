﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Obstacles : IObstaclesOnField, IObservable
    {
        protected int x; // возможно private
        protected int y;  // возможно private
        protected int health; // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int Health { get { return health; } }
        public Image GetObjectImage { get { return objectImage; } }
        private List<IObserver> observers;

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            //foreach (IObserver observer in observers)
                //observer.Update(); // добавить в Update все что нужно
        }

        public Obstacles()
        {
            observers = new List<IObserver>();
        }

        public Obstacles(int obstX, int obstY)
        {
            x = obstX;
            y = obstY;
        }
    }

    class DestructibleObstacle : Obstacles// класс разрушаемых препятствий
    {
        public DestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            health = 100;
        }
    }

    class UnDestructibleObstacle : Obstacles// класс неразрушимых препятствий
    {
        public UnDestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            health = 0;
        }
    }
}

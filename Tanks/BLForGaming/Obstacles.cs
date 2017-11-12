using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLForInterfaces;
using System.Drawing;

namespace BLClassesForGame
{
    abstract class Obstacles : IObstaclesOnField
    {
        protected int x; // возможно private
        protected int y;  // возможно private
        protected int health; // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int Health { get { return health; } }
        public Image GetObjectImage { get { return objectImage; } }

        public Obstacles(int obstX, int obstY, Image image)
        {
            x = obstX;
            y = obstY;
            objectImage = image;
        }
    }

    class DestructibleObstacle : Obstacles// класс разрушаемых препятствий
    {
        public DestructibleObstacle(int obstX, int obstY, Image image) : base(obstX, obstY, image)
        {
            health = 100;
        }
    }

    class UnDestructibleObstacle : Obstacles// класс неразрушимых препятствий
    {
        public UnDestructibleObstacle(int obstX, int obstY, Image image) : base(obstX, obstY, image)
        {
            health = 0;
        }
    }
}

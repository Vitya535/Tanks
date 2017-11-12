using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLForInterfaces;
using System.Drawing;

namespace BLClassesForGame
{
    class DestructibleObstacle : IObstaclesOnField // класс разрушаемых препятствий
    {
        private int x;
        private int y;
        protected int health;
        private Image objectImage;
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int Health { get { return health; } }
        public Image GetObjectImage { get { return objectImage; } }

        public DestructibleObstacle(int obstX, int obstY, Image image)
        {
            x = obstX;
            y = obstY;
            objectImage = image;
            health = 100;
        }
    }

    class UnDestructibleObstacle : DestructibleObstacle // класс неразрушимых препятствий
    {
        public UnDestructibleObstacle(int obstX, int obstY, Image image) : base(obstX, obstY, image)
        {
            health = 0;
        }
    }
}

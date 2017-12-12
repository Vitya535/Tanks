using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Obstacles : IObjectsOnField
    {
        protected readonly int x; // возможно private
        protected readonly int y;  // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return objectImage; } }

        public Obstacles(int obstX, int obstY)
        {
            x = obstX;
            y = obstY;
        }
    }

    public class DestructibleObstacle : Obstacles, IDamagable// класс разрушаемых препятствий
    {
        private int health = 100;
        public int Health { get { return health; } set { health = value; } }

        public DestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            objectImage = ImagesForGame.GetDestructObstacle;
        }
    }

    public class UnDestructibleObstacle : Obstacles// класс неразрушимых препятствий
    {
        public UnDestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            objectImage = ImagesForGame.GetUndestructObstacle;
        }
    }
}

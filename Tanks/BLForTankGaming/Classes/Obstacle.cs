using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Obstacles : IObstaclesOnField
    {
        protected readonly int x; // возможно private
        protected readonly int y;  // возможно private
        protected int health; // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int Health { get { return health; } }
        public Image ObjectImage { get { return objectImage; } }

        public Obstacles(int obstX, int obstY)
        {
            x = obstX;
            y = obstY;
        }
    }

    public class DestructibleObstacle : Obstacles// класс разрушаемых препятствий
    {
        public DestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            objectImage = ImagesForGame.GetDestructObstacle;
            health = 100;
        }

        public void TakeDamage(Tank From)
        {
            health -= From.TankCartridge.Damage;
            if (health <= 0)
                Game.ReturnInstance().StaticObjectsInGame.Remove(this);
        }
    }

    public class UnDestructibleObstacle : Obstacles// класс неразрушимых препятствий
    {
        public UnDestructibleObstacle(int obstX, int obstY) : base(obstX, obstY)
        {
            objectImage = ImagesForGame.GetUndestructObstacle;
            health = 0;
        }
    }
}

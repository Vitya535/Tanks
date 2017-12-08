using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class Utils
    {
        private static Random rnd = new Random();
        public static Random GetRandom { get { return rnd; } }
        private const int widthAndheightOfcell = 20;

        public static void DrawGame(Game game, Graphics g) // рисование начала игры и перемещения
        {
            foreach (Tank t in game.TanksInGame)
                g.DrawImage(t.ObjectImage, new Point(t.GetX * widthAndheightOfcell, t.GetY * widthAndheightOfcell));
            foreach (IObjectsOnField t in game.StaticObjectsInGame)
                g.DrawImage(t.ObjectImage, new Point(t.GetX * widthAndheightOfcell, t.GetY * widthAndheightOfcell));
        }

        public static IObjectsOnField FindObjectOnNearbyCell(Game game, int x, int y) // нахождение обьекта по координатам
        {
            foreach (Tank t in game.TanksInGame)
                if (x == t.GetX && y == t.GetY)
                    return t;
            foreach (IObjectsOnField t in game.StaticObjectsInGame)
                if (x == t.GetX && y == t.GetY)
                    return t;
            return null;
        }
    }
}
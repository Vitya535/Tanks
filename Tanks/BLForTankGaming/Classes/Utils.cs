using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace BLForTankGame
{
    public class Utils
    {
        public static void DrawGame(Game game, Graphics g) // рисование начала игры и перемещения
        {
            foreach (Tank t in game.TanksInGame)
                g.DrawImage(t.ObjectImage, new Point(t.GetX * 20, t.GetY * 20));
            foreach (Obstacles o in game.ObstaclesInGame)
                g.DrawImage(o.ObjectImage, new Point(o.GetX * 20, o.GetY * 20));
            foreach (CartridgeOnField c in game.CartridgeInGame)
                g.DrawImage(c.ObjectImage, new Point(c.GetX * 20, c.GetY * 20));
            foreach (Artifact art in game.ArtifactsInGame)
                g.DrawImage(art.ObjectImage, new Point(art.GetX * 20, art.GetY * 20));
        }

        public static void DrawShoot(Game game, Graphics g, Tank t, float i) //
        {
            g.FillRectangle(Brushes.Black, new Rectangle(new Point((int)(t.GetX + i) * 20, (int)(t.GetY + i) * 20), new Size(6, 6)));
        }

        public static IObjectsOnField FindObjectOnNearbyCell(Game game, int x, int y) // нахождение обьекта по координатам
        {
            foreach (Tank t in game.TanksInGame)
                if (x == t.GetX && y == t.GetY)
                    return t;
            foreach (Obstacles o in game.ObstaclesInGame)
                if (x == o.GetX && y == o.GetY)
                    return o;
            foreach (Artifact art in game.ArtifactsInGame)
                if (x == art.GetX && y == art.GetY)
                {
                    game.ArtifactsInGame.Remove(art);
                    return art;
                }
            foreach (CartridgeOnField c in game.CartridgeInGame)
                if (x == c.GetX && y == c.GetY)
                {
                    game.CartridgeInGame.Remove(c);
                    return c;
                }
            return null;
        }
    }
}

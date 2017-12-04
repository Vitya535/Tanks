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
        public static void DrawGame(Game game, Graphics g) // рисование начала игры
        {
            for (int i = 0; i < game.TanksInGame.Count; i++)
                g.DrawImage(game.TanksInGame[i].ObjectImage, new Point(game.TanksInGame[i].GetX * 20, game.TanksInGame[i].GetY * 20));
            for (int i = 0; i < game.ObstaclesInGame.Count; i++)
                g.DrawImage(game.ObstaclesInGame[i].ObjectImage, new Point(game.ObstaclesInGame[i].GetX * 20, game.ObstaclesInGame[i].GetY * 20));
            for (int i = 0; i < game.CartridgeInGame.Count; i++)
                g.DrawImage(game.CartridgeInGame[i].ObjectImage, new Point(game.CartridgeInGame[i].GetX * 20, game.CartridgeInGame[i].GetY * 20));
            for (int i = 0; i < game.ArtifactsInGame.Count; i++)
                g.DrawImage(game.ArtifactsInGame[i].ObjectImage, new Point(game.ArtifactsInGame[i].GetX * 20, game.ArtifactsInGame[i].GetY * 20));
        }

        public static bool FindObjectOnNearbyCell(Game game, int x, int y) // проверка для перемещения
        {
            bool move = true;
            for (int i = 0; i < game.TanksInGame.Count; i++)
                if (x == game.TanksInGame[i].GetX && y == game.TanksInGame[i].GetY)
                    move = false;
            for (int i = 0; i < game.ObstaclesInGame.Count; i++)
                if (x == game.ObstaclesInGame[i].GetX && y == game.ObstaclesInGame[i].GetY)
                    move = false;
            return move;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLForTankGame;
using System.Threading;

namespace FormForTanks
{
    public partial class FormForTanks : Form
    {
        Bitmap bmp;
        Graphics g;
        Pen MyPen;
        Game MyGame;
        Tank Player;
        public FormForTanks()
        {
            InitializeComponent();
            bmp = new Bitmap(PBForTanks.Width, PBForTanks.Height);
            g = Graphics.FromImage(bmp);
            MyPen = Pens.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 25; i++)
            {
                g.DrawLine(MyPen, new Point(20 * i, 0), new Point(20 * i, PBForTanks.Height));
                g.DrawLine(MyPen, new Point(0, 20 * i), new Point(PBForTanks.Width, 20 * i));
            }
            PBForTanks.Image = bmp;
        }

        private void beginGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyGame = Game.Initialize(3, 20, 5, 3);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
            Player = (Tank)MyGame.StaticObjectsInGame[0];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormForTanks_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    Player.NotifyObserverForMove(Tank.Direction.Up);
                    break;
                case Keys.A:
                case Keys.Left:
                    Player.NotifyObserverForMove(Tank.Direction.Left);
                    break;
                case Keys.S:
                case Keys.Down:
                    Player.NotifyObserverForMove(Tank.Direction.Down);
                    break;
                case Keys.D:
                case Keys.Right:
                    Player.NotifyObserverForMove(Tank.Direction.Right);
                    break;
                case Keys.Space:
                    Player.NotifyObserverForShoot();
                    break;
            }
            g.Clear(Color.White);
            Form1_Load(sender, e);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
        }
    }
}
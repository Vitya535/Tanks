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
        Pen MyPen = Pens.Black;
        Game MyGame;
        public FormForTanks()
        {
            InitializeComponent();
            bmp = new Bitmap(PBForTanks.Width, PBForTanks.Height);
            g = Graphics.FromImage(bmp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 25; i++)
                g.DrawLine(MyPen, new Point(20 * i, 0), new Point(20 * i, PBForTanks.Height));
            for (int j = 0; j <= 25; j++)
                g.DrawLine(MyPen, new Point(0, 20 * j), new Point(PBForTanks.Width, 20 * j));
            PBForTanks.Image = bmp;
        }

        private void beginGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyGame = Game.Initialize(3, 20, 5, 3);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
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
                    MyGame.TanksInGame[0].NotifyObserverForMoveUp();
                    break;
                case Keys.A:
                case Keys.Left:
                    MyGame.TanksInGame[0].NotifyObserverForMoveLeft();
                    break;
                case Keys.S:
                case Keys.Down:
                    MyGame.TanksInGame[0].NotifyObserverForMoveDown();
                    break;
                case Keys.D:
                case Keys.Right:
                    MyGame.TanksInGame[0].NotifyObserverForMoveRight();
                    break;
                case Keys.Space:
                    MyGame.TanksInGame[0].NotifyObserverForShoot();
                    break;
            }
            g.Clear(Color.White);
            Form1_Load(sender, e);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
            g.Dispose();
            g = Graphics.FromImage(bmp);
        }
    }
}
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
        Graphics g;
        Bitmap bmp;
        Pen MyPen;
        Game MyGame;
        public FormForTanks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(PBForTanks.Width, PBForTanks.Height);
            g = Graphics.FromImage(bmp);
            MyPen = Pens.Black;
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
                //        for (int i = 0; i < MyGame.TanksInGame[0].TankCartridge.Range; i++)
                //        {
                //            g.Clear(Color.White);
                //            Form1_Load(sender, e);
                //            g.FillRectangle(Brushes.Black, new RectangleF(new PointF((MyGame.TanksInGame[0].GetX + i) * 20, (MyGame.TanksInGame[0].GetY + i) * 20), new Size(15, 15) ));
                //            PBForTanks.Image = bmp;
                //        }
                        MyGame.TanksInGame[0].NotifyObserverForShoot();
                    break;
            }
            g.Clear(Color.White);
            Form1_Load(sender, e);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
        }
    }
}
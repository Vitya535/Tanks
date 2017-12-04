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

namespace FormForTanks
{
    public partial class FormForTanks : Form
    {
        Graphics g;
        Bitmap bmp;
        Pen MyPen;
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
            Game MyGame = Game.Initialize(3, 20, 5, 3);
            Utils.DrawGame(MyGame, g);
            PBForTanks.Image = bmp;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
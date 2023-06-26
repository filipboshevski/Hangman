using Besilka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Besilka
{
    public partial class Besilka : Form
    {
        private Scene scene;

        public Besilka()
        {
            InitializeComponent();
            scene = new Scene(this);
        }

        private void hangerPanel_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.StartGame();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.StartGame();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            scene.StartGame();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            scene.GetHelp();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.GetHelp();
        }
    }
}

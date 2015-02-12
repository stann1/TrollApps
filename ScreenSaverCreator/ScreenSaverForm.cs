using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaverCreator
{
    public partial class ScreenSaverForm : Form
    {
        public ScreenSaverForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            TopMost = true;

            moveTimer.Interval = 3000;
            moveTimer.Tick += moveTimer_Tick;
            moveTimer.Start();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            // Move text to new location
            textLabel.Hide();
            textLabel.Left = rand.Next(Math.Max(1, Bounds.Width - textLabel.Width));
            textLabel.Top = rand.Next(Math.Max(1, Bounds.Height - textLabel.Height));
            textLabel.Show();
        }

        private void textLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}

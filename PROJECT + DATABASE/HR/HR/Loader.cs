using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            colors_add(); 
        }
        // generic list for color transition
        List<Color> colors = new List<Color>();
        private void colors_add()
        {
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(216, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
        }

        // closing function
        private void close_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // variables for starting the transition
        int color = 0;
        int loop = 0;

        // timer for transition
        private void fader_Tick(object sender, EventArgs e)
        {
            fader.Enabled = false;
            if (color < colors.Count - 1)
            {
                this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(loop, colors[color], colors[color + 1]);
                if (loop < 100)
                {
                    loop++;
                }
                else
                {
                    loop = 0;
                    color++;
                }
                fader.Enabled = true;
            }
            else
            {
                // hiding this window and showing login window
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }
    }
}

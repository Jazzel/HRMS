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
    public partial class AlertMessages : Form
    {
        public AlertMessages(string message, alertType type)
        {
            InitializeComponent();

            switch (type)
            {
                case alertType.success:
                    this.BackColor = Color.SeaGreen;
                    pictureBox1.Image = Image.FromFile(Application.StartupPath+"/icons8_ok_filled.ico");
                    textMsg.Text = message;
                    break;

                case alertType.info:
                    this.BackColor = Color.Blue;
                    textMsg.Text = message;

                    break;

                case alertType.warning:
                    this.BackColor = Color.Goldenrod;
                    textMsg.Text = message;
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "/icons8_warning_shield.ico");

                    break;

                case alertType.error:
                    this.BackColor = Color.Maroon;
                    textMsg.Text = message;
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "/icons8_error_filled.ico");

                    break;

            }
        }

        private void SuccessMsg_Load(object sender, EventArgs e)
        {
            // Setting postion 
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;
            show.Start();
        }
        public enum alertType
        {
            success, info, warning, error
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            close.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        void animateFormShow()
        {

        }

        int interval = 0;

        // show transition
        private void timein_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval; // dropping msg
                interval += 2; // increasing speed
            }
            else
            {
                show.Stop();
                closeAuto.Start();

            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                close.Stop();
                this.Close();
            }
        }

        private async void closeAuto_Tick(object sender, EventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(4));
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                closeAuto.Stop();
                this.Close();
            }
        }
    }
}

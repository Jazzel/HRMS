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
    public partial class SecurityQuestion : Form
    {
        public SecurityQuestion()
        {
            InitializeComponent();
        }

        // moving to change password button
        private void next_to_changePassword_btn_Click(object sender, EventArgs e)
        {
            // verifying answer

            if(answer.Text == ForgotPassword.securityAnswer)
            {
                NewPassword password = new NewPassword();
                this.Hide();
                password.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Incorrect answer !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SecurityQuestion_Load(object sender, EventArgs e)
        {
            // fetching question from database
            question.Text = ForgotPassword.securityQuestion;
        }

        // closing function
        private void close_btn_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }
    }
}

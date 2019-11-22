using HR.DB_DATA;
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
    public partial class NewPassword : Form
    {
        // context class global object
        DB_tables data = new DB_tables();
        public NewPassword()
        {
            InitializeComponent();
        }

        // changing the password
        private void next_to_securityquestion_btn_Click(object sender, EventArgs e)
        {

            // confirming password
            string password; 
            if(new_password_txt.Text == confirm_password_txt.Text)
            {
                password = new_password_txt.Text;
                USER userData = data.USERs.Where(find => find.ID == ForgotPassword.userName).FirstOrDefault();

                userData.PASSWORD = password;
                data.SaveChanges();
                MetroFramework.MetroMessageBox.Show(this, "Password changed !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Login login = new Login();
                this.Hide();
                login.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Passwords not matched !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void NewPassword_Load(object sender, EventArgs e)
        {
            // fetching user's name from it's user name or email
            USER userData = data.USERs.Where(find => find.ID == ForgotPassword.userName).FirstOrDefault();

            username_label.Text = userData.FIRST_NAME + " " + userData.LAST_NAME;
                ;
        }

        // closing function
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        // showing password hidden text
        private void show_1_Click(object sender, EventArgs e)
        {
            if(new_password_txt.isPassword == false)
            {
                new_password_txt.isPassword = true;
            }
            else
            {
                new_password_txt.isPassword = false;
            }
        }

        // showing password hidden text

        private void show_2_Click(object sender, EventArgs e)
        {
            if (confirm_password_txt.isPassword == false)
            {
                confirm_password_txt.isPassword = true;
            }
            else
            {
                confirm_password_txt.isPassword = false;
            }
        }
    }
}

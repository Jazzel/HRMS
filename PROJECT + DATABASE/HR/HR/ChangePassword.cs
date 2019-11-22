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
    public partial class ChangePassword : Form
    {

        // context class global object
        DB_tables data = new DB_tables();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void confirm_password_txt_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void new_password_txt_OnValueChanged(object sender, EventArgs e)
        {

        }

        // fetching name of the user changing the password
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            USER userData = data.USERs.Where(find => find.ID == Login.user_id).FirstOrDefault();
            username_label.Text = userData.FIRST_NAME + " " + userData.LAST_NAME;
            
        }

        // closing function
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // changing password
        private void change_password_btn_Click(object sender, EventArgs e)
        {
            USER userData = data.USERs.Where(find => find.ID == Login.user_id).FirstOrDefault();

            // verifying old password
            if (old_password_txt.Text == userData.PASSWORD)
            {
                string password;
                if (new_password_txt.Text == confirm_password_txt.Text)
                {
                    password = new_password_txt.Text;
                    userData.PASSWORD = password;
                    data.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Password updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Passwords not matched !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Wrong password !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        // showing hidden password
        private void show_1_Click(object sender, EventArgs e)
        {
            if(old_password_txt.isPassword == false)
            {
                old_password_txt.isPassword = true;
            }
            else
            {
                old_password_txt.isPassword = false;
            }
        }

        // showing hidden password
        private void show_2_Click(object sender, EventArgs e)
        {
            if (new_password_txt.isPassword == false)
            {
                new_password_txt.isPassword = true;
            }
            else
            {
                new_password_txt.isPassword = false;
            }
        }

        // showing hidden password
        private void show_3_Click(object sender, EventArgs e)
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

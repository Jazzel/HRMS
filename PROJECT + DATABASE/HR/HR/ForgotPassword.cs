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
    public partial class ForgotPassword : Form
    {
        // global objects and static variables
        DB_tables data = new DB_tables();
        public static string securityQuestion;
        public static string securityAnswer;
        public static int userName;

        public ForgotPassword()
        {
            InitializeComponent();
        }


        // verifying user integerety
        private void next_to_securityquestion_btn_Click(object sender, EventArgs e)
        {


            var adminData = from item in data.USERs
                           where item.ROLE == "admin" && item.USERNAME == email_txt.Text
                           select item;

            //if(adminData != null)
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "You can't change any admin's password !!", "Error");
            //}
            //else
            //{
                if (email_txt.Text != "")
                {
                    string email = email_txt.Text;
                    USER userData = data.USERs.Where(find => find.EMAIL == email || find.USERNAME == email).FirstOrDefault();
                    string question = userData.SECURITY_QUESTION;
                    string answer = userData.SECURITY_ANSWER;
                    int username = userData.ID;

                    if (question == "")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Email or Username not found !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        securityQuestion = question;
                        securityAnswer = answer;
                        userName = username;
                        SecurityQuestion security = new SecurityQuestion();
                        this.Hide();
                        security.Show();
                    }


                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please enter correct email or username !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}

            
        }

        // closing function
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

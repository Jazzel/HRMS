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
    public partial class Login : Form
    {
        // context class global object
        DB_tables data = new DB_tables();

        // static variables for data fetching
        public static int user_id;
        public static string role;
        public Login()
        {
            InitializeComponent();
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // dialog for taking user input
        DialogResult Dialog = new DialogResult();

        private void login_btn_Click(object sender, EventArgs e)
        {
            // loging in the user or admin by email or username
            try
            {
                string email = email_txt.Text;
                string password = pass_txt.Text;
                USER login = data.USERs.Where(find => find.EMAIL == email && find.PASSWORD == password).FirstOrDefault();
                //USER login2 = data.USERs.Where(find => find.USERNAME == email && find.PASSWORD == password).FirstOrDefault();
                USER login2 = data.USERs.Where(find => find.USERNAME == email && find.PASSWORD == password).FirstOrDefault();
                
                if (login != null)
                {
                    if(login.ROLE == "admin")
                    {
                        Dialog = MetroFramework.MetroMessageBox.Show(this, "Welcome Admin !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        role = "admin";
                       
                    }
                    else
                    {
                        Dialog = MetroFramework.MetroMessageBox.Show(this, "Welcome User !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        role = "user";
                    }
                    user_id = login.ID;
                    
                    Dashboard main = new Dashboard();
                    this.Hide();
                    main.Show();
                }
                else if (login2 != null)
                {
                    if (login2.ROLE == "admin")
                    {
                        Dialog = MetroFramework.MetroMessageBox.Show(this, "Welcome Admin !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        role = "admin";
                    }
                    else
                    {
                        Dialog = MetroFramework.MetroMessageBox.Show(this, "Welcome User !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        role = "user";
                    }
                    user_id = login2.ID;
                    Cursor.Current = Cursors.WaitCursor;
                    Dashboard main = new Dashboard();
                    Cursor.Current = Cursors.Default;
                    this.Hide();
                    main.Show();

                }
                else
                {
                    Dialog = MetroFramework.MetroMessageBox.Show(this, "Couldn't find your account !!", "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        // closing function

        private void close_btn_Click(object sender, EventArgs e)
        {

            Environment.Exit(0);
        }

        // moving to forgot password
        private void register_btn_Click(object sender, EventArgs e)
        {
            ForgotPassword forgot = new ForgotPassword();
            this.Hide();
            forgot.Show();
        }

        // showing password hidden text
        private void show_1_Click(object sender, EventArgs e)
        {
            if(pass_txt.isPassword == false)
            {
                pass_txt.isPassword = true;
            }
            else
            {
                pass_txt.isPassword = false;
            }
        }
    }
}

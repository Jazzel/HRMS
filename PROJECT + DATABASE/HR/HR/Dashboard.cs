using HR.DB_DATA;
using HR.Reports;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR
{
    public partial class Dashboard : MaterialForm
    {
        DB_tables data = new DB_tables();
        AlertMessages alert;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;

        public Dashboard()
        {
            InitializeComponent();
            data_fetch();
            profile_load();
            login_load();
        }

        private void theme_manager()
        {
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;
            if (theme == "light")
            {
                profile_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                profile_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                profile_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                profile_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                profile_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                profile_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                profile_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                profile_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                profile_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                profile_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                profile_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                profile_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }

        }

        private void login_load()
        {
            try
            {
                int user_id = Login.user_id;
                USER login = data.USERs.Where(find => find.ID == user_id).FirstOrDefault();
                byte[] image = (byte[])login.IMAGE;
                MemoryStream stream = new MemoryStream(image);
                userImage1.Image = Image.FromStream(stream);
                login_user.Text = login.FIRST_NAME + " " + login.LAST_NAME;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void profile_load()
        {
            try
            {
                int user_id = Login.user_id;
                USER login = data.USERs.Where(find => find.ID == user_id).FirstOrDefault();
                byte[] image = (byte[])login.IMAGE;
                MemoryStream stream = new MemoryStream(image);
                userImage.Image = Image.FromStream(stream);
                username_label.Text = login.FIRST_NAME + "\n" + login.LAST_NAME;
                job_title_label.Text = login.JOB_TITLE;
                about_label.Text = login.DESCRIPTION;
                contact_phone_label.Text = login.CONTACT_PHONE;
                contact_email_label.Text = login.CONTACT_EMAIL;
                contact_address_label.Text = login.CONTACT_ADDRESS;
                experience_label.Text = login.EXPERIENCE;
                education_label.Text = login.EDUCATION;
                language.Text = login.LANGUAGE;
                if (login.SOCIAL_FACEBOOK == null)
                {
                    fb_panel.Visible = false;
                }
                else
                {
                    fb_panel.Visible = true;
                    facebook_label.Text = login.SOCIAL_FACEBOOK;
                }
                if (login.SOCIAL_TWITTER == null)
                {
                    tw_panel.Visible = false;
                }
                else
                {
                    tw_panel.Visible = true;
                    twitter_label.Text = login.SOCIAL_TWITTER;

                }
                if (login.SOCIAL_LINKEDIN == null)
                {
                    ln_panel.Visible = false;
                }
                else
                {
                    ln_panel.Visible = true;
                    linked_label.Text = login.SOCIAL_LINKEDIN;

                }
                if (login.SOCIAL_FACEBOOK == null && login.SOCIAL_TWITTER == null && login.SOCIAL_LINKEDIN == null)
                {
                    social_panel.Visible = false;
                }
                else
                {
                    social_panel.Visible = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }



        private void data_fetch()
        {
            try
            {
                DataTable tb_data = new DataTable();
                tb_data.Columns.Add("ID");
                tb_data.Columns.Add("FIRST_NAME");
                tb_data.Columns.Add("LAST_NAME");
                tb_data.Columns.Add("JOB_TITLE");
                tb_data.Columns.Add("EMAIL");
                tb_data.Columns.Add("USERNAME");
                tb_data.Columns.Add("PHONE");
                tb_data.Columns.Add("ADDRESS");


                var emp_data = from item in data.USERs
                               where item.ROLE == "Employee"
                               select new
                               {
                                   item.ID,
                                   item.FIRST_NAME,
                                   item.LAST_NAME,
                                   item.JOB_TITLE,
                                   item.EMAIL,
                                   item.USERNAME,
                                   item.CONTACT_PHONE,
                                   item.CONTACT_ADDRESS
                               };

                foreach (var item in emp_data)
                {
                    DataRow row = tb_data.NewRow();
                    row["ID"] = item.ID;
                    row["FIRST_NAME"] = item.FIRST_NAME;
                    row["LAST_NAME"] = item.LAST_NAME;
                    row["JOB_TITLE"] = item.JOB_TITLE;
                    row["EMAIL"] = item.EMAIL;
                    row["USERNAME"] = item.USERNAME;
                    row["PHONE"] = item.CONTACT_PHONE;
                    row["ADDRESS"] = item.CONTACT_ADDRESS;
                    tb_data.Rows.Add(row);
                }

                //DataTable tb_data = new DataTable();
                //tb_data.data
                //emp_data_bind.DataSource = emp_data;
                select_emp_for_update.DataSource = tb_data;
                //show_emp.DataSource = tb_data;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            try
            {
                DataTable tb_data = new DataTable();
                tb_data.Columns.Add("ID");
                tb_data.Columns.Add("FIRST_NAME");
                tb_data.Columns.Add("LAST_NAME");
                tb_data.Columns.Add("JOB_TITLE");
                tb_data.Columns.Add("EMAIL");
                tb_data.Columns.Add("USERNAME");
                tb_data.Columns.Add("PHONE");
                tb_data.Columns.Add("ADDRESS");


                var emp_data = from item in data.USERs
                               where item.ROLE == "user"
                               select new
                               {
                                   item.ID,
                                   item.FIRST_NAME,
                                   item.LAST_NAME,
                                   item.JOB_TITLE,
                                   item.EMAIL,
                                   item.USERNAME,
                                   item.CONTACT_PHONE,
                                   item.CONTACT_ADDRESS
                               };

                foreach (var item in emp_data)
                {
                    DataRow row = tb_data.NewRow();
                    row["ID"] = item.ID;
                    row["FIRST_NAME"] = item.FIRST_NAME;
                    row["LAST_NAME"] = item.LAST_NAME;
                    row["JOB_TITLE"] = item.JOB_TITLE;
                    row["EMAIL"] = item.EMAIL;
                    row["USERNAME"] = item.USERNAME;
                    row["PHONE"] = item.CONTACT_PHONE;
                    row["ADDRESS"] = item.CONTACT_ADDRESS;
                    tb_data.Rows.Add(row);
                }

                show_users.DataSource = tb_data;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            try
            {

                var attenData = from item in data.ATTENDANCEs
                                select new
                                {
                                    ID = item.ID,
                                    USER_ID = item.USER_NAME,
                                    USERNAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                    DATE_TIME = item.DATETIME_NOW
                                };
                select_emp_for_attendance.DataSource = attenData.ToList();

                //DataTable tb_data2 = new DataTable();
                //tb_data2.Columns.Add("ID");
                //tb_data2.Columns.Add("USER/EMPLOYEE");
                //tb_data2.Columns.Add("DATE_TIME");
                //var userData = from item in data.ATTENDANCEs
                //               select item;
                //string username;
                //foreach (var item in userData)
                //{
                //    int user_id = item.USER_NAME;
                //    //USER userName = data.USERs.Where(find => find.ID == USER).FirstOrDefault();
                //    //USER emp_data = data.USERs.Where(find => find.ID == user_id).FirstOrDefault();
                //    var emp_data = from item2 in data.USERs
                //                   where item2.ID == user_id
                //                   select new
                //                   {
                //                       item2.FIRST_NAME,
                //                       item2.LAST_NAME
                //                   };
                //    foreach (var data in emp_data)
                //    {
                //        username = data.FIRST_NAME + data.LAST_NAME;
                //        DataRow tb_row = tb_data2.NewRow();
                //        tb_row["ID"] = item.ID;
                //        tb_row["USER/EMPLOYEE"] = username;
                //        tb_row["DATE_TIME"] = item.DATETIME_NOW;
                //        tb_data2.Rows.Add(tb_row);
                //    }
                //}
                //select_emp_for_attendance.DataSource = tb_data2;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            try
            {
                attendance_list.DataSource = data.USERs.ToList();
                attendance_list.DisplayMember = "FIRST_NAME";
                attendance_list.ValueMember = "ID";
                update_username_attendance.DataSource = data.USERs.ToList();
                update_username_attendance.DisplayMember = "FIRST_NAME";
                update_username_attendance.ValueMember = "ID";

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            try
            {
                //select_emp_for_attendance.DataSource = data.ATTENDANCEs.ToList();
                //show_attendance.DataSource = data.ATTENDANCEs.ToList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
            try
            {
                //atten_username_txt.DataSource = data.USERs.ToList();
                //atten_username_txt.DisplayMember = "FIRST_NAME";
                //atten_username_txt.ValueMember = "ID";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
            try
            {

                var salaryData = from item in data.SALARIEs
                                 select new
                                 {
                                     ID = item.ID,
                                     USER_ID = item.USER_NAME,
                                     USERNAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                     FROM_DATE = item.FROM_DATE,
                                     TO_DATE = item.TO_DATE,
                                     SALARY = item.USER_SALARY
                                 };

                select_emp_for_salary.DataSource = salaryData.ToList();
                //show_salary.DataSource = data.SALARIEs.ToList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
            try
            {
                emp_salary_combo.DataSource = data.USERs.ToList();
                emp_salary_combo.DisplayMember = "FIRST_NAME";
                emp_salary_combo.ValueMember = "ID";
                update_username_salary_txt.DataSource = data.USERs.ToList();
                update_username_salary_txt.DisplayMember = "FIRST_NAME";
                update_username_salary_txt.ValueMember = "ID";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void data_clear()
        {
            user_image.Image = null;
            user_first_name_txt.Text = "";
            user_last_name_txt.Text = "";
            user_email_txt.Text = "";
            user_username_txt.Text = "";
            user_password_txt.Text = "";
            user_confirm_password_txt.Text = "";
            user_phone_txt.Text = "";
            user_facebook_txt.Text = "";
            user_twitter_txt.Text = "";
            user_linked_txt.Text = "";
            user_security_answer_txt.Text = "";
            user_address_txt.Text = "";
            user_description_txt.Text = "";
            user_education_txt.Text = "";
            user_experience_txt.Text = "";
            for (int i = 0; i < user_languages.Items.Count; i++)
            {
                user_languages.SetItemChecked(i, false);
            }



        }



        private void select_emp_for_update_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void select_emp_for_attendance_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void select_emp_for_salary_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void save_emp_btn_Click(object sender, EventArgs e)
        {

            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (image_emp.Image == null)
            {
                alert = new AlertMessages("Please insert your picture !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (firstname_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your first name !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (lastname_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your last name !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (jobtitle_combo.Text == "")
            {
                alert = new AlertMessages("Please select any job title !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }


            else if (email_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your email !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (!rEmail.IsMatch(email_txt.Text.Trim()))
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }


            else if (phone_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your phone number !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (address_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (description_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your description !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();

            }





            else
            {



                if (image_emp.Image == null)
                {
                    alert = new AlertMessages("Please insert your picture !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }
                else
                {

                    emp_mini_screen.SelectedTab = more_emp_data;

                }
            }
        }

        private void Save_more_data_Click(object sender, EventArgs e)
        {

            if (languages_select.CheckedItems.Count == 0)
            {
                alert = new AlertMessages("Please check out aleast one language  !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            {

            }

            if (education_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your education !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (experience_txt.Text == "")
            {
                alert = new AlertMessages("Please enter your experience !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }





            else
            {
                string lang_data = "";

                if (languages_select.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < languages_select.CheckedItems.Count; i++)
                    {
                        if (lang_data == "")
                        {
                            lang_data += languages_select.CheckedItems[i].ToString();

                        }
                        else
                        {
                            lang_data += ", " + languages_select.CheckedItems[i].ToString();

                        }

                    }
                }
                else
                {
                    alert = new AlertMessages("Please check out aleast one language !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }






                MemoryStream stream = new MemoryStream();
                image_emp.Image.Save(stream, image_emp.Image.RawFormat);
                byte[] byteImage = stream.GetBuffer();

                USER userData = new USER()
                {
                    FIRST_NAME = firstname_txt.Text,
                    LAST_NAME = lastname_txt.Text,
                    IMAGE = byteImage,
                    JOB_TITLE = jobtitle_combo.Text,
                    CONTACT_PHONE = phone_txt.Text,
                    CONTACT_EMAIL = email_txt.Text,
                    CONTACT_ADDRESS = address_txt.Text,
                    SOCIAL_FACEBOOK = facebook_txt.Text,
                    SOCIAL_TWITTER = twitter_txt.Text,
                    SOCIAL_LINKEDIN = linkedin_txt.Text,
                    ROLE = "Employee",
                    DESCRIPTION = description_txt.Text,
                    EDUCATION = education_txt.Text,
                    EXPERIENCE = experience_txt.Text,
                    LANGUAGE = lang_data,
                    EMAIL = email_txt.Text
                };
                data.USERs.Add(userData);
                data.SaveChanges();

                numbers_fetching();
                data_fetch();
                clear_emp_data();
                emp_mini_screen.SelectedTab = select_emp_screen;
                alert = new AlertMessages("Employee Registered !!", AlertMessages.alertType.success);
                alert.BringToFront();
                alert.Show();
            }




        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            profile_emp_load();
            numbers_fetching();
            Default_theme();
            navbar.Visible = false;
            theme_manager(); color_changer();
            if (Login.role == "admin")
            {
                admin_btn.Enabled = true;
                admin_btn.Cursor = Cursors.Hand;
                admin_nav_btn.Enabled = true;
                admin_nav_btn.Cursor = Cursors.Hand;
            }
            else
            {
                admin_btn.Enabled = false; admin_btn.Cursor = Cursors.No;
                admin_nav_btn.Cursor = Cursors.No;
                admin_nav_btn.Enabled = false;
            }
            alert = new AlertMessages("Welcome User !!", AlertMessages.alertType.success);
            alert.BringToFront();
            alert.Show();
            alert.BringToFront();
            emp_mini_screen.SelectedTab = select_emp_screen;
        }

        private void Default_theme()
        {
            theme = "red";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Red50, Primary.Red800,
               Primary.Red100, Accent.Red100,
               TextShade.BLACK
           );

            theme_manager(); color_changer();
            navbar.BackColor = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientBottomLeft = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientBottomRight = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientTopRight = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientTopLeft = Color.FromArgb(255, 235, 238);
            profile_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            emp_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            attendance_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            salary_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            report_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            admin_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            profile_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            emp_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            attendance_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            salary_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            report_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            admin_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            profile_btn.Activecolor = Color.FromArgb(66, 13, 13);
            emp_btn.Activecolor = Color.FromArgb(66, 13, 13);
            attendance_btn.Activecolor = Color.FromArgb(66, 13, 13);
            salary_btn.Activecolor = Color.FromArgb(66, 13, 13);
            report_btn.Activecolor = Color.FromArgb(66, 13, 13);
            admin_btn.Activecolor = Color.FromArgb(66, 13, 13);
            boundary1.BackColor = Color.FromArgb(198, 40, 40);
            boundary2.BackColor = Color.FromArgb(198, 40, 40);
        }

        private void Red_Click(object sender, EventArgs e)
        {
            theme = "red";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Red50, Primary.Red800,
               Primary.Red100, Accent.Red100,
               TextShade.BLACK
           );

            theme_manager(); color_changer();
            navbar.BackColor = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientBottomLeft = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientBottomRight = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientTopRight = Color.FromArgb(255, 235, 238);
            mini_navbar.GradientTopLeft = Color.FromArgb(255, 235, 238);
            profile_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            emp_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            attendance_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            salary_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            report_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            admin_btn.Normalcolor = Color.FromArgb(198, 40, 40);
            profile_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            emp_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            attendance_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            salary_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            report_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            admin_btn.OnHovercolor = Color.FromArgb(217, 111, 111);
            profile_btn.Activecolor = Color.FromArgb(66, 13, 13);
            emp_btn.Activecolor = Color.FromArgb(66, 13, 13);
            attendance_btn.Activecolor = Color.FromArgb(66, 13, 13);
            salary_btn.Activecolor = Color.FromArgb(66, 13, 13);
            report_btn.Activecolor = Color.FromArgb(66, 13, 13);
            admin_btn.Activecolor = Color.FromArgb(66, 13, 13);
            boundary1.BackColor = Color.FromArgb(198, 40, 40);
            boundary2.BackColor = Color.FromArgb(198, 40, 40);
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            theme = "yellow";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Yellow50, Primary.Yellow800,
               Primary.Yellow100, Accent.Yellow100,
               TextShade.BLACK
           );

            theme_manager(); color_changer();
            mini_navbar.BackColor = Color.FromArgb(255, 253, 231);
            navbar.BackColor = Color.FromArgb(255, 253, 231);
            mini_navbar.GradientBottomLeft = Color.FromArgb(255, 253, 231);
            mini_navbar.GradientBottomRight = Color.FromArgb(255, 253, 231);
            mini_navbar.GradientTopRight = Color.FromArgb(255, 253, 231);
            mini_navbar.GradientTopLeft = Color.FromArgb(255, 253, 231);
            profile_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            emp_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            attendance_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            salary_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            report_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            admin_btn.Normalcolor = Color.FromArgb(249, 168, 37);
            profile_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            emp_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            attendance_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            salary_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            report_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            admin_btn.OnHovercolor = Color.FromArgb(249, 238, 37);
            profile_btn.Activecolor = Color.FromArgb(245, 107, 23);
            emp_btn.Activecolor = Color.FromArgb(245, 107, 23);
            attendance_btn.Activecolor = Color.FromArgb(245, 107, 23);
            salary_btn.Activecolor = Color.FromArgb(245, 107, 23);
            report_btn.Activecolor = Color.FromArgb(245, 107, 23);
            admin_btn.Activecolor = Color.FromArgb(245, 107, 23);
            boundary1.BackColor = Color.FromArgb(249, 168, 37);
            boundary2.BackColor = Color.FromArgb(249, 168, 37);
        }

        private void Green_Click(object sender, EventArgs e)
        {
            theme = "green";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Green50, Primary.Green800,
               Primary.Green100, Accent.Green100,
               TextShade.BLACK
           );


            theme_manager(); color_changer();
            mini_navbar.BackColor = Color.FromArgb(232, 245, 233);
            navbar.BackColor = Color.FromArgb(232, 245, 233);
            mini_navbar.GradientBottomLeft = Color.FromArgb(232, 245, 233);
            mini_navbar.GradientBottomRight = Color.FromArgb(232, 245, 233);
            mini_navbar.GradientTopRight = Color.FromArgb(232, 245, 233);
            mini_navbar.GradientTopLeft = Color.FromArgb(232, 245, 233);
            profile_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            emp_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            attendance_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            salary_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            report_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            admin_btn.Normalcolor = Color.FromArgb(46, 125, 50);
            profile_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            emp_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            attendance_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            salary_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            report_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            admin_btn.OnHovercolor = Color.FromArgb(135, 201, 138);
            profile_btn.Activecolor = Color.FromArgb(15, 41, 16);
            emp_btn.Activecolor = Color.FromArgb(15, 41, 16);
            attendance_btn.Activecolor = Color.FromArgb(15, 41, 16);
            salary_btn.Activecolor = Color.FromArgb(15, 41, 16);
            report_btn.Activecolor = Color.FromArgb(15, 41, 16);
            admin_btn.Activecolor = Color.FromArgb(15, 41, 16);
            boundary1.BackColor = Color.FromArgb(46, 125, 50);
            boundary2.BackColor = Color.FromArgb(46, 125, 50);
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            theme = "gray";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.BlueGrey50, Primary.BlueGrey800,
               Primary.BlueGrey100, Accent.Blue100,
               TextShade.BLACK
           );


            theme_manager(); color_changer();
            mini_navbar.BackColor = Color.FromArgb(236, 239, 241);
            navbar.BackColor = Color.FromArgb(236, 239, 241);
            mini_navbar.GradientBottomLeft = Color.FromArgb(236, 239, 241);
            mini_navbar.GradientBottomRight = Color.FromArgb(236, 239, 241);
            mini_navbar.GradientTopRight = Color.FromArgb(236, 239, 241);
            mini_navbar.GradientTopLeft = Color.FromArgb(236, 239, 241);
            profile_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            emp_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            attendance_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            salary_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            report_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            admin_btn.Normalcolor = Color.FromArgb(55, 71, 79);
            profile_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            emp_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            attendance_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            salary_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            report_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            admin_btn.OnHovercolor = Color.FromArgb(190, 190, 190);
            profile_btn.Activecolor = Color.FromArgb(18, 23, 26);
            emp_btn.Activecolor = Color.FromArgb(18, 23, 26);
            attendance_btn.Activecolor = Color.FromArgb(18, 23, 26);
            salary_btn.Activecolor = Color.FromArgb(18, 23, 26);
            report_btn.Activecolor = Color.FromArgb(18, 23, 26);
            admin_btn.Activecolor = Color.FromArgb(18, 23, 26);
            boundary1.BackColor = Color.FromArgb(55, 71, 79);
            boundary2.BackColor = Color.FromArgb(55, 71, 79);
        }

        private void Light_Click(object sender, EventArgs e)
        {
            theme = "light";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Blue50, Primary.Blue800,
               Primary.Blue100, Accent.Blue100,
               TextShade.BLACK
           );

            theme_manager(); color_changer();
            boundary1.BackColor = Color.FromArgb(21, 101, 192);
            boundary2.BackColor = Color.FromArgb(21, 101, 192);
            mini_navbar.BackColor = Color.FromArgb(227, 242, 253);
            navbar.BackColor = Color.FromArgb(227, 242, 253);
            mini_navbar.GradientBottomLeft = Color.FromArgb(227, 242, 253);
            mini_navbar.GradientBottomRight = Color.FromArgb(227, 242, 253);
            mini_navbar.GradientTopRight = Color.FromArgb(227, 242, 253);
            mini_navbar.GradientTopLeft = Color.FromArgb(227, 242, 253);
            profile_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            emp_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            attendance_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            salary_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            report_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            admin_btn.Normalcolor = Color.FromArgb(21, 101, 192);
            profile_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            emp_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            attendance_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            salary_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            report_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            admin_btn.OnHovercolor = Color.FromArgb(99, 152, 213);
            profile_btn.Activecolor = Color.FromArgb(14, 67, 128);
            emp_btn.Activecolor = Color.FromArgb(14, 67, 128);
            attendance_btn.Activecolor = Color.FromArgb(14, 67, 128);
            salary_btn.Activecolor = Color.FromArgb(14, 67, 128);
            report_btn.Activecolor = Color.FromArgb(14, 67, 128);
            admin_btn.Activecolor = Color.FromArgb(14, 67, 128);

        }

        private void Dark_Click(object sender, EventArgs e)
        {
            theme = "dark";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Grey50, Primary.Grey800,
               Primary.Grey100, Accent.Amber100,
               TextShade.BLACK
           );


            theme_manager(); color_changer();
            color_scheme_error.BackColor = Color.White;
            mini_navbar.BackColor = Color.FromArgb(250, 250, 250);
            navbar.BackColor = Color.FromArgb(250, 250, 250);
            mini_navbar.GradientBottomLeft = Color.FromArgb(250, 250, 250);
            mini_navbar.GradientBottomRight = Color.FromArgb(250, 250, 250);
            mini_navbar.GradientTopRight = Color.FromArgb(250, 250, 250);
            mini_navbar.GradientTopLeft = Color.FromArgb(250, 250, 250);
            profile_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            emp_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            attendance_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            salary_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            report_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            admin_btn.Normalcolor = Color.FromArgb(66, 66, 66);
            profile_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            emp_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            attendance_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            salary_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            report_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            admin_btn.OnHovercolor = Color.FromArgb(129, 129, 129);
            profile_btn.Activecolor = Color.FromArgb(22, 22, 22);
            emp_btn.Activecolor = Color.FromArgb(22, 22, 22);
            attendance_btn.Activecolor = Color.FromArgb(22, 22, 22);
            salary_btn.Activecolor = Color.FromArgb(22, 22, 22);
            report_btn.Activecolor = Color.FromArgb(22, 22, 22);
            admin_btn.Activecolor = Color.FromArgb(22, 22, 22);
            boundary1.BackColor = Color.FromArgb(66, 66, 66);
            boundary2.BackColor = Color.FromArgb(66, 66, 66);
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            theme = "purple";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Purple50, Primary.Purple800,
               Primary.Purple100, Accent.Purple100,
               TextShade.BLACK
           );


            theme_manager(); color_changer();
            mini_navbar.BackColor = Color.FromArgb(243, 229, 245);
            navbar.BackColor = Color.FromArgb(243, 229, 245);
            mini_navbar.GradientBottomLeft = Color.FromArgb(243, 229, 245);
            mini_navbar.GradientBottomRight = Color.FromArgb(243, 229, 245);
            mini_navbar.GradientTopRight = Color.FromArgb(243, 229, 245);
            mini_navbar.GradientTopLeft = Color.FromArgb(243, 229, 245);
            profile_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            emp_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            attendance_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            salary_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            report_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            admin_btn.Normalcolor = Color.FromArgb(106, 27, 154);
            profile_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            emp_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            attendance_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            salary_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            report_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            admin_btn.OnHovercolor = Color.FromArgb(189, 111, 202);
            profile_btn.Activecolor = Color.FromArgb(35, 9, 51);
            emp_btn.Activecolor = Color.FromArgb(35, 9, 51);
            attendance_btn.Activecolor = Color.FromArgb(35, 9, 51);
            salary_btn.Activecolor = Color.FromArgb(35, 9, 51);
            report_btn.Activecolor = Color.FromArgb(35, 9, 51);
            admin_btn.Activecolor = Color.FromArgb(35, 9, 51);
            boundary1.BackColor = Color.FromArgb(106, 27, 154);
            boundary2.BackColor = Color.FromArgb(106, 27, 154);

        }

        private void DarkPurple_Click(object sender, EventArgs e)
        {
            theme = "darkpurple";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.DeepPurple50, Primary.DeepPurple800,
               Primary.DeepPurple100, Accent.DeepPurple100,
               TextShade.BLACK
           );


            mini_navbar.BackColor = Color.FromArgb(237, 231, 246);
            navbar.BackColor = Color.FromArgb(237, 231, 246);
            mini_navbar.GradientBottomLeft = Color.FromArgb(237, 231, 246);
            mini_navbar.GradientBottomRight = Color.FromArgb(237, 231, 246);
            mini_navbar.GradientTopRight = Color.FromArgb(237, 231, 246);
            mini_navbar.GradientTopLeft = Color.FromArgb(237, 231, 246);
            profile_btn.Normalcolor = Color.FromArgb(69, 39, 160);
            emp_btn.Normalcolor = Color.FromArgb(69, 39, 160);
            attendance_btn.Normalcolor = Color.FromArgb(69, 39, 160);
            salary_btn.Normalcolor = Color.FromArgb(69, 39, 160);
            report_btn.Normalcolor = Color.FromArgb(69, 39, 160);
            admin_btn.Normalcolor = Color.FromArgb(69, 39, 160);

            theme_manager(); color_changer();
            profile_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            emp_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            attendance_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            salary_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            report_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            admin_btn.OnHovercolor = Color.FromArgb(153, 123, 207);
            profile_btn.Activecolor = Color.FromArgb(23, 13, 53);
            emp_btn.Activecolor = Color.FromArgb(23, 13, 53);
            attendance_btn.Activecolor = Color.FromArgb(23, 13, 53);
            salary_btn.Activecolor = Color.FromArgb(23, 13, 53);
            report_btn.Activecolor = Color.FromArgb(23, 13, 53);
            admin_btn.Activecolor = Color.FromArgb(23, 13, 53);
            boundary1.BackColor = Color.FromArgb(69, 39, 160);
            boundary2.BackColor = Color.FromArgb(69, 39, 160);
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            theme = "orange";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Amber50, Primary.Amber800,
               Primary.Amber100, Accent.Amber100,
               TextShade.BLACK
           );


            mini_navbar.BackColor = Color.FromArgb(255, 248, 225);
            navbar.BackColor = Color.FromArgb(255, 248, 225);
            mini_navbar.GradientBottomLeft = Color.FromArgb(255, 248, 225);
            mini_navbar.GradientBottomRight = Color.FromArgb(255, 248, 225);
            mini_navbar.GradientTopRight = Color.FromArgb(255, 248, 225);
            mini_navbar.GradientTopLeft = Color.FromArgb(255, 248, 225);
            profile_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            emp_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            attendance_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            salary_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            report_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            admin_btn.Normalcolor = Color.FromArgb(255, 143, 0);
            theme_manager(); color_changer();
            profile_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            emp_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            attendance_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            salary_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            report_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            admin_btn.OnHovercolor = Color.FromArgb(255, 202, 40);
            profile_btn.Activecolor = Color.FromArgb(255, 50, 0);
            emp_btn.Activecolor = Color.FromArgb(255, 50, 0);
            attendance_btn.Activecolor = Color.FromArgb(255, 50, 0);
            salary_btn.Activecolor = Color.FromArgb(255, 50, 0);
            report_btn.Activecolor = Color.FromArgb(255, 50, 0);
            admin_btn.Activecolor = Color.FromArgb(255, 50, 0);
            boundary1.BackColor = Color.FromArgb(255, 143, 0);
            boundary2.BackColor = Color.FromArgb(255, 143, 0);
        }

        private void Cyan_Click(object sender, EventArgs e)
        {
            theme = "cyan";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Cyan50, Primary.Cyan800,
               Primary.Cyan100, Accent.Cyan100,
               TextShade.BLACK
           );


            theme_manager(); color_changer();
            mini_navbar.BackColor = Color.FromArgb(224, 247, 250);
            navbar.BackColor = Color.FromArgb(224, 247, 250);
            mini_navbar.GradientBottomLeft = Color.FromArgb(224, 247, 250);
            mini_navbar.GradientBottomRight = Color.FromArgb(224, 247, 250);
            mini_navbar.GradientTopRight = Color.FromArgb(224, 247, 250);
            mini_navbar.GradientTopLeft = Color.FromArgb(224, 247, 250);
            profile_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            emp_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            attendance_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            salary_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            report_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            admin_btn.Normalcolor = Color.FromArgb(0, 131, 143);
            profile_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            emp_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            attendance_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            salary_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            report_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            admin_btn.OnHovercolor = Color.FromArgb(85, 172, 180);
            profile_btn.Activecolor = Color.FromArgb(0, 43, 47);
            emp_btn.Activecolor = Color.FromArgb(0, 43, 47);
            attendance_btn.Activecolor = Color.FromArgb(0, 43, 47);
            salary_btn.Activecolor = Color.FromArgb(0, 43, 47);
            report_btn.Activecolor = Color.FromArgb(0, 43, 47);
            admin_btn.Activecolor = Color.FromArgb(0, 43, 47);
            boundary1.BackColor = Color.FromArgb(0, 131, 143);
            boundary2.BackColor = Color.FromArgb(0, 131, 143);
        }

        private void DarkBlue_Click(object sender, EventArgs e)
        {
            theme = "darkblue";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Indigo50, Primary.Indigo800,
               Primary.Indigo100, Accent.Indigo100,
               TextShade.BLACK
           );


            mini_navbar.BackColor = Color.FromArgb(232, 234, 246);
            navbar.BackColor = Color.FromArgb(232, 234, 246);
            mini_navbar.GradientBottomLeft = Color.FromArgb(232, 234, 246);
            mini_navbar.GradientBottomRight = Color.FromArgb(232, 234, 246);
            mini_navbar.GradientTopRight = Color.FromArgb(232, 234, 246);
            mini_navbar.GradientTopLeft = Color.FromArgb(232, 234, 246);
            profile_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            emp_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            attendance_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            salary_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            report_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            admin_btn.Normalcolor = Color.FromArgb(40, 53, 147);
            theme_manager(); color_changer();
            profile_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            emp_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            attendance_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            salary_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            report_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            admin_btn.OnHovercolor = Color.FromArgb(127, 139, 205);
            profile_btn.Activecolor = Color.FromArgb(13, 17, 49);
            emp_btn.Activecolor = Color.FromArgb(13, 17, 49);
            attendance_btn.Activecolor = Color.FromArgb(13, 17, 49);
            salary_btn.Activecolor = Color.FromArgb(13, 17, 49);
            report_btn.Activecolor = Color.FromArgb(13, 17, 49);
            admin_btn.Activecolor = Color.FromArgb(13, 17, 49);
            boundary1.BackColor = Color.FromArgb(40, 53, 147);
            boundary2.BackColor = Color.FromArgb(40, 53, 147);
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            theme = "pink";
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Pink50, Primary.Pink800,
               Primary.Pink100, Accent.Pink100,
               TextShade.BLACK
           );
            theme_manager();
            color_changer();

            mini_navbar.BackColor = Color.FromArgb(252, 228, 236);
            navbar.BackColor = Color.FromArgb(252, 228, 236);
            mini_navbar.GradientBottomLeft = Color.FromArgb(252, 228, 236);
            mini_navbar.GradientBottomRight = Color.FromArgb(252, 228, 236);
            mini_navbar.GradientTopRight = Color.FromArgb(252, 228, 236);
            mini_navbar.GradientTopLeft = Color.FromArgb(252, 228, 236);
            profile_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            emp_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            attendance_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            salary_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            report_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            admin_btn.Normalcolor = Color.FromArgb(173, 20, 87);
            profile_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            emp_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            attendance_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            salary_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            report_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            admin_btn.OnHovercolor = Color.FromArgb(240, 105, 151);
            profile_btn.Activecolor = Color.FromArgb(57, 6, 29);
            emp_btn.Activecolor = Color.FromArgb(57, 6, 29);
            attendance_btn.Activecolor = Color.FromArgb(57, 6, 29);
            salary_btn.Activecolor = Color.FromArgb(57, 6, 29);
            report_btn.Activecolor = Color.FromArgb(57, 6, 29);
            admin_btn.Activecolor = Color.FromArgb(57, 6, 29);
            boundary1.BackColor = Color.FromArgb(173, 20, 87);
            boundary2.BackColor = Color.FromArgb(173, 20, 87);
        }

        private void navCollapsebtn_Click(object sender, EventArgs e)
        {
            navbar.Visible = true;
            mini_navbar.Visible = false;
        }

        private void collapseNavbar_btn_Click(object sender, EventArgs e)
        {
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void emp_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = emp_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = profile_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void attendance_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = atten_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void salary_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = salary_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void report_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = report_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void admin_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = admin_main_screen;
            navbar.Visible = false;
            mini_navbar.Visible = true;
        }

        private void browse_image_btn_Click(object sender, EventArgs e)
        {
            if (Imagepicker.ShowDialog() == DialogResult.OK)
            {
                image_emp.Image = Image.FromFile(Imagepicker.FileName);
            }
        }

        string theme = "red";
        private void admin_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = admin_main_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;
            if (theme == "light")
            {
                admin_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                admin_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                admin_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                admin_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                admin_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                admin_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                admin_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                admin_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                admin_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                admin_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                admin_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                admin_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }

        }

        private void report_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = report_main_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;

            if (theme == "light")
            {
                report_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                report_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                report_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                report_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                report_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                report_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                report_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                report_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                report_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                report_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                report_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                report_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }


        }

        private void salary_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = salary_main_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;

            admin_nav_btn.BackColor = Color.Transparent;

            if (theme == "light")
            {
                salary_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                salary_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                salary_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                salary_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                salary_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                salary_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                salary_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                salary_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                salary_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                salary_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                salary_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                salary_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }



        }

        private void atten_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = atten_main_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;

            if (theme == "light")
            {
                atten_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                atten_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                atten_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                atten_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                atten_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                atten_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                atten_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                atten_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                atten_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                atten_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                atten_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                atten_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }

        }

        private void emp_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = emp_main_screen;
            emp_mini_screen.SelectedTab = select_emp_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;

            if (theme == "light")
            {
                emp_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                emp_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                emp_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                emp_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                emp_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                emp_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                emp_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                emp_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                emp_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                emp_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                emp_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                emp_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }


        }

        private void profile_nav_btn_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = profile_main_screen;
            profile_nav_btn.BackColor = Color.Transparent;
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            report_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;

            if (theme == "light")
            {
                profile_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            }
            else if (theme == "dark")
            {
                profile_nav_btn.BackColor = Color.FromArgb(66, 66, 66);
            }
            else if (theme == "pink")
            {
                profile_nav_btn.BackColor = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {
                profile_nav_btn.BackColor = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                profile_nav_btn.BackColor = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                profile_nav_btn.BackColor = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                profile_nav_btn.BackColor = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                profile_nav_btn.BackColor = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                profile_nav_btn.BackColor = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                profile_nav_btn.BackColor = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                profile_nav_btn.BackColor = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                profile_nav_btn.BackColor = Color.FromArgb(46, 125, 50);
            }

        }

        private void update_emp_data_Click(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(select_emp_for_update.CurrentRow.Cells[0].Value.ToString());
            emp_mini_screen.SelectedTab = update_emp_screen;
            USER emp_data = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();
            update_firstname_txt.Text = emp_data.FIRST_NAME;

            byte[] image = emp_data.IMAGE;
            MemoryStream stream = new MemoryStream(image);

            string lang_data = emp_data.LANGUAGE.ToString();

            string[] lang_list = lang_data.Split(',');
            for (int i = 0; i < lang_list.Length; i++)
            {
                lang_list[i] = lang_list[i].Trim();
            }
            for (int i = 0; i < update_languages.Items.Count; i++)
            {
                update_languages.SetItemChecked(i, false);
                for (int j = 0; j < lang_list.Length; j++)
                {
                    if (update_languages.Items[i].ToString() == lang_list[j].ToString())
                    {
                        update_languages.SetItemChecked(i, true);
                    }
                }
            }

            update_image_emp.Image = Image.FromStream(stream);
            update_lastname_txt.Text = emp_data.LAST_NAME;
            update_jobtitle_combo.Text = emp_data.JOB_TITLE;
            update_email_txt.Text = emp_data.EMAIL;
            update_phone_txt.Text = emp_data.CONTACT_PHONE;
            update_address_txt.Text = emp_data.CONTACT_ADDRESS;
            update_facebook_txt.Text = emp_data.SOCIAL_FACEBOOK;
            update_description_txt.Text = emp_data.DESCRIPTION;
            update_skype_txt.Text = emp_data.SOCIAL_TWITTER;
            update_linkedin_txt.Text = emp_data.SOCIAL_LINKEDIN;
            update_twitter_txt.Text = emp_data.SOCIAL_TWITTER;
            update_experience_txt.Text = emp_data.EXPERIENCE;
            update_education_txt.Text = emp_data.EDUCATION;

        }

        private void browse_emp_image_update_Click(object sender, EventArgs e)
        {
            if (Imagepicker.ShowDialog() == DialogResult.OK)
            {
                update_image_emp.Image = Image.FromFile(Imagepicker.FileName);
            }
        }
        private void profile_emp_load()
        {
            try
            {
                int emp_id = 1;
                emp_mini_screen.SelectedTab = detail_emp_screen;

                USER login = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();
                byte[] image = (byte[])login.IMAGE;
                MemoryStream stream = new MemoryStream(image);
                userImage2.Image = Image.FromStream(stream);
                user_username.Text = login.FIRST_NAME + "\n" + login.LAST_NAME;
                user_job.Text = login.JOB_TITLE;
                user_about.Text = login.DESCRIPTION;
                user_phone.Text = login.CONTACT_PHONE;
                user_email.Text = login.CONTACT_EMAIL;
                user_address.Text = login.CONTACT_ADDRESS;
                if (login.SOCIAL_FACEBOOK == null)
                {
                    user_fb_panel.Visible = false;
                }
                else
                {
                    user_fb_panel.Visible = true;
                    user_facebook.Text = login.SOCIAL_FACEBOOK;
                }
                if (login.SOCIAL_TWITTER == null)
                {
                    user_tw_panel.Visible = false;
                }
                else
                {
                    user_tw_panel.Visible = true;
                    user_twitter.Text = login.SOCIAL_TWITTER;

                }
                if (login.SOCIAL_LINKEDIN == null)
                {
                    user_ln_panel.Visible = false;
                }
                else
                {
                    user_ln_panel.Visible = true;
                    user_linkedIN.Text = login.SOCIAL_LINKEDIN;

                }
                if (login.SOCIAL_FACEBOOK == null && login.SOCIAL_TWITTER == null && login.SOCIAL_LINKEDIN == null)
                {
                    user_social_panel.Visible = false;
                }
                else
                {
                    user_social_panel.Visible = true;
                }
                user_description.Text = login.EXPERIENCE;
                user_education.Text = login.EDUCATION;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }
        private void profile_emp_load_click()
        {
            int emp_id = Convert.ToInt32(select_emp_for_update.CurrentRow.Cells[0].Value.ToString());
            emp_mini_screen.SelectedTab = detail_emp_screen;

            USER login = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();
            byte[] image = (byte[])login.IMAGE;
            MemoryStream stream = new MemoryStream(image);
            userImage2.Image = Image.FromStream(stream);
            user_username.Text = login.FIRST_NAME + "\n" + login.LAST_NAME;
            user_job.Text = login.JOB_TITLE;
            user_about.Text = login.DESCRIPTION;
            user_phone.Text = login.CONTACT_PHONE;
            user_email.Text = login.CONTACT_EMAIL;
            user_address.Text = login.CONTACT_ADDRESS;
            if (login.SOCIAL_FACEBOOK == null)
            {
                user_fb_panel.Visible = false;
            }
            else
            {
                user_fb_panel.Visible = true;
                user_facebook.Text = login.SOCIAL_FACEBOOK;
            }
            if (login.SOCIAL_TWITTER == null)
            {
                user_tw_panel.Visible = false;
            }
            else
            {
                user_tw_panel.Visible = true;
                user_twitter.Text = login.SOCIAL_TWITTER;

            }
            if (login.SOCIAL_LINKEDIN == null)
            {
                user_ln_panel.Visible = false;
            }
            else
            {
                user_ln_panel.Visible = true;
                user_linkedIN.Text = login.SOCIAL_LINKEDIN;

            }
            if (login.SOCIAL_FACEBOOK == null && login.SOCIAL_TWITTER == null && login.SOCIAL_LINKEDIN == null)
            {
                user_social_panel.Visible = false;
            }
            else
            {
                user_social_panel.Visible = true;
            }
            user_description.Text = login.EXPERIENCE;
            user_education.Text = login.EDUCATION;
            languages_txt.Text = login.LANGUAGE;

        }

        private void clear_emp_data()
        {
            image_emp.Image = null;
            firstname_txt.Text = "";
            lastname_txt.Text = "";
            email_txt.Text = "";
            phone_txt.Text = "";
            address_txt.Text = "";
            facebook_txt.Text = "";
            twitter_txt.Text = "";
            skype_txt.Text = "";
            linkedin_txt.Text = "";
            description_txt.Text = "";
            if (languages_select.CheckedItems.Count > 0)
            {
                for (int i = 0; i < languages_select.CheckedItems.Count; i++)
                {
                    languages_select.SetItemChecked(i, false);
                }
            }
            education_txt.Text = "";
            experience_txt.Text = "";
            update_image_emp.Text = "";
            update_firstname_txt.Text = "";
            update_lastname_txt.Text = "";
            update_description_txt.Text = "";
            update_email_txt.Text = "";
            update_phone_txt.Text = "";
            update_address_txt.Text = "";
            update_facebook_txt.Text = "";
            update_twitter_txt.Text = "";
            update_skype_txt.Text = "";
            update_linkedin_txt.Text = "";
            update_education_txt.Text = "";
            update_experience_txt.Text = "";
            if (update_languages.CheckedItems.Count > 0)
            {
                for (int i = 0; i < update_languages.CheckedItems.Count; i++)
                {
                    update_languages.SetItemChecked(i, false);
                }
            }
        }


        private void detail_btn_Click(object sender, EventArgs e)
        {
            profile_emp_load_click();
            emp_mini_screen.SelectedTab = detail_emp_screen;
        }

        private void update_emp_btn_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (update_firstname_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the first name of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_lastname_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the last name of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_jobtitle_combo.Text == "")
            {
                alert = new AlertMessages("Please select any one job title !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (update_email_txt.Text == "")
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (!rEmail.IsMatch(update_email_txt.Text.Trim()))
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (update_phone_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the phone number of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_address_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the address of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_description_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the description of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {




                emp_mini_screen.SelectedTab = update_mode_data;
            }
        }


        private void Update_more_data_btn_Click(object sender, EventArgs e)
        {
            if (update_education_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the details of education of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_experience_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the details of experience of employee !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            int emp_id = Convert.ToInt32(select_emp_for_update.CurrentRow.Cells[0].Value.ToString());
            USER emp_data = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();

            string lang_data = "";
            if (update_languages.CheckedItems.Count > 0)
            {
                for (int i = 0; i < update_languages.CheckedItems.Count; i++)
                {
                    if (lang_data == "")
                    {
                        lang_data += update_languages.CheckedItems[i].ToString();
                    }
                    else
                    {
                        lang_data += ", " + update_languages.CheckedItems[i].ToString();

                    }

                }

            }
            else
            {
                alert = new AlertMessages("Please check out atleast one language !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }



            emp_data.FIRST_NAME = update_firstname_txt.Text;
            emp_data.LAST_NAME = update_lastname_txt.Text;
            emp_data.JOB_TITLE = update_jobtitle_combo.Text;
            emp_data.EMAIL = update_email_txt.Text;
            emp_data.DESCRIPTION = update_description_txt.Text;
            emp_data.CONTACT_PHONE = update_phone_txt.Text;
            emp_data.CONTACT_EMAIL = update_email_txt.Text;
            emp_data.CONTACT_ADDRESS = update_address_txt.Text;
            emp_data.SOCIAL_FACEBOOK = update_facebook_txt.Text;
            emp_data.SOCIAL_TWITTER = update_twitter_txt.Text;
            emp_data.SOCIAL_LINKEDIN = update_linkedin_txt.Text;
            emp_data.EDUCATION = update_education_txt.Text;
            emp_data.EXPERIENCE = update_experience_txt.Text;
            emp_data.LANGUAGE = lang_data;



            MemoryStream stream = new MemoryStream();
            update_image_emp.Image.Save(stream, update_image_emp.Image.RawFormat);
            byte[] byteImage = stream.GetBuffer();

            emp_data.IMAGE = byteImage;

            data.SaveChanges();
            data_fetch();

            emp_mini_screen.SelectedTab = select_emp_screen;
            clear_emp_data();

            mini_navbar.Enabled = true;
            navbar.Enabled = true;
            alert = new AlertMessages("Employee Data Updated !!", AlertMessages.alertType.success);
            alert.BringToFront();
            alert.Show();
        }

        private void check_all_btn_Click(object sender, EventArgs e)
        {
            if (check.Checked == true)
            {
                for (int i = 0; i < attendance_list.Items.Count; i++)
                {
                    attendance_list.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < attendance_list.Items.Count; i++)
                {
                    attendance_list.SetItemChecked(i, false);
                }
            }



        }

        private void attendance_list_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        private void user_atten_txt_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        private void update_attendance_btn_Click(object sender, EventArgs e)
        {
            //int atten_id = Convert.ToInt32(select_emp_for_attendance.CurrentRow.Cells[0].Value.ToString());
            //ATTENDANCE atten_data = data.ATTENDANCEs.Where(find => find.ID == atten_id).FirstOrDefault();

            //if (update_time.Checked == true)
            //{
            //    atten_data.USER_NAME = Convert.ToInt32(atten_username_txt.SelectedValue.ToString());
            //    atten_data.DATETIME_NOW = DateTime.Now;
            //}
            //else
            //{
            //    atten_data.USER_NAME = Convert.ToInt32(atten_username_txt.SelectedValue.ToString());
            //}
            //alert = new AlertMessages("Attendance Updated !!", AlertMessages.alertType.success);
            //alert.BringToFront();

            //alert.Show();
            //attendance_mini_screen.SelectedTab = update_atten_screen;

        }

        private void atten_username_txt_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        private void update_salary_btn_Click(object sender, EventArgs e)
        {
            salary_mini_screen.SelectedTab = update_salary_screen;
            int salary_id = Convert.ToInt32(select_emp_for_salary.CurrentRow.Cells[0].Value.ToString());
            SALARY salary_data = data.SALARIEs.Where(find => find.ID == salary_id).FirstOrDefault();


            update_username_salary_txt.SelectedValue = salary_data.USER_NAME;
            update_from_salary_txt.Value = salary_data.FROM_DATE;
            update_to_salary_txt.Value = salary_data.TO_DATE;
            string rate;
            double salary = salary_data.USER_SALARY;
            DateTime startdate = salary_data.FROM_DATE;
            DateTime enddate = salary_data.TO_DATE;

            TimeSpan workingHours = enddate - startdate;

            rate = (salary / (workingHours.Days + 1)).ToString();

            update_rate_salary_txt.Text = rate;
            update_salary_txt.Text = salary.ToString();
        }

        private void emp_salary_combo_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        private void save_salary_btn_Click(object sender, EventArgs e)
        {

            if (rate_txt.Text == "")
            {
                alert = new AlertMessages("Please insert the rate of salary !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {

                SALARY salary_data = new SALARY()
                {
                    USER_NAME = Convert.ToInt32(emp_salary_combo.SelectedValue.ToString()),
                    FROM_DATE = from_salary_date.Value,
                    TO_DATE = to_salary_date.Value,
                    USER_SALARY = Convert.ToDouble(salary.Text)
                };
                data.SALARIEs.Add(salary_data);
                data.SaveChanges();

                data_fetch();
                salary_mini_screen.SelectedTab = select_salary_screen;
                alert = new AlertMessages("Salary Added !!", AlertMessages.alertType.success);
                alert.BringToFront();

                alert.Show();
            }
        }

        private void rate_txt_TextChanged(object sender, EventArgs e)
        {
            if (rate_txt.Text == "")
            {
                DateTime startDate = from_salary_date.Value.Date;
                DateTime endDate = to_salary_date.Value.Date;

                TimeSpan workingHours = endDate - startDate;
                try
                {
                    int rate = 0;
                    salary.Text = (workingHours.Days * rate).ToString();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                DateTime startDate = from_salary_date.Value.Date;
                DateTime endDate = to_salary_date.Value.Date;

                TimeSpan workingHours = endDate - startDate;
                try
                {
                    int rate = Convert.ToInt32(rate_txt.Text);
                    salary.Text = (workingHours.Days * rate).ToString();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }





        }

        private void update_rate_salary_txt_TextChanged(object sender, EventArgs e)
        {

            if (rate_txt.Text == "")
            {

                DateTime startDate = update_from_salary_txt.Value.Date;
                DateTime endDate = update_to_salary_txt.Value.Date;

                TimeSpan workingHours = endDate - startDate;
                try
                {
                    int rate = 0;
                    salary.Text = (workingHours.Days * rate).ToString();
                    update_salary_txt.Text = (workingHours.Days * rate).ToString();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }


            }
            else
            {

                DateTime startDate = update_from_salary_txt.Value.Date;
                DateTime endDate = update_to_salary_txt.Value.Date;

                TimeSpan workingHours = endDate - startDate;
                try
                {
                    int rate = Convert.ToInt32(update_rate_salary_txt.Text);
                    salary.Text = (workingHours.Days * rate).ToString();
                    update_salary_txt.Text = (workingHours.Days * rate).ToString();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }


            }


        }

        private void update_salary_button_Click(object sender, EventArgs e)
        {
            int salary_id = Convert.ToInt32(select_emp_for_salary.CurrentRow.Cells[0].Value.ToString());
            SALARY atten_data = data.SALARIEs.Where(find => find.ID == salary_id).FirstOrDefault();


            atten_data.USER_NAME = Convert.ToInt32(update_username_salary_txt.SelectedValue.ToString());
            atten_data.FROM_DATE = update_from_salary_txt.Value;
            atten_data.TO_DATE = update_to_salary_txt.Value;
            atten_data.USER_SALARY = Convert.ToDouble(update_salary_txt.Text);


            data_fetch();
            salary_mini_screen.SelectedTab = select_salary_screen;
            alert = new AlertMessages("Salary Updated !!", AlertMessages.alertType.success);
            alert.BringToFront();

            alert.Show();

        }

        private void update_username_salary_txt_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        DialogResult Dialog = new DialogResult();
        private void close_btn_Click(object sender, EventArgs e)
        {
            Dialog = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to logout ? ", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (Dialog == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                return;
            }
        }

        private void profile_nav_btn_Click_1(object sender, EventArgs e)
        {
            profile_nav_btn.BackColor = Color.FromArgb(21, 101, 192);
            emp_nav_btn.BackColor = Color.Transparent;
            atten_nav_btn.BackColor = Color.Transparent;
            salary_nav_btn.BackColor = Color.Transparent;
            admin_nav_btn.BackColor = Color.Transparent;
        }

        private void add_users_btn_Click(object sender, EventArgs e)
        {


            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");


            if (user_image.Image == null)
            {
                alert = new AlertMessages("Please insert the picture of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_first_name_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the first name of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_last_name_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the last name of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_job_txt.Text == "")
            {
                alert = new AlertMessages("Please select any job title !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_email_txt.Text == "")
            {
                alert = new AlertMessages("Please insert the email of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();

            }
            else if (!rEmail.IsMatch(user_email_txt.Text.Trim()))
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }


            else if (user_username_txt.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_password_txt.Text != user_confirm_password_txt.Text)
            {
                alert = new AlertMessages("Passwords you entered doesnot matched !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_phone_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the correct phone number !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_address_txt.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_security_question_txt.Text == "")
            {
                alert = new AlertMessages("Please select any one question !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (user_security_answer_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the answer of selected question !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (user_description_txt.Text == "")
            {
                alert = new AlertMessages("Please enter the description of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {
                admin_mini_screen.SelectedTab = user_more_screen;

            }



        }


        private void add_more_user_btn(object sender, EventArgs e)
        {

            if (user_languages.CheckedItems.Count == 0)
            {
                alert = new AlertMessages("Please check out aleast one language !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {

                string lang_data = "";


                if (user_education_txt.Text == "")
                {
                    alert = new AlertMessages("Please enter the details of education of user !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }
                else if (user_experience_txt.Text == "")
                {
                    alert = new AlertMessages("Please enter the details of experience of user !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }

                else if (user_languages.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < user_languages.CheckedItems.Count; i++)
                    {
                        if (lang_data == "")
                        {
                            lang_data += user_languages.CheckedItems[i].ToString();

                        }
                        else
                        {
                            lang_data += ", " + user_languages.CheckedItems[i].ToString();

                        }

                    }

                    if (user_image.Image != null)
                    {

                        MemoryStream stream = new MemoryStream();
                        user_image.Image.Save(stream, user_image.Image.RawFormat);
                        byte[] image = stream.GetBuffer();

                        string password;

                        if (user_password_txt.Text == user_confirm_password_txt.Text)
                        {
                            password = user_password_txt.Text;
                            USER add_user = new USER()
                            {
                                IMAGE = image,
                                FIRST_NAME = user_first_name_txt.Text,
                                LAST_NAME = user_last_name_txt.Text,
                                JOB_TITLE = user_job_txt.Text,
                                DESCRIPTION = user_description_txt.Text,
                                EMAIL = user_email_txt.Text,
                                CONTACT_EMAIL = user_email_txt.Text,
                                USERNAME = user_username_txt.Text,
                                PASSWORD = password,
                                CONTACT_PHONE = user_phone_txt.Text,
                                CONTACT_ADDRESS = user_address_txt.Text,
                                SOCIAL_FACEBOOK = user_facebook_txt.Text,
                                SOCIAL_TWITTER = user_twitter_txt.Text,
                                SOCIAL_LINKEDIN = user_linked_txt.Text,
                                SECURITY_QUESTION = user_security_question_txt.Text,
                                SECURITY_ANSWER = user_security_answer_txt.Text,
                                ROLE = "user",
                                EDUCATION = user_education_txt.Text,
                                EXPERIENCE = user_experience_txt.Text,
                                LANGUAGE = lang_data


                            };
                            data.USERs.Add(add_user);
                            data.SaveChanges();
                            alert = new AlertMessages("User Added !!", AlertMessages.alertType.success);
                            alert.BringToFront();
                            alert.Show();
                            numbers_fetching();
                            data_fetch();
                            admin_mini_screen.SelectedTab = admin_main;
                        }
                        else
                        {
                            alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                            alert.BringToFront();

                            alert.Show();
                        }



                    }
                    else
                    {
                        alert = new AlertMessages("Please check out aleast one language !!", AlertMessages.alertType.error);
                        alert.BringToFront();

                        alert.Show();
                    }

                }



            }
        }

        private void browse_image_button_Click(object sender, EventArgs e)
        {
            if (Imagepicker.ShowDialog() == DialogResult.OK)
            {
                user_image.Image = Image.FromFile(Imagepicker.FileName);
            }
        }

        private void admin_nav_btn_MouseEnter(object sender, EventArgs e)
        {
        }

        private void edit_profile_Click(object sender, EventArgs e)
        {
            the_screen.SelectedTab = edit_profile_tab;
        }

        private void edit_profile_MouseEnter(object sender, EventArgs e)
        {
            if (theme == "dark")
            {
                edit_profile.ForeColor = Color.White;

            }
            else
            {
                edit_profile.ForeColor = Color.Black;

            }
        }

        private void edit_profile_MouseLeave(object sender, EventArgs e)
        {
            edit_profile.ForeColor = Color.Gray;
            update_profile_load();
        }

        private void edit_profile_btn_Click(object sender, EventArgs e)
        {

            if (edit_profile_first_name.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_last_name.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_image.Image == null)
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_job_title.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_description.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_email.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_username.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_phone.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (edit_profile_address.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {

                the_screen.SelectedTab = edit_more_profile;



            }
        }

        private void update_profile_load()
        {
            int emp_id = Login.user_id;
            USER emp_data = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();
            edit_profile_first_name.Text = emp_data.FIRST_NAME;
            byte[] image = emp_data.IMAGE;
            MemoryStream stream = new MemoryStream(image);


            string lang_data = emp_data.LANGUAGE.ToString();

            string[] lang_list = lang_data.Split(',');
            for (int i = 0; i < lang_list.Length; i++)
            {
                lang_list[i] = lang_list[i].Trim();
            }
            for (int i = 0; i < update_profile_lang.Items.Count; i++)
            {
                update_profile_lang.SetItemChecked(i, false);
                for (int j = 0; j < lang_list.Length; j++)
                {
                    if (update_profile_lang.Items[i].ToString() == lang_list[j].ToString())
                    {
                        update_profile_lang.SetItemChecked(i, true);
                    }
                }
            }


            edit_profile_image.Image = Image.FromStream(stream);
            edit_profile_last_name.Text = emp_data.LAST_NAME;
            edit_profile_job_title.Text = emp_data.JOB_TITLE;
            edit_profile_email.Text = emp_data.EMAIL;
            edit_profile_username.Text = emp_data.USERNAME;
            edit_profile_password.Text = emp_data.PASSWORD;
            edit_profile_confirm_password.Text = emp_data.PASSWORD;
            edit_profile_phone.Text = emp_data.CONTACT_PHONE;
            edit_profile_address.Text = emp_data.CONTACT_ADDRESS;
            edit_profile_facebook.Text = emp_data.SOCIAL_FACEBOOK;
            edit_profile_description.Text = emp_data.DESCRIPTION;
            edit_profile_twitter.Text = emp_data.SOCIAL_TWITTER;
            edit_profile_linked.Text = emp_data.SOCIAL_LINKEDIN;
            update_profile_edu.Text = emp_data.EDUCATION;
            update_profile_exp.Text = emp_data.EXPERIENCE;
        }

        private void browse_img_edit_profile_Click(object sender, EventArgs e)
        {
            if (Imagepicker.ShowDialog() == DialogResult.OK)
            {
                edit_profile_image.Image = Image.FromFile(Imagepicker.FileName);
            }
        }

        private void change_password_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.ShowDialog();
        }

        private void mark_atten_btn_Click(object sender, EventArgs e)
        {
            if (attendance_list.CheckedItems.Count > 0)
            {
                List<string> empData = new List<string>();

                for (int i = 0; i < attendance_list.CheckedItems.Count; i++)
                {
                    int userId = attendance_list.CheckedIndices[i] + 1;
                    ATTENDANCE attenData = new ATTENDANCE()
                    {
                        USER_NAME = userId,
                        DATETIME_NOW = date_for_attendance.Value

                    };
                    data.ATTENDANCEs.Add(attenData);
                    data.SaveChanges();
                }

                attendance_mini_screen.SelectedTab = select_atten_screen;
                data_fetch();

                for (int i = 0; i < attendance_list.Items.Count; i++)
                {
                    attendance_list.SetItemChecked(i, false);
                }
                alert = new AlertMessages("Attendance marked !!", AlertMessages.alertType.success);
                alert.BringToFront();

                alert.Show();
                //foreach (var itemChecked in attendance_list.CheckedItems)
                //{

                //    int userId = attendance_list.SelectedIndex + 1;
                //    ATTENDANCE attenData = new ATTENDANCE()
                //    {
                //        USER_NAME = userId,
                //        DATETIME_NOW = date_for_attendance.Value

                //    };
                //    data.ATTENDANCEs.Add(attenData);
                //    data.SaveChanges();
                //}
                //alert = new AlertMessages("Attendance marked !!", AlertMessages.alertType.success);
                //alert.BringToFront();

                //alert.Show();
                //attendance_mini_screen.SelectedTab = select_atten_screen;
                //data_fetch();

                //for (int i = 0; i < attendance_list.Items.Count; i++)
                //{
                //    attendance_list.SetItemChecked(i, false);
                //}
            }
            else
            {
                alert = new AlertMessages("Please check out atleast one employee or user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
        }

        private void report_selecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_selecter.Text == "Attendance")
            {

                Attendance attenReport = new Attendance();
                attenReport.SetDatabaseLogon("sa", "jazz123");
                report_viewer.ReportSource = attenReport;


            }
            else if (report_selecter.Text == "Employees")
            {
                Employees empReport = new Employees();
                empReport.SetDatabaseLogon("sa", "jazz123");
                report_viewer.ReportSource = empReport;

            }

            else if (report_selecter.Text == "Salaries")
            {
                Salary salReport = new Salary();
                salReport.SetDatabaseLogon("sa", "jazz123");
                report_viewer.ReportSource = salReport;
            }
        }

        private void emp_mini_screen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (emp_mini_screen.SelectedIndex == 4)
            //{
            //    hiding_emp.Visible = false;

            //}
            //else
            //{
            //    hiding_emp.Visible = true;
            //}
        }

        private void admin_show1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void color_changer()
        {
            if (theme == "light")
            {
                category.ForeColor = Color.Black;
                white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;

                admin_show1.GradientBottomLeft = Color.FromArgb(21, 101, 192);
                admin_show1.GradientTopLeft = Color.FromArgb(21, 101, 192);
                admin_show1.GradientTopRight = Color.FromArgb(21, 101, 192);
                admin_show2.GradientBottomLeft = Color.FromArgb(21, 101, 192);
                admin_show2.GradientTopLeft = Color.FromArgb(21, 101, 192);
                admin_show2.GradientTopRight = Color.FromArgb(21, 101, 192);
                admin_show3.GradientBottomLeft = Color.FromArgb(21, 101, 192);
                admin_show3.GradientTopLeft = Color.FromArgb(21, 101, 192);
                admin_show3.GradientTopRight = Color.FromArgb(21, 101, 192);
                salary_details.GradientBottomLeft = Color.FromArgb(21, 101, 192);
                salary_details.GradientTopLeft = Color.FromArgb(21, 101, 192);
                salary_details.GradientTopRight = Color.FromArgb(21, 101, 192);

                atten_details.GradientBottomLeft = Color.FromArgb(21, 101, 192);
                atten_details.GradientTopLeft = Color.FromArgb(21, 101, 192);
                atten_details.GradientTopRight = Color.FromArgb(21, 101, 192);

            }
            else if (theme == "dark")
            {
                admin_show1.GradientBottomLeft = Color.FromArgb(161, 161, 161);
                admin_show1.GradientTopLeft = Color.FromArgb(161, 161, 161);
                admin_show1.GradientTopRight = Color.FromArgb(161, 161, 161);
                admin_show2.GradientBottomLeft = Color.FromArgb(161, 161, 161);
                admin_show2.GradientTopLeft = Color.FromArgb(161, 161, 161);
                admin_show2.GradientTopRight = Color.FromArgb(161, 161, 161);
                admin_show3.GradientBottomLeft = Color.FromArgb(161, 161, 161);
                admin_show3.GradientTopLeft = Color.FromArgb(161, 161, 161);
                admin_show3.GradientTopRight = Color.FromArgb(161, 161, 161);
                salary_details.GradientBottomLeft = Color.FromArgb(161, 161, 161);
                salary_details.GradientTopLeft = Color.FromArgb(161, 161, 161);
                salary_details.GradientTopRight = Color.FromArgb(161, 161, 161);

                atten_details.GradientBottomLeft = Color.FromArgb(161, 161, 161);
                atten_details.GradientTopLeft = Color.FromArgb(161, 161, 161);
                atten_details.GradientTopRight = Color.FromArgb(161, 161, 161);
                category.ForeColor = Color.White;
                white_1.ForeColor = Color.White;
                white_2.ForeColor = Color.White;
                education_label.ForeColor = Color.White;
                experience_label.ForeColor = Color.White;
            }
            else if (theme == "pink")
            {
                category.ForeColor = Color.Black;
                white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientBottomLeft = Color.FromArgb(173, 20, 87);
                admin_show1.GradientTopLeft = Color.FromArgb(173, 20, 87);
                admin_show1.GradientTopRight = Color.FromArgb(173, 20, 87);
                admin_show2.GradientBottomLeft = Color.FromArgb(173, 20, 87);
                admin_show2.GradientTopLeft = Color.FromArgb(173, 20, 87);
                admin_show2.GradientTopRight = Color.FromArgb(173, 20, 87);
                admin_show3.GradientBottomLeft = Color.FromArgb(173, 20, 87);
                admin_show3.GradientTopLeft = Color.FromArgb(173, 20, 87);
                admin_show3.GradientTopRight = Color.FromArgb(173, 20, 87);
                salary_details.GradientBottomLeft = Color.FromArgb(173, 20, 87);
                salary_details.GradientTopLeft = Color.FromArgb(173, 20, 87);
                salary_details.GradientTopRight = Color.FromArgb(173, 20, 87);

                atten_details.GradientBottomLeft = Color.FromArgb(173, 20, 87);
                atten_details.GradientTopLeft = Color.FromArgb(173, 20, 87);
                atten_details.GradientTopRight = Color.FromArgb(173, 20, 87);
            }
            else if (theme == "darkblue")
            {

                category.ForeColor = Color.Black;
                white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black; admin_show1.GradientBottomLeft = Color.FromArgb(40, 53, 147);
                admin_show1.GradientTopLeft = Color.FromArgb(40, 53, 147);
                admin_show1.GradientTopRight = Color.FromArgb(40, 53, 147);
                admin_show2.GradientBottomLeft = Color.FromArgb(40, 53, 147);
                admin_show2.GradientTopLeft = Color.FromArgb(40, 53, 147);
                admin_show2.GradientTopRight = Color.FromArgb(40, 53, 147);
                admin_show3.GradientBottomLeft = Color.FromArgb(40, 53, 147);
                admin_show3.GradientTopLeft = Color.FromArgb(40, 53, 147);
                admin_show3.GradientTopRight = Color.FromArgb(40, 53, 147);
                salary_details.GradientBottomLeft = Color.FromArgb(40, 53, 147);
                salary_details.GradientTopLeft = Color.FromArgb(40, 53, 147);
                salary_details.GradientTopRight = Color.FromArgb(40, 53, 147);

                atten_details.GradientBottomLeft = Color.FromArgb(40, 53, 147);
                atten_details.GradientTopLeft = Color.FromArgb(40, 53, 147);
                atten_details.GradientTopRight = Color.FromArgb(40, 53, 147);
            }
            else if (theme == "cyan")
            {
                admin_show1.GradientBottomLeft = Color.FromArgb(0, 131, 143);
                admin_show1.GradientTopLeft = Color.FromArgb(0, 131, 143);
                admin_show1.GradientTopRight = Color.FromArgb(0, 131, 143);
                admin_show2.GradientBottomLeft = Color.FromArgb(0, 131, 143);
                admin_show2.GradientTopLeft = Color.FromArgb(0, 131, 143);
                admin_show2.GradientTopRight = Color.FromArgb(0, 131, 143);
                admin_show3.GradientBottomLeft = Color.FromArgb(0, 131, 143);
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show3.GradientTopLeft = Color.FromArgb(0, 131, 143);
                admin_show3.GradientTopRight = Color.FromArgb(0, 131, 143);
                salary_details.GradientBottomLeft = Color.FromArgb(0, 131, 143);
                salary_details.GradientTopLeft = Color.FromArgb(0, 131, 143);
                salary_details.GradientTopRight = Color.FromArgb(0, 131, 143);

                atten_details.GradientBottomLeft = Color.FromArgb(0, 131, 143);
                atten_details.GradientTopLeft = Color.FromArgb(0, 131, 143);
                atten_details.GradientTopRight = Color.FromArgb(0, 131, 143);
            }
            else if (theme == "purple")
            {
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientBottomLeft = Color.FromArgb(106, 27, 154);
                admin_show1.GradientTopLeft = Color.FromArgb(106, 27, 154);
                admin_show1.GradientTopRight = Color.FromArgb(106, 27, 154);
                admin_show2.GradientBottomLeft = Color.FromArgb(106, 27, 154);
                admin_show2.GradientTopLeft = Color.FromArgb(106, 27, 154);
                admin_show2.GradientTopRight = Color.FromArgb(106, 27, 154);
                admin_show3.GradientBottomLeft = Color.FromArgb(106, 27, 154);
                admin_show3.GradientTopLeft = Color.FromArgb(106, 27, 154);
                admin_show3.GradientTopRight = Color.FromArgb(106, 27, 154);
                salary_details.GradientBottomLeft = Color.FromArgb(106, 27, 154);
                salary_details.GradientTopLeft = Color.FromArgb(106, 27, 154);
                salary_details.GradientTopRight = Color.FromArgb(106, 27, 154);

                atten_details.GradientBottomLeft = Color.FromArgb(106, 27, 154);
                atten_details.GradientTopLeft = Color.FromArgb(106, 27, 154);
                atten_details.GradientTopRight = Color.FromArgb(106, 27, 154);
            }
            else if (theme == "orange")
            {
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientBottomLeft = Color.FromArgb(255, 143, 0);
                admin_show1.GradientTopLeft = Color.FromArgb(255, 143, 0);
                admin_show1.GradientTopRight = Color.FromArgb(255, 143, 0);
                admin_show2.GradientBottomLeft = Color.FromArgb(255, 143, 0);
                admin_show2.GradientTopLeft = Color.FromArgb(255, 143, 0);
                admin_show2.GradientTopRight = Color.FromArgb(255, 143, 0);
                admin_show3.GradientBottomLeft = Color.FromArgb(255, 143, 0);
                admin_show3.GradientTopLeft = Color.FromArgb(255, 143, 0);
                admin_show3.GradientTopRight = Color.FromArgb(255, 143, 0);
                salary_details.GradientBottomLeft = Color.FromArgb(255, 143, 0);
                salary_details.GradientTopLeft = Color.FromArgb(255, 143, 0);
                salary_details.GradientTopRight = Color.FromArgb(255, 143, 0);

                atten_details.GradientBottomLeft = Color.FromArgb(255, 143, 0);
                atten_details.GradientTopLeft = Color.FromArgb(255, 143, 0);
                atten_details.GradientTopRight = Color.FromArgb(255, 143, 0);
            }
            else if (theme == "gray")
            {
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientBottomLeft = Color.FromArgb(55, 71, 79);
                admin_show1.GradientTopLeft = Color.FromArgb(55, 71, 79);
                admin_show1.GradientTopRight = Color.FromArgb(55, 71, 79);
                admin_show2.GradientBottomLeft = Color.FromArgb(55, 71, 79);
                admin_show2.GradientTopLeft = Color.FromArgb(55, 71, 79);
                admin_show2.GradientTopRight = Color.FromArgb(55, 71, 79);
                admin_show3.GradientBottomLeft = Color.FromArgb(55, 71, 79);
                admin_show3.GradientTopLeft = Color.FromArgb(55, 71, 79);
                admin_show3.GradientTopRight = Color.FromArgb(55, 71, 79);
                salary_details.GradientBottomLeft = Color.FromArgb(55, 71, 79);
                salary_details.GradientTopLeft = Color.FromArgb(55, 71, 79);
                salary_details.GradientTopRight = Color.FromArgb(55, 71, 79);

                atten_details.GradientBottomLeft = Color.FromArgb(55, 71, 79);
                atten_details.GradientTopLeft = Color.FromArgb(55, 71, 79);
                atten_details.GradientTopRight = Color.FromArgb(55, 71, 79);
            }
            else if (theme == "yellow")
            {
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientBottomLeft = Color.FromArgb(249, 168, 37);
                admin_show1.GradientTopLeft = Color.FromArgb(249, 168, 37);
                admin_show1.GradientTopRight = Color.FromArgb(249, 168, 37);
                admin_show2.GradientBottomLeft = Color.FromArgb(249, 168, 37);
                admin_show2.GradientTopLeft = Color.FromArgb(249, 168, 37);
                admin_show2.GradientTopRight = Color.FromArgb(249, 168, 37);
                admin_show3.GradientBottomLeft = Color.FromArgb(249, 168, 37);
                admin_show3.GradientTopLeft = Color.FromArgb(249, 168, 37);
                admin_show3.GradientTopRight = Color.FromArgb(249, 168, 37);
                salary_details.GradientBottomLeft = Color.FromArgb(249, 168, 37);
                salary_details.GradientTopLeft = Color.FromArgb(249, 168, 37);
                salary_details.GradientTopRight = Color.FromArgb(249, 168, 37);

                atten_details.GradientBottomLeft = Color.FromArgb(249, 168, 37);
                atten_details.GradientTopLeft = Color.FromArgb(249, 168, 37);
                atten_details.GradientTopRight = Color.FromArgb(249, 168, 37);
            }
            else if (theme == "darkpurple")
            {
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                profile_nav_btn.BackColor = Color.FromArgb(69, 39, 160);

                admin_show1.GradientBottomLeft = Color.FromArgb(69, 39, 160);
                admin_show1.GradientTopLeft = Color.FromArgb(69, 39, 160);
                admin_show1.GradientTopRight = Color.FromArgb(69, 39, 160);
                admin_show2.GradientBottomLeft = Color.FromArgb(69, 39, 160);
                admin_show2.GradientTopLeft = Color.FromArgb(69, 39, 160);
                admin_show2.GradientTopRight = Color.FromArgb(69, 39, 160);
                admin_show3.GradientBottomLeft = Color.FromArgb(69, 39, 160);
                admin_show3.GradientTopLeft = Color.FromArgb(69, 39, 160);
                admin_show3.GradientTopRight = Color.FromArgb(69, 39, 160);
                salary_details.GradientBottomLeft = Color.FromArgb(69, 39, 160);
                salary_details.GradientTopLeft = Color.FromArgb(69, 39, 160);
                salary_details.GradientTopRight = Color.FromArgb(69, 39, 160);

                atten_details.GradientBottomLeft = Color.FromArgb(69, 39, 160);
                atten_details.GradientTopLeft = Color.FromArgb(69, 39, 160);
                atten_details.GradientTopRight = Color.FromArgb(69, 39, 160);
            }
            else if (theme == "red")
            {
                admin_show1.GradientBottomLeft = Color.FromArgb(198, 40, 40);
                admin_show1.GradientTopLeft = Color.FromArgb(198, 40, 40);
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show1.GradientTopRight = Color.FromArgb(198, 40, 40);
                admin_show2.GradientBottomLeft = Color.FromArgb(198, 40, 40);
                admin_show2.GradientTopLeft = Color.FromArgb(198, 40, 40);
                admin_show2.GradientTopRight = Color.FromArgb(198, 40, 40);
                admin_show3.GradientBottomLeft = Color.FromArgb(198, 40, 40);
                admin_show3.GradientTopLeft = Color.FromArgb(198, 40, 40);
                admin_show3.GradientTopRight = Color.FromArgb(198, 40, 40);
                salary_details.GradientBottomLeft = Color.FromArgb(198, 40, 40);
                salary_details.GradientTopLeft = Color.FromArgb(198, 40, 40);
                salary_details.GradientTopRight = Color.FromArgb(198, 40, 40);

                atten_details.GradientBottomLeft = Color.FromArgb(198, 40, 40);
                atten_details.GradientTopLeft = Color.FromArgb(198, 40, 40);
                atten_details.GradientTopRight = Color.FromArgb(198, 40, 40);
            }
            else if (theme == "green")
            {
                admin_show1.GradientBottomLeft = Color.FromArgb(46, 125, 50);
                admin_show1.GradientTopLeft = Color.FromArgb(46, 125, 50);
                admin_show1.GradientTopRight = Color.FromArgb(46, 125, 50);
                category.ForeColor = Color.Black; white_1.ForeColor = Color.Black;
                white_2.ForeColor = Color.Black;
                education_label.ForeColor = Color.Black;
                experience_label.ForeColor = Color.Black;
                admin_show2.GradientBottomLeft = Color.FromArgb(46, 125, 50);
                admin_show2.GradientTopLeft = Color.FromArgb(46, 125, 50);
                admin_show2.GradientTopRight = Color.FromArgb(46, 125, 50);
                admin_show3.GradientBottomLeft = Color.FromArgb(46, 125, 50);
                admin_show3.GradientTopLeft = Color.FromArgb(46, 125, 50);
                admin_show3.GradientTopRight = Color.FromArgb(46, 125, 50);
                salary_details.GradientBottomLeft = Color.FromArgb(46, 125, 50);
                salary_details.GradientTopLeft = Color.FromArgb(46, 125, 50);
                salary_details.GradientTopRight = Color.FromArgb(46, 125, 50);

                atten_details.GradientBottomLeft = Color.FromArgb(46, 125, 50);
                atten_details.GradientTopLeft = Color.FromArgb(46, 125, 50);
                atten_details.GradientTopRight = Color.FromArgb(46, 125, 50);
            }


        }
        private void numbers_fetching()
        {
            try
            {

                var empData = from item in data.USERs
                              where item.ROLE == "Employee"
                              select item;
                int empCount = empData.Count();
                emp_number.Text = empCount.ToString();

                var userData = from item in data.USERs
                               where item.ROLE == "user"
                               select item;
                int userCount = userData.Count();
                user_number.Text = userCount.ToString();

                var salData = from item in data.SALARIEs
                              select item.USER_SALARY;
                double salCount = salData.Sum();
                salary_number.Text = "$ " + salCount.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void new_user_btn_Click(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = add_users_tab;
            data_clear();
        }

        private void users_show_btn_Click(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = show_users_tab;
            data_fetch();
        }

        private void update_user_btn_Click(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = show_users_tab;
            alert = new AlertMessages("Please select a user to update it's information !!", AlertMessages.alertType.warning);
            alert.BringToFront();

            alert.Show();
        }

        private void fetch_user_data()
        {
            var userData = from item in data.USERs
                           where item.ROLE == "user"
                           select item;


            show_users.DataSource = userData.ToList();
        }

        private void update_to_tab_Click(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = update_users_tab;
            data_load_to_update();
        }

        private void data_load_to_update()
        {
            int emp_id = Convert.ToInt32(show_users.CurrentRow.Cells[0].Value.ToString());
            USER emp_data = data.USERs.Where(find => find.ID == emp_id).FirstOrDefault();


            string lang_data = emp_data.LANGUAGE.ToString();

            string[] lang_list = lang_data.Split(',');
            for (int i = 0; i < lang_list.Length; i++)
            {
                lang_list[i] = lang_list[i].Trim();
            }
            for (int i = 0; i < update_languages_user.Items.Count; i++)
            {
                update_languages_user.SetItemChecked(i, false);
                for (int j = 0; j < lang_list.Length; j++)
                {
                    if (update_languages_user.Items[i].ToString() == lang_list[j].ToString())
                    {
                        update_languages_user.SetItemChecked(i, true);
                    }
                }
            }


            update_user_first.Text = emp_data.FIRST_NAME;
            byte[] image = emp_data.IMAGE;
            MemoryStream stream = new MemoryStream(image);
            update_user_image.Image = Image.FromStream(stream);
            update_user_last.Text = emp_data.LAST_NAME;
            update_user_job.Text = emp_data.JOB_TITLE;
            update_user_email.Text = emp_data.EMAIL;
            update_user_username.Text = emp_data.USERNAME;
            update_user_password.Text = emp_data.PASSWORD;
            update_user_c_password.Text = emp_data.PASSWORD;
            update_user_phone.Text = emp_data.CONTACT_PHONE;
            update_user_address.Text = emp_data.CONTACT_ADDRESS;
            update_user_fb.Text = emp_data.SOCIAL_FACEBOOK;
            update_user_des.Text = emp_data.DESCRIPTION;
            update_user_tw.Text = emp_data.SOCIAL_TWITTER;
            update_user_ln.Text = emp_data.SOCIAL_LINKEDIN;
            update_user_education.Text = emp_data.EDUCATION;
            update_user_experience.Text = emp_data.EXPERIENCE;
            update_user_ques.Text = emp_data.SECURITY_QUESTION;
            update_user_ans.Text = emp_data.SECURITY_ANSWER;
        }

        private void back_to_admin1(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = admin_main;
        }

        private void back_to_search(object sender, EventArgs e)
        {
            admin_mini_screen.SelectedTab = show_users_tab;
        }

        private void Browse_update_user_Click(object sender, EventArgs e)
        {
            if (Imagepicker.ShowDialog() == DialogResult.OK)
            {
                image_emp.Image = Image.FromFile(Imagepicker.FileName);
            }
        }

        private void back_to_emp_Click(object sender, EventArgs e)
        {
            emp_mini_screen.SelectedTab = select_emp_screen;
        }

        private void Mini_navbar_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Go_to_new_emp(object sender, EventArgs e)
        {
            emp_mini_screen.SelectedTab = new_emp_screen;
            clear_emp_data();
        }

        private void New_atten_btn_Click(object sender, EventArgs e)
        {
            attendance_mini_screen.SelectedTab = new_atten_screen;
        }

        private void back_to_atten_Click(object sender, EventArgs e)
        {
            attendance_mini_screen.SelectedTab = select_atten_screen;
        }

        private void Update_attendance_btn_Click_1(object sender, EventArgs e)
        {
            attendance_mini_screen.SelectedTab = update_atten_screen;
            int atten_id = Convert.ToInt32(select_emp_for_attendance.CurrentRow.Cells[0].Value.ToString());
            ATTENDANCE atten_data = data.ATTENDANCEs.Where(find => find.ID == atten_id).FirstOrDefault();
            update_date_attendance.Value = atten_data.DATETIME_NOW;
            update_username_attendance.Text = atten_data.USER.FIRST_NAME + " " + atten_data.USER.LAST_NAME;
        }

        private void Detailed_atten_btn_Click(object sender, EventArgs e)
        {
            attendance_mini_screen.SelectedTab = detailed_atten_screen;
            int attendance_id = Convert.ToInt32(select_emp_for_attendance.CurrentRow.Cells[1].Value.ToString());
            var attendanceData = from item in data.ATTENDANCEs
                                 where item.USER_NAME == attendance_id
                                 select new
                                 {
                                     ID = item.ID,
                                     NAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                     ATTENDANCE = item.DATETIME_NOW
                                 };
            var countSalary = from item in data.ATTENDANCEs
                              select item;
            double attenCount = countSalary.Count();

            show_details_attendance.Text = "Total days worked in the company \n\n" + attenCount.ToString();

            var countUserAtten = from item in data.ATTENDANCEs
                                 where item.USER_NAME == attendance_id
                                 select item;
            double attenUserCount = countUserAtten.Count();

            show_details_user_attendance.Text = "Total days this employee has worked \n\n" + attenUserCount.ToString();
            show_attendance_of_user.DataSource = attendanceData.ToList();

            var atten_Data = from item in data.ATTENDANCEs
                             where item.USER_NAME == attendance_id
                             select new
                             {
                                 NAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                 JOB = item.USER.JOB_TITLE,
                                 USERNAME = item.USER.USERNAME,
                                 EMAIL = item.USER.EMAIL,
                                 ROLE = item.USER.ROLE
                             };
            string name = "";
            string job = "";
            string username = "";
            string email = "";
            string role = "";
            foreach (var item in atten_Data)
            {
                name = item.NAME;
                job = item.JOB;
                username = item.USERNAME;
                email = item.EMAIL;
                role = item.ROLE;
            }


            attendance_details_data.Text = "Name : " + name + "\nJob Title : " + job + "\nUsername : " + username + "\nEmail : " + email + "\nRole : " + role;

        }

        private void new_salary_btn_Click(object sender, EventArgs e)
        {
            salary_mini_screen.SelectedTab = new_salary_screen;

            rate_txt.Text = "";
            salary.Text = "";
        }

        private void update_salary_bttn_Click(object sender, EventArgs e)
        {
            salary_mini_screen.SelectedTab = update_salary_screen;
        }

        private void detailed_salary_btn(object sender, EventArgs e)
        {
            salary_mini_screen.SelectedTab = detailed_salary_screen;
            int salary_id = Convert.ToInt32(select_emp_for_salary.CurrentRow.Cells[1].Value.ToString());

            var salaryData = from item in data.SALARIEs
                             where item.USER_NAME == salary_id
                             select new
                             {
                                 ID = item.ID,
                                 NAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                 SALARY = item.USER_SALARY,

                             };

            var countSalary = from item in data.SALARIEs
                              select item.USER_SALARY;
            double salCount = countSalary.Sum();
            var countUserSalary = from item in data.SALARIEs
                                  where item.USER_NAME == salary_id
                                  select item.USER_SALARY;
            double salUserCount = countUserSalary.Sum();
            user_salary_text.Text = "Salary given to this employee \n\n$" + salUserCount.ToString();
            total_salary_text.Text = "Total Salaries given by the company \n\n$" + salCount.ToString();
            user_salary_screen.DataSource = salaryData.ToList();

            var salary_Data = from item in data.SALARIEs
                              where item.USER_NAME == salary_id
                              select new
                              {
                                  NAME = item.USER.FIRST_NAME + " " + item.USER.LAST_NAME,
                                  JOB = item.USER.JOB_TITLE,
                                  USERNAME = item.USER.USERNAME,
                                  EMAIL = item.USER.EMAIL,
                                  ROLE = item.USER.ROLE
                              };
            string name = "";
            string job = "";
            string username = "";
            string email = "";
            string role = "";
            foreach (var item in salary_Data)
            {
                name = item.NAME;
                job = item.JOB;
                username = item.USERNAME;
                email = item.EMAIL;
                role = item.ROLE;
            }


            salary_details_data.Text = "Name : " + name + "\nJob Title : " + job + "\nUsername : " + username + "\nEmail : " + email + "\nRole : " + role;
        }

        private void back_to_main_salary_screen_Click(object sender, EventArgs e)
        {
            salary_mini_screen.SelectedTab = select_salary_screen;
        }

        private void Panel146_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Update_username_attendance_Format(object sender, ListControlConvertEventArgs e)
        {
            string last_name = ((USER)e.ListItem).LAST_NAME;
            string first_name = ((USER)e.ListItem).FIRST_NAME;
            e.Value = first_name + " " + last_name;
        }

        private void Update_attendance_button_Click(object sender, EventArgs e)
        {
            int atten_id = Convert.ToInt32(select_emp_for_attendance.CurrentRow.Cells[0].Value.ToString());
            ATTENDANCE attenData = data.ATTENDANCEs.Where(find => find.ID == atten_id).FirstOrDefault();

            attenData.DATETIME_NOW = update_date_attendance.Value;
            attendance_mini_screen.SelectedTab = select_atten_screen;
            alert = new AlertMessages("Attendance of current user updated !!", AlertMessages.alertType.success);
            alert.BringToFront();

            alert.Show();
        }

        private void Label67_Click(object sender, EventArgs e)
        {
        }

        private void Update_user_data_Click(object sender, EventArgs e)
        {


            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (update_user_first.Text == "")
            {
                alert = new AlertMessages("Please enter the first name of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_last.Text == "")
            {
                alert = new AlertMessages("Please enter the last name of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_job.Text == "")
            {
                alert = new AlertMessages("Please select any one job title !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_des.Text == "")
            {
                alert = new AlertMessages("Please enter the description of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_email.Text == "")
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (!rEmail.IsMatch(update_user_email.Text.Trim()))
            {
                alert = new AlertMessages("Please input a correct email address !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (update_user_username.Text == "")
            {
                alert = new AlertMessages("Please enter the username of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_address.Text == "")
            {
                alert = new AlertMessages("Please enter the address of user !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_ques.Text == "")
            {
                alert = new AlertMessages("Please select any one security question !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_user_ans.Text == "")
            {
                alert = new AlertMessages("Please enter the answer of selected question !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {
                admin_mini_screen.SelectedTab = update_more_user_screen;

            }



        }

        private void update_user_more_data_Click(object sender, EventArgs e)
        {

            if (update_languages_user.CheckedItems.Count == 0)
            {
                alert = new AlertMessages("Please check any one of the languages !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else
            {


                string lang_data = "";


                if (update_user_education.Text == "")
                {
                    alert = new AlertMessages("Please enter details of education of user !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }
                else if (update_user_experience.Text == "")
                {
                    alert = new AlertMessages("Please enter details of experience of user !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }

                else if (update_languages_user.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < update_languages_user.CheckedItems.Count; i++)
                    {
                        if (lang_data == "")
                        {
                            lang_data += update_languages_user.CheckedItems[i].ToString();

                        }
                        else
                        {
                            lang_data += ", " + update_languages_user.CheckedItems[i].ToString();

                        }

                    }

                    if (update_user_image.Image != null)
                    {

                        MemoryStream stream = new MemoryStream();
                        update_user_image.Image.Save(stream, update_user_image.Image.RawFormat);
                        byte[] image = stream.GetBuffer();

                        string password;

                        if (update_user_password.Text == update_user_c_password.Text)
                        {
                            password = update_user_password.Text;
                            int user_id = Convert.ToInt32(show_users.CurrentRow.Cells[0].Value.ToString());
                            USER userData = data.USERs.Where(find => find.ID == user_id).FirstOrDefault();



                            string lang_data2 = "";

                            if (update_languages.CheckedItems.Count > 0)
                            {
                                for (int i = 0; i < update_languages.CheckedItems.Count; i++)
                                {
                                    if (lang_data2 == "")
                                    {
                                        lang_data2 += update_languages.CheckedItems[i].ToString();
                                    }
                                    else
                                    {
                                        lang_data2 += ", " + update_languages.CheckedItems[i].ToString();

                                    }

                                }

                            }
                            else
                            {
                                alert = new AlertMessages("Please check out atleast one language !!", AlertMessages.alertType.error);
                                alert.BringToFront();

                                alert.Show();
                            }




                            userData.IMAGE = image;
                            userData.FIRST_NAME = update_user_first.Text;
                            userData.LAST_NAME = update_user_last.Text;
                            userData.JOB_TITLE = update_user_job.Text;
                            userData.DESCRIPTION = update_user_des.Text;
                            userData.EMAIL = update_user_email.Text;
                            userData.CONTACT_EMAIL = update_user_email.Text;
                            userData.USERNAME = update_user_username.Text;
                            userData.PASSWORD = password;
                            userData.CONTACT_PHONE = update_user_phone.Text;
                            userData.CONTACT_ADDRESS = update_user_address.Text;
                            userData.SOCIAL_FACEBOOK = update_user_fb.Text;
                            userData.SOCIAL_TWITTER = update_user_tw.Text;
                            userData.SOCIAL_LINKEDIN = update_user_ln.Text;
                            userData.SECURITY_QUESTION = update_user_ques.Text;
                            userData.SECURITY_ANSWER = update_user_ans.Text;
                            userData.EDUCATION = update_user_education.Text;
                            userData.EXPERIENCE = update_user_experience.Text;
                            userData.LANGUAGE = lang_data2;


                            data.SaveChanges();

                            numbers_fetching();
                            data_fetch();
                            admin_mini_screen.SelectedTab = admin_main;
                            alert = new AlertMessages("User Added !!", AlertMessages.alertType.success);
                            alert.BringToFront();
                            alert.Show();
                        }
                        else
                        {
                            alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                            alert.BringToFront();

                            alert.Show();
                        }



                    }
                    else
                    {
                        alert = new AlertMessages("Please check out aleast one language !!", AlertMessages.alertType.error);
                        alert.BringToFront();

                        alert.Show();
                    }


                }

            }
        }

        private void update_profile_user_Click(object sender, EventArgs e)
        {

            string lang_data = "";


            if (update_profile_edu.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }
            else if (update_profile_exp.Text == "")
            {
                alert = new AlertMessages("Please fill out the details first !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            else if (update_profile_lang.CheckedItems.Count > 0)
            {
                for (int i = 0; i < update_profile_lang.CheckedItems.Count; i++)
                {
                    if (lang_data == "")
                    {
                        lang_data += update_profile_lang.CheckedItems[i].ToString();

                    }
                    else
                    {
                        lang_data += ", " + update_profile_lang.CheckedItems[i].ToString();

                    }

                }

                if (edit_profile_image.Image != null)
                {

                    MemoryStream stream = new MemoryStream();
                    edit_profile_image.Image.Save(stream, edit_profile_image.Image.RawFormat);
                    byte[] image = stream.GetBuffer();

                    string password;


                    password = edit_profile_password.Text;
                    int user_id = Login.user_id;
                    USER userData = data.USERs.Where(find => find.ID == user_id).FirstOrDefault();



                    string lang_data2 = "";

                    if (update_profile_lang.CheckedItems.Count > 0)
                    {
                        for (int i = 0; i < update_profile_lang.CheckedItems.Count; i++)
                        {
                            if (lang_data2 == "")
                            {
                                lang_data2 += update_profile_lang.CheckedItems[i].ToString();
                            }
                            else
                            {
                                lang_data2 += ", " + update_profile_lang.CheckedItems[i].ToString();

                            }

                        }

                    }
                    else
                    {
                        alert = new AlertMessages("Please check out atleast one language !!", AlertMessages.alertType.error);
                        alert.BringToFront();

                        alert.Show();
                    }

                    userData.FIRST_NAME = edit_profile_first_name.Text;
                    userData.LAST_NAME = edit_profile_last_name.Text;


                    userData.IMAGE = image;
                    userData.JOB_TITLE = edit_profile_job_title.Text;
                    userData.DESCRIPTION = edit_profile_description.Text;
                    userData.EMAIL = edit_profile_email.Text;
                    userData.CONTACT_EMAIL = edit_profile_email.Text;
                    userData.USERNAME = edit_profile_username.Text;
                    userData.PASSWORD = password;

                    userData.CONTACT_PHONE = edit_profile_phone.Text;
                    userData.CONTACT_ADDRESS = edit_profile_address.Text;
                    userData.SOCIAL_FACEBOOK = edit_profile_facebook.Text;
                    userData.SOCIAL_TWITTER = edit_profile_twitter.Text;
                    userData.SOCIAL_LINKEDIN = edit_profile_linked.Text;
                    userData.LANGUAGE = lang_data2;
                    userData.EDUCATION = update_profile_edu.Text;
                    userData.EXPERIENCE = update_profile_exp.Text;


                    data.SaveChanges();
                    profile_load();
                    alert = new AlertMessages("Profile Uploaded !!", AlertMessages.alertType.success);
                    alert.BringToFront();
                    alert.Show();
                    the_screen.SelectedTab = profile_main_screen;



                }
                else
                {
                    alert = new AlertMessages("Please check out aleast one language !!", AlertMessages.alertType.error);
                    alert.BringToFront();

                    alert.Show();
                }




            }
        }

        private void phone_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifying that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '+'))
            {
                e.Handled = true;
                alert = new AlertMessages("Please enter a correct phone number !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            // Preventing use of decimal numbers
            if (e.KeyChar == '.')
            {
                e.Handled = true;
                alert = new AlertMessages("Please enter a correct phone number !!", AlertMessages.alertType.error);
                alert.BringToFront();

                alert.Show();
            }

            // Allowing + sign in number
            if ((e.KeyChar == '+'))
            {
                e.Handled = false;

            }
        }
    }


}


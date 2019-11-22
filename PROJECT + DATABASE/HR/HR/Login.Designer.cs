namespace HR
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.show_1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.close_btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.register_btn = new System.Windows.Forms.Label();
            this.login_btn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pass_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.email_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.bunifuGradientPanel2);
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.show_1);
            this.bunifuGradientPanel2.Controls.Add(this.close_btn);
            this.bunifuGradientPanel2.Controls.Add(this.register_btn);
            this.bunifuGradientPanel2.Controls.Add(this.login_btn);
            this.bunifuGradientPanel2.Controls.Add(this.label2);
            this.bunifuGradientPanel2.Controls.Add(this.label1);
            this.bunifuGradientPanel2.Controls.Add(this.pass_txt);
            this.bunifuGradientPanel2.Controls.Add(this.email_txt);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(293, 0);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(458, 450);
            this.bunifuGradientPanel2.TabIndex = 3;
            // 
            // show_1
            // 
            this.show_1.BackColor = System.Drawing.Color.Transparent;
            this.show_1.Image = ((System.Drawing.Image)(resources.GetObject("show_1.Image")));
            this.show_1.ImageActive = null;
            this.show_1.Location = new System.Drawing.Point(319, 239);
            this.show_1.Name = "show_1";
            this.show_1.Size = new System.Drawing.Size(25, 25);
            this.show_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_1.TabIndex = 9;
            this.show_1.TabStop = false;
            this.show_1.Zoom = 10;
            this.show_1.Click += new System.EventHandler(this.show_1_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.White;
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.ImageActive = null;
            this.close_btn.Location = new System.Drawing.Point(426, 12);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(20, 20);
            this.close_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.close_btn.TabIndex = 5;
            this.close_btn.TabStop = false;
            this.close_btn.Zoom = 10;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // register_btn
            // 
            this.register_btn.AutoSize = true;
            this.register_btn.BackColor = System.Drawing.Color.White;
            this.register_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.ForeColor = System.Drawing.Color.Gray;
            this.register_btn.Location = new System.Drawing.Point(43, 280);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(131, 17);
            this.register_btn.TabIndex = 4;
            this.register_btn.Text = "Forgot Password ? ";
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.AutoSize = true;
            this.login_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.login_btn.BackColor = System.Drawing.Color.Black;
            this.login_btn.Depth = 0;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.Location = new System.Drawing.Point(296, 331);
            this.login_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.login_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.login_btn.Name = "login_btn";
            this.login_btn.Padding = new System.Windows.Forms.Padding(50);
            this.login_btn.Primary = false;
            this.login_btn.Size = new System.Drawing.Size(52, 36);
            this.login_btn.TabIndex = 3;
            this.login_btn.Text = "Login";
            this.login_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email or Username";
            // 
            // pass_txt
            // 
            this.pass_txt.BackColor = System.Drawing.Color.White;
            this.pass_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pass_txt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.pass_txt.ForeColor = System.Drawing.Color.Black;
            this.pass_txt.HintForeColor = System.Drawing.Color.Empty;
            this.pass_txt.HintText = "";
            this.pass_txt.isPassword = true;
            this.pass_txt.LineFocusedColor = System.Drawing.Color.Black;
            this.pass_txt.LineIdleColor = System.Drawing.Color.Gray;
            this.pass_txt.LineMouseHoverColor = System.Drawing.Color.Black;
            this.pass_txt.LineThickness = 3;
            this.pass_txt.Location = new System.Drawing.Point(43, 239);
            this.pass_txt.Margin = new System.Windows.Forms.Padding(4);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.Size = new System.Drawing.Size(305, 33);
            this.pass_txt.TabIndex = 1;
            this.pass_txt.Text = "admin12";
            this.pass_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // email_txt
            // 
            this.email_txt.BackColor = System.Drawing.Color.White;
            this.email_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email_txt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.email_txt.ForeColor = System.Drawing.Color.Black;
            this.email_txt.HintForeColor = System.Drawing.Color.Empty;
            this.email_txt.HintText = "";
            this.email_txt.isPassword = false;
            this.email_txt.LineFocusedColor = System.Drawing.Color.Black;
            this.email_txt.LineIdleColor = System.Drawing.Color.Gray;
            this.email_txt.LineMouseHoverColor = System.Drawing.Color.Black;
            this.email_txt.LineThickness = 3;
            this.email_txt.Location = new System.Drawing.Point(43, 160);
            this.email_txt.Margin = new System.Windows.Forms.Padding(4);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(305, 33);
            this.email_txt.TabIndex = 1;
            this.email_txt.Text = "admin";
            this.email_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Maroon;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Aqua;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(293, 450);
            this.bunifuGradientPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 0;
            this.bunifuElipse2.TargetControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuImageButton close_btn;
        private System.Windows.Forms.Label register_btn;
        private MaterialSkin.Controls.MaterialFlatButton login_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox pass_txt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox email_txt;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuImageButton show_1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
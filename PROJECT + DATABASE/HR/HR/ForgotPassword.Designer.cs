namespace HR
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.close_btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.next_to_securityquestion_btn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.email_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.close_btn);
            this.bunifuGradientPanel2.Controls.Add(this.next_to_securityquestion_btn);
            this.bunifuGradientPanel2.Controls.Add(this.label1);
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
            // next_to_securityquestion_btn
            // 
            this.next_to_securityquestion_btn.AutoSize = true;
            this.next_to_securityquestion_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.next_to_securityquestion_btn.BackColor = System.Drawing.Color.Black;
            this.next_to_securityquestion_btn.Depth = 0;
            this.next_to_securityquestion_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_to_securityquestion_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_to_securityquestion_btn.ForeColor = System.Drawing.Color.White;
            this.next_to_securityquestion_btn.Location = new System.Drawing.Point(301, 276);
            this.next_to_securityquestion_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.next_to_securityquestion_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.next_to_securityquestion_btn.Name = "next_to_securityquestion_btn";
            this.next_to_securityquestion_btn.Padding = new System.Windows.Forms.Padding(50);
            this.next_to_securityquestion_btn.Primary = false;
            this.next_to_securityquestion_btn.Size = new System.Drawing.Size(46, 36);
            this.next_to_securityquestion_btn.TabIndex = 3;
            this.next_to_securityquestion_btn.Text = "Next";
            this.next_to_securityquestion_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.next_to_securityquestion_btn.UseVisualStyleBackColor = false;
            this.next_to_securityquestion_btn.Click += new System.EventHandler(this.next_to_securityquestion_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email or Username";
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
            this.email_txt.Location = new System.Drawing.Point(42, 204);
            this.email_txt.Margin = new System.Windows.Forms.Padding(4);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(305, 33);
            this.email_txt.TabIndex = 1;
            this.email_txt.Text = "jazz12";
            this.email_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.panel1.TabIndex = 1;
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
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 0;
            this.bunifuElipse2.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPassword";
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuImageButton close_btn;
        private MaterialSkin.Controls.MaterialFlatButton next_to_securityquestion_btn;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox email_txt;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace Project_SAD_CUTEES
{
    partial class Form1
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
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_signup = new System.Windows.Forms.Label();
            this.panel_login = new Guna.UI2.WinForms.Guna2Panel();
            this.pict_userlogin = new System.Windows.Forms.PictureBox();
            this.pict_close = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pict_minimize = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_userlogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_minimize)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(209, 147);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(365, 29);
            this.txt_email.TabIndex = 1;
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(209, 230);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(365, 29);
            this.txt_password.TabIndex = 2;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Gold;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(308, 318);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(161, 48);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "Log In";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_signup
            // 
            this.lbl_signup.AutoSize = true;
            this.lbl_signup.BackColor = System.Drawing.Color.Transparent;
            this.lbl_signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_signup.Location = new System.Drawing.Point(229, 404);
            this.lbl_signup.Name = "lbl_signup";
            this.lbl_signup.Size = new System.Drawing.Size(292, 20);
            this.lbl_signup.TabIndex = 4;
            this.lbl_signup.Text = "Don\'t have an account ? Sign Up here";
            this.lbl_signup.Click += new System.EventHandler(this.lbl_signup_Click);
            this.lbl_signup.MouseLeave += new System.EventHandler(this.lbl_signup_MouseLeave);
            this.lbl_signup.MouseHover += new System.EventHandler(this.lbl_signup_MouseHover);
            // 
            // panel_login
            // 
            this.panel_login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_login.BackColor = System.Drawing.Color.Transparent;
            this.panel_login.BorderColor = System.Drawing.Color.Transparent;
            this.panel_login.BorderRadius = 80;
            this.panel_login.BorderThickness = 50;
            this.panel_login.Controls.Add(this.pict_userlogin);
            this.panel_login.Controls.Add(this.txt_email);
            this.panel_login.Controls.Add(this.txt_password);
            this.panel_login.Controls.Add(this.lbl_signup);
            this.panel_login.Controls.Add(this.btn_login);
            this.panel_login.FillColor = System.Drawing.Color.LightGray;
            this.panel_login.Location = new System.Drawing.Point(588, 265);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(745, 453);
            this.panel_login.TabIndex = 5;
            // 
            // pict_userlogin
            // 
            this.pict_userlogin.Image = global::Project_SAD_CUTEES.Properties.Resources.USER_LOGIN;
            this.pict_userlogin.Location = new System.Drawing.Point(136, 57);
            this.pict_userlogin.Name = "pict_userlogin";
            this.pict_userlogin.Size = new System.Drawing.Size(524, 66);
            this.pict_userlogin.TabIndex = 5;
            this.pict_userlogin.TabStop = false;
            // 
            // pict_close
            // 
            this.pict_close.BackColor = System.Drawing.Color.Transparent;
            this.pict_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pict_close.FillColor = System.Drawing.Color.Transparent;
            this.pict_close.Image = global::Project_SAD_CUTEES.Properties.Resources.White_close_icon;
            this.pict_close.ImageRotate = 0F;
            this.pict_close.Location = new System.Drawing.Point(1846, 16);
            this.pict_close.Name = "pict_close";
            this.pict_close.Size = new System.Drawing.Size(56, 55);
            this.pict_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_close.TabIndex = 6;
            this.pict_close.TabStop = false;
            this.pict_close.Click += new System.EventHandler(this.pict_close_Click);
            // 
            // pict_minimize
            // 
            this.pict_minimize.BackColor = System.Drawing.Color.Transparent;
            this.pict_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pict_minimize.FillColor = System.Drawing.Color.Transparent;
            this.pict_minimize.Image = global::Project_SAD_CUTEES.Properties.Resources.White_minimize_icon;
            this.pict_minimize.ImageRotate = 0F;
            this.pict_minimize.Location = new System.Drawing.Point(1757, 16);
            this.pict_minimize.Name = "pict_minimize";
            this.pict_minimize.Size = new System.Drawing.Size(56, 55);
            this.pict_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_minimize.TabIndex = 7;
            this.pict_minimize.TabStop = false;
            this.pict_minimize.Click += new System.EventHandler(this.pict_minimize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.BackgroundImage = global::Project_SAD_CUTEES.Properties.Resources.Cutees_Wallpaper_with_logo;
            this.ClientSize = new System.Drawing.Size(1924, 1039);
            this.ControlBox = false;
            this.Controls.Add(this.pict_minimize);
            this.Controls.Add(this.pict_close);
            this.Controls.Add(this.panel_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_userlogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_minimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_signup;
        private Guna.UI2.WinForms.Guna2Panel panel_login;
        private System.Windows.Forms.PictureBox pict_userlogin;
        public Guna.UI2.WinForms.Guna2PictureBox pict_minimize;
        public Guna.UI2.WinForms.Guna2PictureBox pict_close;
    }
}


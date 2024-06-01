namespace Project_SAD_CUTEES
{
    partial class Form_Sign_Up
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
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_number = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.panel_login = new Guna.UI2.WinForms.Guna2Panel();
            this.pict_createaccount = new System.Windows.Forms.PictureBox();
            this.btn_signup = new System.Windows.Forms.Button();
            this.pict_minimize = new System.Windows.Forms.PictureBox();
            this.panel_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_createaccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_minimize)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_firstname
            // 
            this.txt_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_firstname.Location = new System.Drawing.Point(99, 122);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(281, 29);
            this.txt_firstname.TabIndex = 1;
            // 
            // txt_lastname
            // 
            this.txt_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lastname.Location = new System.Drawing.Point(486, 121);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(281, 29);
            this.txt_lastname.TabIndex = 2;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(218, 171);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(426, 29);
            this.txt_email.TabIndex = 3;
            // 
            // txt_number
            // 
            this.txt_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_number.Location = new System.Drawing.Point(218, 229);
            this.txt_number.Name = "txt_number";
            this.txt_number.Size = new System.Drawing.Size(426, 29);
            this.txt_number.TabIndex = 4;
            this.txt_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_number_KeyPress);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(218, 284);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(426, 29);
            this.txt_password.TabIndex = 5;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.BackColor = System.Drawing.Color.Transparent;
            this.lbl_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(275, 410);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(295, 20);
            this.lbl_login.TabIndex = 7;
            this.lbl_login.Text = "Already have an account ? Log In here";
            this.lbl_login.Click += new System.EventHandler(this.lbl_login_Click);
            this.lbl_login.MouseLeave += new System.EventHandler(this.lbl_login_MouseLeave);
            this.lbl_login.MouseHover += new System.EventHandler(this.lbl_login_MouseHover);
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.Transparent;
            this.panel_login.BorderColor = System.Drawing.Color.Transparent;
            this.panel_login.BorderRadius = 80;
            this.panel_login.BorderThickness = 50;
            this.panel_login.Controls.Add(this.pict_createaccount);
            this.panel_login.Controls.Add(this.lbl_login);
            this.panel_login.Controls.Add(this.btn_signup);
            this.panel_login.Controls.Add(this.txt_firstname);
            this.panel_login.Controls.Add(this.txt_lastname);
            this.panel_login.Controls.Add(this.txt_password);
            this.panel_login.Controls.Add(this.txt_email);
            this.panel_login.Controls.Add(this.txt_number);
            this.panel_login.FillColor = System.Drawing.Color.LightGray;
            this.panel_login.Location = new System.Drawing.Point(523, 267);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(867, 453);
            this.panel_login.TabIndex = 8;
            // 
            // pict_createaccount
            // 
            this.pict_createaccount.Image = global::Project_SAD_CUTEES.Properties.Resources.CREATE_AN_ACCOUNT;
            this.pict_createaccount.Location = new System.Drawing.Point(52, 31);
            this.pict_createaccount.Name = "pict_createaccount";
            this.pict_createaccount.Size = new System.Drawing.Size(787, 66);
            this.pict_createaccount.TabIndex = 8;
            this.pict_createaccount.TabStop = false;
            // 
            // btn_signup
            // 
            this.btn_signup.BackColor = System.Drawing.Color.Gold;
            this.btn_signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signup.Location = new System.Drawing.Point(364, 343);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(161, 48);
            this.btn_signup.TabIndex = 3;
            this.btn_signup.Text = "Sign Up";
            this.btn_signup.UseVisualStyleBackColor = false;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // pict_minimize
            // 
            this.pict_minimize.BackColor = System.Drawing.Color.Transparent;
            this.pict_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pict_minimize.Image = global::Project_SAD_CUTEES.Properties.Resources.White_minimize_icon;
            this.pict_minimize.Location = new System.Drawing.Point(1777, 12);
            this.pict_minimize.Name = "pict_minimize";
            this.pict_minimize.Size = new System.Drawing.Size(59, 57);
            this.pict_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_minimize.TabIndex = 9;
            this.pict_minimize.TabStop = false;
            this.pict_minimize.Click += new System.EventHandler(this.pict_minimize_Click);
            // 
            // Form_Sign_Up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.BackgroundImage = global::Project_SAD_CUTEES.Properties.Resources.Cutees_Wallpaper_with_logo;
            this.ClientSize = new System.Drawing.Size(1924, 1039);
            this.Controls.Add(this.pict_minimize);
            this.Controls.Add(this.panel_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Sign_Up";
            this.Text = "Form_Sign_Up";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Sign_Up_Load);
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_createaccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_minimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_number;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lbl_login;
        private Guna.UI2.WinForms.Guna2Panel panel_login;
        private System.Windows.Forms.Button btn_signup;
        private System.Windows.Forms.PictureBox pict_createaccount;
        private System.Windows.Forms.PictureBox pict_minimize;
    }
}
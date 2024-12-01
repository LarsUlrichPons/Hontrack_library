namespace Hontrack_library
{
    partial class LoginForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.showpass = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 506);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 506);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.library;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 506);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.PasswordInput);
            this.panel2.Controls.Add(this.UsernameInput);
            this.panel2.Controls.Add(this.showpass);
            this.panel2.Controls.Add(this.loginButton);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(373, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 506);
            this.panel2.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Hontrack_library.Properties.Resources.icons8_library_building_100;
            this.pictureBox2.Location = new System.Drawing.Point(167, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(36, 332);
            this.PasswordInput.Multiline = true;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(396, 40);
            this.PasswordInput.TabIndex = 19;
            // 
            // UsernameInput
            // 
            this.UsernameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameInput.Location = new System.Drawing.Point(36, 238);
            this.UsernameInput.Multiline = true;
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(396, 40);
            this.UsernameInput.TabIndex = 18;
            // 
            // showpass
            // 
            this.showpass.AutoSize = true;
            this.showpass.Location = new System.Drawing.Point(305, 384);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(148, 24);
            this.showpass.TabIndex = 17;
            this.showpass.Text = "Show Password";
            this.showpass.UseVisualStyleBackColor = true;
            this.showpass.CheckedChanged += new System.EventHandler(this.showpass_CheckedChanged_1);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SeaGreen;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(167, 433);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(147, 48);
            this.loginButton.TabIndex = 16;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "Enter login credentials";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(118, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 61);
            this.label3.TabIndex = 13;
            this.label3.Text = "HonTrack\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Username:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HonTrack: Library Management";
            this.TransparencyKey = System.Drawing.Color.MediumSeaGreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.CheckBox showpass;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
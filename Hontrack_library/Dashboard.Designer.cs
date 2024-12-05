using System.Windows.Forms;
using System;

namespace Hontrack_library
{
    partial class Dashboard
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.RbButton = new System.Windows.Forms.Button();
            this.BhButton = new System.Windows.Forms.Button();
            this.BbButton = new System.Windows.Forms.Button();
            this.DbButton = new System.Windows.Forms.Button();
            this.MuButton = new System.Windows.Forms.Button();
            this.BiButton = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dashMain1 = new Hontrack_library.DashMain();
            this.borrowBook1 = new Hontrack_library.BorrowBook();
            this.returnbook1 = new Hontrack_library.Returnbook();
            this.borrowingHistory1 = new Hontrack_library.BorrowingHistory();
            this.issueBook1 = new Hontrack_library.IssueBook();
            this.userManagement1 = new Hontrack_library.UserManagement();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Controls.Add(this.pictureBox7);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.RbButton);
            this.panel2.Controls.Add(this.BhButton);
            this.panel2.Controls.Add(this.BbButton);
            this.panel2.Controls.Add(this.DbButton);
            this.panel2.Controls.Add(this.MuButton);
            this.panel2.Controls.Add(this.BiButton);
            this.panel2.Controls.Add(this.LogoutBtn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 664);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox8.Image = global::Hontrack_library.Properties.Resources.log_out_btn;
            this.pictureBox8.Location = new System.Drawing.Point(14, 621);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(48, 40);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 17;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox7.Image = global::Hontrack_library.Properties.Resources.manage_users_btn;
            this.pictureBox7.Location = new System.Drawing.Point(14, 464);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(48, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 16;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox6.Image = global::Hontrack_library.Properties.Resources.book_inventory_btn;
            this.pictureBox6.Location = new System.Drawing.Point(14, 409);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 40);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 15;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox5.Image = global::Hontrack_library.Properties.Resources.return_book_btn;
            this.pictureBox5.Location = new System.Drawing.Point(14, 351);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox4.Image = global::Hontrack_library.Properties.Resources.borrowing_history_btn;
            this.pictureBox4.Location = new System.Drawing.Point(14, 294);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox3.Image = global::Hontrack_library.Properties.Resources.borrow_book_btn;
            this.pictureBox3.Location = new System.Drawing.Point(14, 242);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.pictureBox2.Image = global::Hontrack_library.Properties.Resources.dash_btn;
            this.pictureBox2.Location = new System.Drawing.Point(14, 185);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.userLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 168);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.user_img;
            this.pictureBox1.Location = new System.Drawing.Point(107, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.Color.Transparent;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.userLabel.Location = new System.Drawing.Point(51, 122);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(129, 29);
            this.userLabel.TabIndex = 8;
            this.userLabel.Text = "Welcome,";
            this.userLabel.Click += new System.EventHandler(this.userLabel_Click);
            // 
            // RbButton
            // 
            this.RbButton.BackColor = System.Drawing.Color.Transparent;
            this.RbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RbButton.FlatAppearance.BorderSize = 0;
            this.RbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbButton.ForeColor = System.Drawing.Color.White;
            this.RbButton.Location = new System.Drawing.Point(0, 288);
            this.RbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbButton.Name = "RbButton";
            this.RbButton.Size = new System.Drawing.Size(327, 59);
            this.RbButton.TabIndex = 7;
            this.RbButton.Text = "   Return Book";
            this.RbButton.UseVisualStyleBackColor = false;
            this.RbButton.Click += new System.EventHandler(this.RbButton_Click);
            // 
            // BhButton
            // 
            this.BhButton.BackColor = System.Drawing.Color.Transparent;
            this.BhButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BhButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BhButton.FlatAppearance.BorderSize = 0;
            this.BhButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BhButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BhButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BhButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BhButton.ForeColor = System.Drawing.Color.White;
            this.BhButton.Location = new System.Drawing.Point(0, 345);
            this.BhButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BhButton.Name = "BhButton";
            this.BhButton.Size = new System.Drawing.Size(331, 59);
            this.BhButton.TabIndex = 8;
            this.BhButton.Text = "      Borrowing History";
            this.BhButton.UseVisualStyleBackColor = false;
            this.BhButton.Click += new System.EventHandler(this.BhButton_Click);
            // 
            // BbButton
            // 
            this.BbButton.BackColor = System.Drawing.Color.Transparent;
            this.BbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BbButton.FlatAppearance.BorderSize = 0;
            this.BbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbButton.ForeColor = System.Drawing.Color.White;
            this.BbButton.Location = new System.Drawing.Point(0, 230);
            this.BbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BbButton.Name = "BbButton";
            this.BbButton.Size = new System.Drawing.Size(334, 59);
            this.BbButton.TabIndex = 6;
            this.BbButton.Text = "     Borrow Book";
            this.BbButton.UseVisualStyleBackColor = false;
            this.BbButton.Click += new System.EventHandler(this.BbButton_Click);
            // 
            // DbButton
            // 
            this.DbButton.BackColor = System.Drawing.Color.Transparent;
            this.DbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DbButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.DbButton.FlatAppearance.BorderSize = 0;
            this.DbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbButton.ForeColor = System.Drawing.Color.White;
            this.DbButton.Location = new System.Drawing.Point(-3, 172);
            this.DbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DbButton.Name = "DbButton";
            this.DbButton.Size = new System.Drawing.Size(338, 59);
            this.DbButton.TabIndex = 2;
            this.DbButton.Text = "Dashboard";
            this.DbButton.UseVisualStyleBackColor = false;
            this.DbButton.Click += new System.EventHandler(this.DbButton_Click);
            // 
            // MuButton
            // 
            this.MuButton.BackColor = System.Drawing.Color.Transparent;
            this.MuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MuButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MuButton.FlatAppearance.BorderSize = 0;
            this.MuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuButton.ForeColor = System.Drawing.Color.White;
            this.MuButton.Location = new System.Drawing.Point(-3, 456);
            this.MuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MuButton.Name = "MuButton";
            this.MuButton.Size = new System.Drawing.Size(334, 59);
            this.MuButton.TabIndex = 10;
            this.MuButton.Text = "     Manage User";
            this.MuButton.UseVisualStyleBackColor = false;
            this.MuButton.Click += new System.EventHandler(this.MuButton_Click);
            // 
            // BiButton
            // 
            this.BiButton.BackColor = System.Drawing.Color.Transparent;
            this.BiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BiButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BiButton.FlatAppearance.BorderSize = 0;
            this.BiButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BiButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BiButton.ForeColor = System.Drawing.Color.White;
            this.BiButton.Location = new System.Drawing.Point(-3, 400);
            this.BiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BiButton.Name = "BiButton";
            this.BiButton.Size = new System.Drawing.Size(334, 59);
            this.BiButton.TabIndex = 9;
            this.BiButton.Text = "     Book Inventory";
            this.BiButton.UseVisualStyleBackColor = false;
            this.BiButton.Click += new System.EventHandler(this.BiButton_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.LogoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.LogoutBtn.FlatAppearance.BorderSize = 0;
            this.LogoutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LogoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.Color.White;
            this.LogoutBtn.Location = new System.Drawing.Point(-3, 618);
            this.LogoutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(331, 46);
            this.LogoutBtn.TabIndex = 5;
            this.LogoutBtn.Text = "   Log Out";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 11;
            // 
            // dashMain1
            // 
            this.dashMain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dashMain1.Location = new System.Drawing.Point(331, 0);
            this.dashMain1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dashMain1.Name = "dashMain1";
            this.dashMain1.Size = new System.Drawing.Size(930, 664);
            this.dashMain1.TabIndex = 7;
            this.dashMain1.Load += new System.EventHandler(this.dashMain1_Load);
            // 
            // borrowBook1
            // 
            this.borrowBook1.BackColor = System.Drawing.Color.AliceBlue;
            this.borrowBook1.Location = new System.Drawing.Point(331, 0);
            this.borrowBook1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.borrowBook1.Name = "borrowBook1";
            this.borrowBook1.Size = new System.Drawing.Size(924, 664);
            this.borrowBook1.TabIndex = 6;
            // 
            // returnbook1
            // 
            this.returnbook1.BackColor = System.Drawing.Color.AliceBlue;
            this.returnbook1.Location = new System.Drawing.Point(331, 0);
            this.returnbook1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnbook1.Name = "returnbook1";
            this.returnbook1.Size = new System.Drawing.Size(924, 664);
            this.returnbook1.TabIndex = 5;
            // 
            // borrowingHistory1
            // 
            this.borrowingHistory1.BackColor = System.Drawing.Color.AliceBlue;
            this.borrowingHistory1.Location = new System.Drawing.Point(331, 0);
            this.borrowingHistory1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.borrowingHistory1.Name = "borrowingHistory1";
            this.borrowingHistory1.Size = new System.Drawing.Size(924, 664);
            this.borrowingHistory1.TabIndex = 4;
            // 
            // issueBook1
            // 
            this.issueBook1.BackColor = System.Drawing.Color.AliceBlue;
            this.issueBook1.Location = new System.Drawing.Point(331, 0);
            this.issueBook1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.issueBook1.Name = "issueBook1";
            this.issueBook1.Size = new System.Drawing.Size(924, 664);
            this.issueBook1.TabIndex = 3;
            // 
            // userManagement1
            // 
            this.userManagement1.BackColor = System.Drawing.Color.AliceBlue;
            this.userManagement1.Location = new System.Drawing.Point(331, 0);
            this.userManagement1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userManagement1.Name = "userManagement1";
            this.userManagement1.Size = new System.Drawing.Size(924, 664);
            this.userManagement1.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.dashMain1);
            this.Controls.Add(this.borrowBook1);
            this.Controls.Add(this.returnbook1);
            this.Controls.Add(this.borrowingHistory1);
            this.Controls.Add(this.issueBook1);
            this.Controls.Add(this.userManagement1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hontrack : Library Management";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DbButton;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button BhButton;
        private System.Windows.Forms.Button RbButton;
        private System.Windows.Forms.Button BbButton;
        private System.Windows.Forms.Button MuButton;
        private System.Windows.Forms.Button BiButton;
        private Label userLabel;
        private Panel panel1;
        private UserManagement userManagement1;
        private IssueBook issueBook1;
        private BorrowingHistory borrowingHistory1;
        private Returnbook returnbook1;
        private BorrowBook borrowBook1;
        private DashMain dashMain1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
    }
}
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
            this.MuButton = new System.Windows.Forms.Button();
            this.BiButton = new System.Windows.Forms.Button();
            this.BhButton = new System.Windows.Forms.Button();
            this.RbButton = new System.Windows.Forms.Button();
            this.BbButton = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.DbButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dashMain1 = new Hontrack_library.DashMain();
            this.borrowBook1 = new Hontrack_library.BorrowBook();
            this.returnbook1 = new Hontrack_library.Returnbook();
            this.borrowingHistory1 = new Hontrack_library.BorrowingHistory();
            this.issueBook1 = new Hontrack_library.IssueBook();
            this.userManagement1 = new Hontrack_library.UserManagement();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.Controls.Add(this.MuButton);
            this.panel2.Controls.Add(this.BiButton);
            this.panel2.Controls.Add(this.BhButton);
            this.panel2.Controls.Add(this.RbButton);
            this.panel2.Controls.Add(this.BbButton);
            this.panel2.Controls.Add(this.LogoutBtn);
            this.panel2.Controls.Add(this.DbButton);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 664);
            this.panel2.TabIndex = 1;
            // 
            // MuButton
            // 
            this.MuButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.MuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MuButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.MuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.MuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuButton.ForeColor = System.Drawing.Color.White;
            this.MuButton.Location = new System.Drawing.Point(15, 511);
            this.MuButton.Name = "MuButton";
            this.MuButton.Size = new System.Drawing.Size(298, 47);
            this.MuButton.TabIndex = 10;
            this.MuButton.Text = "Manage User";
            this.MuButton.UseVisualStyleBackColor = false;
            this.MuButton.Click += new System.EventHandler(this.MuButton_Click);
            // 
            // BiButton
            // 
            this.BiButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BiButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BiButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BiButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BiButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BiButton.ForeColor = System.Drawing.Color.White;
            this.BiButton.Location = new System.Drawing.Point(15, 446);
            this.BiButton.Name = "BiButton";
            this.BiButton.Size = new System.Drawing.Size(298, 47);
            this.BiButton.TabIndex = 9;
            this.BiButton.Text = "Book Inventory";
            this.BiButton.UseVisualStyleBackColor = false;
            this.BiButton.Click += new System.EventHandler(this.BiButton_Click);
            // 
            // BhButton
            // 
            this.BhButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BhButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BhButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BhButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BhButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BhButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BhButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BhButton.ForeColor = System.Drawing.Color.White;
            this.BhButton.Location = new System.Drawing.Point(15, 376);
            this.BhButton.Name = "BhButton";
            this.BhButton.Size = new System.Drawing.Size(298, 47);
            this.BhButton.TabIndex = 8;
            this.BhButton.Text = "Borrowing History";
            this.BhButton.UseVisualStyleBackColor = false;
            this.BhButton.Click += new System.EventHandler(this.BhButton_Click);
            // 
            // RbButton
            // 
            this.RbButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.RbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.RbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RbButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbButton.ForeColor = System.Drawing.Color.White;
            this.RbButton.Location = new System.Drawing.Point(15, 308);
            this.RbButton.Name = "RbButton";
            this.RbButton.Size = new System.Drawing.Size(298, 47);
            this.RbButton.TabIndex = 7;
            this.RbButton.Text = "Return Book";
            this.RbButton.UseVisualStyleBackColor = false;
            this.RbButton.Click += new System.EventHandler(this.RbButton_Click);
            // 
            // BbButton
            // 
            this.BbButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BbButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbButton.ForeColor = System.Drawing.Color.White;
            this.BbButton.Location = new System.Drawing.Point(15, 238);
            this.BbButton.Name = "BbButton";
            this.BbButton.Size = new System.Drawing.Size(298, 47);
            this.BbButton.TabIndex = 6;
            this.BbButton.Text = "Borrow Book";
            this.BbButton.UseVisualStyleBackColor = false;
            this.BbButton.Click += new System.EventHandler(this.BbButton_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.BackColor = System.Drawing.Color.DarkGray;
            this.LogoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.LogoutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutBtn.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.Color.White;
            this.LogoutBtn.Location = new System.Drawing.Point(15, 589);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(298, 63);
            this.LogoutBtn.TabIndex = 5;
            this.LogoutBtn.Text = "Log Out";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // DbButton
            // 
            this.DbButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.DbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DbButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DbButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.DbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DbButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbButton.ForeColor = System.Drawing.Color.White;
            this.DbButton.Location = new System.Drawing.Point(15, 176);
            this.DbButton.Name = "DbButton";
            this.DbButton.Size = new System.Drawing.Size(298, 47);
            this.DbButton.TabIndex = 2;
            this.DbButton.Text = "Dashboard";
            this.DbButton.UseVisualStyleBackColor = false;
            this.DbButton.Click += new System.EventHandler(this.DbButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Welcome, Admin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.user_1077114;
            this.pictureBox1.Location = new System.Drawing.Point(95, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dashMain1);
            this.panel1.Controls.Add(this.borrowBook1);
            this.panel1.Controls.Add(this.returnbook1);
            this.panel1.Controls.Add(this.borrowingHistory1);
            this.panel1.Controls.Add(this.issueBook1);
            this.panel1.Controls.Add(this.userManagement1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(334, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 664);
            this.panel1.TabIndex = 2;
            // 
            // dashMain1
            // 
            this.dashMain1.Location = new System.Drawing.Point(0, -3);
            this.dashMain1.Name = "dashMain1";
            this.dashMain1.Size = new System.Drawing.Size(924, 664);
            this.dashMain1.TabIndex = 5;
            // 
            // borrowBook1
            // 
            this.borrowBook1.Location = new System.Drawing.Point(0, 0);
            this.borrowBook1.Name = "borrowBook1";
            this.borrowBook1.Size = new System.Drawing.Size(924, 664);
            this.borrowBook1.TabIndex = 4;
            // 
            // returnbook1
            // 
            this.returnbook1.Location = new System.Drawing.Point(0, -3);
            this.returnbook1.Name = "returnbook1";
            this.returnbook1.Size = new System.Drawing.Size(924, 664);
            this.returnbook1.TabIndex = 3;
            // 
            // borrowingHistory1
            // 
            this.borrowingHistory1.Location = new System.Drawing.Point(-3, 0);
            this.borrowingHistory1.Name = "borrowingHistory1";
            this.borrowingHistory1.Size = new System.Drawing.Size(924, 664);
            this.borrowingHistory1.TabIndex = 2;
            // 
            // issueBook1
            // 
            this.issueBook1.Location = new System.Drawing.Point(0, -3);
            this.issueBook1.Name = "issueBook1";
            this.issueBook1.Size = new System.Drawing.Size(924, 667);
            this.issueBook1.TabIndex = 1;
            // 
            // userManagement1
            // 
            this.userManagement1.Location = new System.Drawing.Point(-3, -3);
            this.userManagement1.Name = "userManagement1";
            this.userManagement1.Size = new System.Drawing.Size(924, 664);
            this.userManagement1.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private Panel panel1;
        private BorrowingHistory borrowingHistory1;
        private IssueBook issueBook1;
        private UserManagement userManagement1;
        private DashMain dashMain1;
        private BorrowBook borrowBook1;
        private Returnbook returnbook1;
    }
}
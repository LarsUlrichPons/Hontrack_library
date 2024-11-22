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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Label();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.borrowBook2 = new Hontrack_library.BorrowBook();
            this.returnbook2 = new Hontrack_library.Returnbook();
            this.borrowingHistory2 = new Hontrack_library.BorrowingHistory();
            this.issueBook2 = new Hontrack_library.IssueBook();
            this.userManagement2 = new Hontrack_library.UserManagement();
            this.dashMain1 = new Hontrack_library.DashMain();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.exitbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 36);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "HonTrack: Library Management System";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.AutoSize = true;
            this.exitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.Color.White;
            this.exitbtn.Location = new System.Drawing.Point(1112, 3);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(26, 29);
            this.exitbtn.TabIndex = 0;
            this.exitbtn.Text = "X";
            this.exitbtn.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 594);
            this.panel2.TabIndex = 1;
            // 
            // MuButton
            // 
            this.MuButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.MuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MuButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuButton.ForeColor = System.Drawing.Color.White;
            this.MuButton.Location = new System.Drawing.Point(15, 434);
            this.MuButton.Name = "MuButton";
            this.MuButton.Size = new System.Drawing.Size(203, 47);
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
            this.BiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BiButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BiButton.ForeColor = System.Drawing.Color.White;
            this.BiButton.Location = new System.Drawing.Point(15, 381);
            this.BiButton.Name = "BiButton";
            this.BiButton.Size = new System.Drawing.Size(203, 47);
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
            this.BhButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BhButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BhButton.ForeColor = System.Drawing.Color.White;
            this.BhButton.Location = new System.Drawing.Point(15, 328);
            this.BhButton.Name = "BhButton";
            this.BhButton.Size = new System.Drawing.Size(203, 47);
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
            this.RbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RbButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbButton.ForeColor = System.Drawing.Color.White;
            this.RbButton.Location = new System.Drawing.Point(15, 275);
            this.RbButton.Name = "RbButton";
            this.RbButton.Size = new System.Drawing.Size(203, 47);
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
            this.BbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BbButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbButton.ForeColor = System.Drawing.Color.White;
            this.BbButton.Location = new System.Drawing.Point(15, 222);
            this.BbButton.Name = "BbButton";
            this.BbButton.Size = new System.Drawing.Size(203, 47);
            this.BbButton.TabIndex = 6;
            this.BbButton.Text = "Borrow Book";
            this.BbButton.UseVisualStyleBackColor = false;
            this.BbButton.Click += new System.EventHandler(this.BbButton_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.BackColor = System.Drawing.Color.Red;
            this.LogoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.LogoutBtn.FlatAppearance.BorderSize = 2;
            this.LogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutBtn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.Color.White;
            this.LogoutBtn.Location = new System.Drawing.Point(15, 533);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(203, 48);
            this.LogoutBtn.TabIndex = 5;
            this.LogoutBtn.Text = "LogOut";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // DbButton
            // 
            this.DbButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.DbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DbButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DbButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbButton.ForeColor = System.Drawing.Color.White;
            this.DbButton.Location = new System.Drawing.Point(15, 169);
            this.DbButton.Name = "DbButton";
            this.DbButton.Size = new System.Drawing.Size(203, 47);
            this.DbButton.TabIndex = 2;
            this.DbButton.Text = "Dashboard";
            this.DbButton.UseVisualStyleBackColor = false;
            this.DbButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Welcome, Admin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.umaklogo1;
            this.pictureBox1.Location = new System.Drawing.Point(59, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dashMain1);
            this.panel3.Controls.Add(this.borrowBook2);
            this.panel3.Controls.Add(this.returnbook2);
            this.panel3.Controls.Add(this.borrowingHistory2);
            this.panel3.Controls.Add(this.issueBook2);
            this.panel3.Controls.Add(this.userManagement2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(249, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(901, 594);
            this.panel3.TabIndex = 2;
            // 
            // borrowBook2
            // 
            this.borrowBook2.Location = new System.Drawing.Point(0, 0);
            this.borrowBook2.Name = "borrowBook2";
            this.borrowBook2.Size = new System.Drawing.Size(901, 594);
            this.borrowBook2.TabIndex = 4;
            // 
            // returnbook2
            // 
            this.returnbook2.Location = new System.Drawing.Point(0, 0);
            this.returnbook2.Name = "returnbook2";
            this.returnbook2.Size = new System.Drawing.Size(901, 594);
            this.returnbook2.TabIndex = 3;
            // 
            // borrowingHistory2
            // 
            this.borrowingHistory2.Location = new System.Drawing.Point(0, 0);
            this.borrowingHistory2.Name = "borrowingHistory2";
            this.borrowingHistory2.Size = new System.Drawing.Size(901, 594);
            this.borrowingHistory2.TabIndex = 2;
            // 
            // issueBook2
            // 
            this.issueBook2.Location = new System.Drawing.Point(0, 0);
            this.issueBook2.Name = "issueBook2";
            this.issueBook2.Size = new System.Drawing.Size(901, 594);
            this.issueBook2.TabIndex = 1;
            // 
            // userManagement2
            // 
            this.userManagement2.Location = new System.Drawing.Point(3, 3);
            this.userManagement2.Name = "userManagement2";
            this.userManagement2.Size = new System.Drawing.Size(895, 588);
            this.userManagement2.TabIndex = 0;
            // 
            // dashMain1
            // 
            this.dashMain1.Location = new System.Drawing.Point(0, 0);
            this.dashMain1.Name = "dashMain1";
            this.dashMain1.Size = new System.Drawing.Size(901, 594);
            this.dashMain1.TabIndex = 5;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 630);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label exitbtn;
        private System.Windows.Forms.Label label2;
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
      
        private System.Windows.Forms.Panel panel3;
        private BorrowBook borrowBook2;
        private Returnbook returnbook2;
        private BorrowingHistory borrowingHistory2;
        private IssueBook issueBook2;
        private UserManagement userManagement2;
        private DashMain dashMain1;
    }
}
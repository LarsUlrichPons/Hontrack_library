namespace Hontrack_library
{
    partial class EmDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.BhButton = new System.Windows.Forms.Button();
            this.RbButton = new System.Windows.Forms.Button();
            this.BbButton = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.DbButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.borrowingHistory1 = new Hontrack_library.BorrowingHistory();
            this.returnbook1 = new Hontrack_library.Returnbook();
            this.borrowBook1 = new Hontrack_library.BorrowBook();
            this.dashMain1 = new Hontrack_library.DashMain();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.BhButton);
            this.panel2.Controls.Add(this.RbButton);
            this.panel2.Controls.Add(this.BbButton);
            this.panel2.Controls.Add(this.LogoutBtn);
            this.panel2.Controls.Add(this.DbButton);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 664);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.userLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 175);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.user_1077114;
            this.pictureBox1.Location = new System.Drawing.Point(91, 9);
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
            this.userLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.userLabel.Location = new System.Drawing.Point(54, 141);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(105, 29);
            this.userLabel.TabIndex = 8;
            this.userLabel.Text = "Welcome,";
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
            this.BhButton.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.BhButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.BhButton.Location = new System.Drawing.Point(-3, 390);
            this.BhButton.Name = "BhButton";
            this.BhButton.Size = new System.Drawing.Size(340, 76);
            this.BhButton.TabIndex = 8;
            this.BhButton.Text = "Borrowing History";
            this.BhButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BhButton.UseVisualStyleBackColor = false;
            this.BhButton.Click += new System.EventHandler(this.BhButton_Click);
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
            this.RbButton.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.RbButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.RbButton.Location = new System.Drawing.Point(0, 308);
            this.RbButton.Name = "RbButton";
            this.RbButton.Size = new System.Drawing.Size(334, 76);
            this.RbButton.TabIndex = 7;
            this.RbButton.Text = "Return Book";
            this.RbButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RbButton.UseVisualStyleBackColor = false;
            this.RbButton.Click += new System.EventHandler(this.RbButton_Click);
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
            this.BbButton.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.BbButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.BbButton.Location = new System.Drawing.Point(0, 244);
            this.BbButton.Name = "BbButton";
            this.BbButton.Size = new System.Drawing.Size(334, 78);
            this.BbButton.TabIndex = 6;
            this.BbButton.Text = "Borrow Book";
            this.BbButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BbButton.UseVisualStyleBackColor = false;
            this.BbButton.Click += new System.EventHandler(this.BbButton_Click);
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
            this.LogoutBtn.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.LogoutBtn.Location = new System.Drawing.Point(0, 585);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(334, 93);
            this.LogoutBtn.TabIndex = 5;
            this.LogoutBtn.Text = "Log Out";
            this.LogoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
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
            this.DbButton.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.DbButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.DbButton.Location = new System.Drawing.Point(-3, 173);
            this.DbButton.Name = "DbButton";
            this.DbButton.Size = new System.Drawing.Size(340, 76);
            this.DbButton.TabIndex = 2;
            this.DbButton.Text = "Dashboard";
            this.DbButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DbButton.UseVisualStyleBackColor = false;
            this.DbButton.Click += new System.EventHandler(this.DbButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 11;
            // 
            // borrowingHistory1
            // 
            this.borrowingHistory1.BackColor = System.Drawing.Color.AliceBlue;
            this.borrowingHistory1.Location = new System.Drawing.Point(331, 0);
            this.borrowingHistory1.Name = "borrowingHistory1";
            this.borrowingHistory1.Size = new System.Drawing.Size(924, 664);
            this.borrowingHistory1.TabIndex = 3;
            // 
            // returnbook1
            // 
            this.returnbook1.BackColor = System.Drawing.Color.AliceBlue;
            this.returnbook1.Location = new System.Drawing.Point(331, 0);
            this.returnbook1.Name = "returnbook1";
            this.returnbook1.Size = new System.Drawing.Size(924, 664);
            this.returnbook1.TabIndex = 4;
            // 
            // borrowBook1
            // 
            this.borrowBook1.BackColor = System.Drawing.Color.AliceBlue;
            this.borrowBook1.Location = new System.Drawing.Point(331, 0);
            this.borrowBook1.Name = "borrowBook1";
            this.borrowBook1.Size = new System.Drawing.Size(924, 664);
            this.borrowBook1.TabIndex = 5;
            // 
            // dashMain1
            // 
            this.dashMain1.BackColor = System.Drawing.Color.AliceBlue;
            this.dashMain1.Location = new System.Drawing.Point(331, 0);
            this.dashMain1.Name = "dashMain1";
            this.dashMain1.Size = new System.Drawing.Size(924, 664);
            this.dashMain1.TabIndex = 6;
            // 
            // EmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.dashMain1);
            this.Controls.Add(this.borrowBook1);
            this.Controls.Add(this.returnbook1);
            this.Controls.Add(this.borrowingHistory1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hontrack: Library Management";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button BhButton;
        private System.Windows.Forms.Button RbButton;
        private System.Windows.Forms.Button BbButton;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button DbButton;
        private System.Windows.Forms.Label label3;
        private BorrowingHistory borrowingHistory1;
        private Returnbook returnbook1;
        private BorrowBook borrowBook1;
        private DashMain dashMain1;
    }
}
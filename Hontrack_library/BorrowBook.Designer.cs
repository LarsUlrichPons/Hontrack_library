namespace Hontrack_library
{
    partial class BorrowBook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Status = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.BorrowButton = new System.Windows.Forms.Button();
            this.AuthotTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BIssueTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BookTitleTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CameraBtn = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.ComboBox();
            this.CameraFrame = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "Return",
            "Not Return"});
            this.Status.Location = new System.Drawing.Point(106, 431);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(197, 28);
            this.Status.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "Status:";
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(167, 489);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(124, 55);
            this.ClearBtn.TabIndex = 16;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // BorrowButton
            // 
            this.BorrowButton.BackColor = System.Drawing.Color.SeaGreen;
            this.BorrowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BorrowButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowButton.ForeColor = System.Drawing.Color.White;
            this.BorrowButton.Location = new System.Drawing.Point(11, 489);
            this.BorrowButton.Name = "BorrowButton";
            this.BorrowButton.Size = new System.Drawing.Size(124, 55);
            this.BorrowButton.TabIndex = 15;
            this.BorrowButton.Text = "Borrow";
            this.BorrowButton.UseVisualStyleBackColor = false;
            // 
            // AuthotTextBox
            // 
            this.AuthotTextBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthotTextBox.Location = new System.Drawing.Point(106, 390);
            this.AuthotTextBox.Name = "AuthotTextBox";
            this.AuthotTextBox.Size = new System.Drawing.Size(197, 32);
            this.AuthotTextBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Author:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 12;
            // 
            // BIssueTextBox
            // 
            this.BIssueTextBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIssueTextBox.Location = new System.Drawing.Point(106, 352);
            this.BIssueTextBox.Name = "BIssueTextBox";
            this.BIssueTextBox.Size = new System.Drawing.Size(197, 32);
            this.BIssueTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Book Issued:";
            // 
            // BookTitleTextBox
            // 
            this.BookTitleTextBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookTitleTextBox.Location = new System.Drawing.Point(106, 314);
            this.BookTitleTextBox.Name = "BookTitleTextBox";
            this.BookTitleTextBox.Size = new System.Drawing.Size(197, 32);
            this.BookTitleTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Book Title:";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTextBox.Location = new System.Drawing.Point(106, 272);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(197, 32);
            this.IDTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issue ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Issued Books";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(350, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 567);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Status);
            this.panel1.Controls.Add(this.CameraBtn);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.Camera);
            this.panel1.Controls.Add(this.ClearBtn);
            this.panel1.Controls.Add(this.CameraFrame);
            this.panel1.Controls.Add(this.BorrowButton);
            this.panel1.Controls.Add(this.AuthotTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.BIssueTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.BookTitleTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.IDTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(23, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 567);
            this.panel1.TabIndex = 2;
            // 
            // CameraBtn
            // 
            this.CameraBtn.Location = new System.Drawing.Point(216, 201);
            this.CameraBtn.Name = "CameraBtn";
            this.CameraBtn.Size = new System.Drawing.Size(75, 33);
            this.CameraBtn.TabIndex = 2;
            this.CameraBtn.Text = "Start";
            this.CameraBtn.UseVisualStyleBackColor = true;
            this.CameraBtn.Click += new System.EventHandler(this.CameraBtn_Click);
            // 
            // Camera
            // 
            this.Camera.FormattingEnabled = true;
            this.Camera.Location = new System.Drawing.Point(11, 204);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(179, 28);
            this.Camera.TabIndex = 2;
            // 
            // CameraFrame
            // 
            this.CameraFrame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CameraFrame.Location = new System.Drawing.Point(11, 12);
            this.CameraFrame.Name = "CameraFrame";
            this.CameraFrame.Size = new System.Drawing.Size(292, 183);
            this.CameraFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CameraFrame.TabIndex = 2;
            this.CameraFrame.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(490, 499);
            this.dataGridView1.TabIndex = 1;
            // 
            // BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BorrowBook";
            this.Size = new System.Drawing.Size(886, 607);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button BorrowButton;
        private System.Windows.Forms.PictureBox CameraFrame;
        private System.Windows.Forms.TextBox AuthotTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BIssueTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BookTitleTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CameraBtn;
        private System.Windows.Forms.ComboBox Camera;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

﻿namespace Hontrack_library
{
    partial class IssueBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Published = new System.Windows.Forms.Label();
            this.publishedDate = new System.Windows.Forms.DateTimePicker();
            this.AddBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bookGenre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bookCondition = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.BQuantityTXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BookNumTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.ComboBox();
            this.CameraFrame = new System.Windows.Forms.PictureBox();
            this.Status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bookTitle = new System.Windows.Forms.TextBox();
            this.author = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Refresh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(388, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 664);
            this.panel1.TabIndex = 0;
            // 
            // Refresh
            // 
            this.Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.Refresh.Image = global::Hontrack_library.Properties.Resources.icons8_refresh_50;
            this.Refresh.Location = new System.Drawing.Point(455, 0);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(77, 70);
            this.Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Refresh.TabIndex = 29;
            this.Refresh.TabStop = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Issued Book";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(532, 590);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(36, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Book Title:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(68, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Author:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Published
            // 
            this.Published.AutoSize = true;
            this.Published.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Published.ForeColor = System.Drawing.Color.White;
            this.Published.Location = new System.Drawing.Point(4, 518);
            this.Published.Name = "Published";
            this.Published.Size = new System.Drawing.Size(111, 18);
            this.Published.TabIndex = 12;
            this.Published.Text = "Published Date:";
            // 
            // publishedDate
            // 
            this.publishedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.publishedDate.Location = new System.Drawing.Point(159, 518);
            this.publishedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.publishedDate.Name = "publishedDate";
            this.publishedDate.Size = new System.Drawing.Size(201, 26);
            this.publishedDate.TabIndex = 13;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(29, 603);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(102, 38);
            this.AddBtn.TabIndex = 14;
            this.AddBtn.Text = "ADD";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.UpdateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpdateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.ForeColor = System.Drawing.Color.White;
            this.UpdateBtn.Location = new System.Drawing.Point(139, 603);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(102, 38);
            this.UpdateBtn.TabIndex = 15;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.bookGenre);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.bookCondition);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.search);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Controls.Add(this.BQuantityTXT);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BookNumTxt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.StartBtn);
            this.panel2.Controls.Add(this.Camera);
            this.panel2.Controls.Add(this.CameraFrame);
            this.panel2.Controls.Add(this.Status);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.bookTitle);
            this.panel2.Controls.Add(this.author);
            this.panel2.Controls.Add(this.UpdateBtn);
            this.panel2.Controls.Add(this.AddBtn);
            this.panel2.Controls.Add(this.publishedDate);
            this.panel2.Controls.Add(this.Published);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 664);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // bookGenre
            // 
            this.bookGenre.Location = new System.Drawing.Point(159, 387);
            this.bookGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookGenre.Multiline = true;
            this.bookGenre.Name = "bookGenre";
            this.bookGenre.Size = new System.Drawing.Size(200, 26);
            this.bookGenre.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(61, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Genre:";
            // 
            // bookCondition
            // 
            this.bookCondition.FormattingEnabled = true;
            this.bookCondition.Items.AddRange(new object[] {
            "New",
            "Good",
            "Fair"});
            this.bookCondition.Location = new System.Drawing.Point(159, 475);
            this.bookCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookCondition.Name = "bookCondition";
            this.bookCondition.Size = new System.Drawing.Size(199, 28);
            this.bookCondition.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(34, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Book Condition";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(284, 211);
            this.search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 38);
            this.search.TabIndex = 28;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(8, 211);
            this.searchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(270, 26);
            this.searchBox.TabIndex = 28;
            // 
            // BQuantityTXT
            // 
            this.BQuantityTXT.Location = new System.Drawing.Point(159, 557);
            this.BQuantityTXT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BQuantityTXT.Name = "BQuantityTXT";
            this.BQuantityTXT.Size = new System.Drawing.Size(200, 26);
            this.BQuantityTXT.TabIndex = 26;
            this.BQuantityTXT.TextChanged += new System.EventHandler(this.BQuantityTXT_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(51, 557);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Quantity:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // BookNumTxt
            // 
            this.BookNumTxt.Location = new System.Drawing.Point(159, 266);
            this.BookNumTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BookNumTxt.Name = "BookNumTxt";
            this.BookNumTxt.Size = new System.Drawing.Size(200, 26);
            this.BookNumTxt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Book Number:";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(284, 164);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 32);
            this.StartBtn.TabIndex = 22;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Camera
            // 
            this.Camera.FormattingEnabled = true;
            this.Camera.Location = new System.Drawing.Point(8, 167);
            this.Camera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(270, 28);
            this.Camera.TabIndex = 2;
            // 
            // CameraFrame
            // 
            this.CameraFrame.BackColor = System.Drawing.Color.Black;
            this.CameraFrame.Dock = System.Windows.Forms.DockStyle.Top;
            this.CameraFrame.Location = new System.Drawing.Point(0, 0);
            this.CameraFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CameraFrame.Name = "CameraFrame";
            this.CameraFrame.Size = new System.Drawing.Size(397, 149);
            this.CameraFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CameraFrame.TabIndex = 2;
            this.CameraFrame.TabStop = false;
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.Status.Location = new System.Drawing.Point(159, 431);
            this.Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(199, 28);
            this.Status.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Status:";
            // 
            // bookTitle
            // 
            this.bookTitle.Location = new System.Drawing.Point(159, 305);
            this.bookTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookTitle.Name = "bookTitle";
            this.bookTitle.Size = new System.Drawing.Size(200, 26);
            this.bookTitle.TabIndex = 19;
            // 
            // author
            // 
            this.author.Location = new System.Drawing.Point(159, 346);
            this.author.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(200, 26);
            this.author.TabIndex = 18;
            // 
            // IssueBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IssueBook";
            this.Size = new System.Drawing.Size(924, 664);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Published;
        private System.Windows.Forms.DateTimePicker publishedDate;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox bookTitle;
        private System.Windows.Forms.TextBox author;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.TextBox BookNumTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.ComboBox Camera;
        private System.Windows.Forms.PictureBox CameraFrame;
        private System.Windows.Forms.TextBox BQuantityTXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox bookCondition;
        private System.Windows.Forms.TextBox bookGenre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox Refresh;
    }
}

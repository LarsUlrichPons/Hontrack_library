namespace Hontrack_library
{
    partial class Returnbook
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NameTXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.borrowDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bookTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReturnDueText = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bookGenre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.Refresh);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(346, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 664);
            this.panel2.TabIndex = 5;
            // 
            // Refresh
            // 
            this.Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.Refresh.Image = global::Hontrack_library.Properties.Resources.icons8_refresh_50;
            this.Refresh.Location = new System.Drawing.Point(499, 0);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(77, 72);
            this.Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Refresh.TabIndex = 29;
            this.Refresh.TabStop = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(576, 590);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Borrow Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Book Number:";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTextBox.Location = new System.Drawing.Point(122, 262);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(182, 32);
            this.IDTextBox.TabIndex = 2;
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.ReturnBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ReturnBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(61)))));
            this.ReturnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBtn.ForeColor = System.Drawing.Color.White;
            this.ReturnBtn.Location = new System.Drawing.Point(29, 526);
            this.ReturnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(114, 55);
            this.ReturnBtn.TabIndex = 15;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = false;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(61)))));
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(191, 526);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(112, 55);
            this.ClearBtn.TabIndex = 16;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(43, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Status:";
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(122, 355);
            this.Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(182, 32);
            this.Status.TabIndex = 19;
            this.Status.TextChanged += new System.EventHandler(this.Status_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(32, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "School ID:";
            // 
            // NameTXT
            // 
            this.NameTXT.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTXT.Location = new System.Drawing.Point(122, 154);
            this.NameTXT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTXT.Name = "NameTXT";
            this.NameTXT.Size = new System.Drawing.Size(182, 32);
            this.NameTXT.TabIndex = 21;
            this.NameTXT.TextChanged += new System.EventHandler(this.NameTXT_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Borrow Date:";
            // 
            // borrowDate
            // 
            this.borrowDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowDate.Location = new System.Drawing.Point(122, 414);
            this.borrowDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.borrowDate.Name = "borrowDate";
            this.borrowDate.Size = new System.Drawing.Size(182, 32);
            this.borrowDate.TabIndex = 24;
            this.borrowDate.TextChanged += new System.EventHandler(this.borrowDate_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "Book Title:";
            // 
            // bookTitle
            // 
            this.bookTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookTitle.Location = new System.Drawing.Point(122, 211);
            this.bookTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookTitle.Name = "bookTitle";
            this.bookTitle.Size = new System.Drawing.Size(182, 32);
            this.bookTitle.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Return Due:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ReturnDueText
            // 
            this.ReturnDueText.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnDueText.Location = new System.Drawing.Point(122, 467);
            this.ReturnDueText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnDueText.Name = "ReturnDueText";
            this.ReturnDueText.Size = new System.Drawing.Size(182, 32);
            this.ReturnDueText.TabIndex = 28;
            this.ReturnDueText.TextChanged += new System.EventHandler(this.ReturnDueText_TextChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(7, 24);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(241, 26);
            this.SearchBox.TabIndex = 24;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.ForeColor = System.Drawing.Color.White;
            this.SearchBtn.Location = new System.Drawing.Point(254, 18);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(90, 38);
            this.SearchBtn.TabIndex = 24;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bookGenre);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.SearchBtn);
            this.panel1.Controls.Add(this.SearchBox);
            this.panel1.Controls.Add(this.ReturnDueText);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.bookTitle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.borrowDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NameTXT);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Status);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ClearBtn);
            this.panel1.Controls.Add(this.ReturnBtn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.IDTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 664);
            this.panel1.TabIndex = 4;
            // 
            // bookGenre
            // 
            this.bookGenre.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookGenre.Location = new System.Drawing.Point(121, 308);
            this.bookGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookGenre.Name = "bookGenre";
            this.bookGenre.Size = new System.Drawing.Size(182, 32);
            this.bookGenre.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(32, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 31;
            this.label9.Text = "Genre:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hontrack_library.Properties.Resources.icons8_sort_32;
            this.pictureBox1.Location = new System.Drawing.Point(427, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Returnbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Returnbook";
            this.Size = new System.Drawing.Size(924, 664);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NameTXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox borrowDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bookTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ReturnDueText;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox bookGenre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox Refresh;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

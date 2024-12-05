using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Hontrack_library
{
    public partial class Dashboard : Form
    {
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";

        public Dashboard()
        {
            InitializeComponent();
            displayUser();
            HighlightActiveButton(DbButton); // Default active button
            this.StartPosition = FormStartPosition.CenterScreen;
        }





        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.StartPosition = FormStartPosition.CenterScreen;
                lForm.Show();
                this.Hide();
            }
        }







        private void DbButton_Click(object sender, EventArgs e)
        {
    dashMain1.Visible = true;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            HighlightActiveButton(DbButton);


        }

        private void BbButton_Click(object sender, EventArgs e)
        {

       dashMain1.Visible = false;
            borrowBook1.Visible = true;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            HighlightActiveButton(BbButton);
        }

        private void RbButton_Click(object sender, EventArgs e)
        {
           dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = true;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            HighlightActiveButton(RbButton);
        

        }

        private void BhButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = true;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            HighlightActiveButton(BhButton);
        }

        private void BiButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = true;
            userManagement1.Visible = false;
            HighlightActiveButton(BiButton);
        }

        private void MuButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = true;
            HighlightActiveButton(MuButton);

            MuButton.BackColor = ColorTranslator.FromHtml("#212529");
        }




        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0); // Fully terminates the application
            }
            else
            {
                e.Cancel = true; // Prevent closing if user chooses "No"
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Dispose of resources here, if necessary
        }


        public void displayUser()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();

                    string selectData = @"
                SELECT username
                FROM tbl_users 
                WHERE deletedate IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Fetch the value from the first column (assumes it's a string)
                                string userId = reader.GetString(0);

                                // Handle null or empty case gracefully
                                if (!string.IsNullOrEmpty(userId))
                                {
                                    userLabel.Text = "Welcome, " + LoginForm.LoggedInUsername + "!";
                                }
                                else
                                {
                                    userLabel.Text = "Welcome, Guest!";
                                }
                            }
                            else
                            {
                                userLabel.Text = "No active users found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void HighlightActiveButton(Button activeButton)
        {
            // Reset styles for all buttons
            foreach (Control ctrl in panel2.Controls) // Assuming all buttons are in 'panel2'
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(39, 43, 47); // Default background color
                    btn.ForeColor = Color.White; // Default text color
                }
            }

            // Highlight the active button
            activeButton.BackColor = Color.FromArgb(33, 37, 41); // Active background color
            activeButton.ForeColor = Color.White; // Text color remains white
        }



        private void userLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dashMain1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

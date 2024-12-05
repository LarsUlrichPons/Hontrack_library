using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hontrack_library
{
    public partial class LoginForm : Form
    {
        private string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        public static string LoggedInUsername { get; private set; } // Static property to store username


        public LoginForm()
        {
            InitializeComponent();
            PasswordInput.PasswordChar = '*'; // Mask the password input
        }

        // Allow Enter key to trigger login
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                loginButton_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameInput.Text) || string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                MessageBox.Show("Please fill in the blank fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection mysql = new MySqlConnection(connect))
            {
                try
                {
                    mysql.Open();
                    string query = "SELECT * FROM `tbl_users` WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, mysql))
                    {
                        cmd.Parameters.AddWithValue("@username", UsernameInput.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", PasswordInput.Text.Trim()); // TODO: Hash password

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userType = reader["usertype"]?.ToString()?.Trim();
                                string username = reader["username"]?.ToString()?.Trim();
                                string status = reader["accountStatus"].ToString()?.Trim();


                                LoggedInUsername = username; // Store the logged-in username

                                if (status == "Suspended")
                                {
                                    MessageBox.Show("Your account has been suspended. Please contact the administrator.", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Handle user types
                                if (userType == "Librarian")
                                {
                                    MessageBox.Show($"Welcome, {username} Librarian!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Dashboard dashboard = new Dashboard();
                                    dashboard.Show();
                                    this.Hide();
                                }
                                else if (userType == "Staff")
                                {
                                    MessageBox.Show($"Welcome, {username} Staff!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EmDashboard emDashboard = new EmDashboard();
                                    emDashboard.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showpass_CheckedChanged_1(object sender, EventArgs e)
        {
            PasswordInput.PasswordChar = showpass.Checked ? '\0' : '*';

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

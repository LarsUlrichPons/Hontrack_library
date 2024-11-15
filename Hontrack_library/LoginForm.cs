using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hontrack_library
{
    public partial class LoginForm : Form
    {
        string connect = "server=127.0.0.1; user = root; database = hontrack; password=";

        public LoginForm()
        {
            InitializeComponent();
            PasswordInput.PasswordChar = '*';
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            PasswordInput.PasswordChar = showpass.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize MySQL connection
            MySqlConnection mysql = new MySqlConnection(connect);

            // Check if username and password fields are not empty
            if (string.IsNullOrWhiteSpace(UsernameInput.Text) || string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                MessageBox.Show("Please fill in the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the connection
                mysql.Open();

                // Define the query to check the username and password
                string selectData = "SELECT * FROM `users` WHERE username = @username AND password = @password";

                // Set up the command with parameters to avoid SQL injection
                using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                {
                    cmd.Parameters.AddWithValue("@username", UsernameInput.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", PasswordInput.Text.Trim());

                    // Execute the query and get the results
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable Table = new DataTable();
                    adapter.Fill(Table);

                    // Check if any row matches the username and password
                    if (Table.Rows.Count >= 1)
                    {
                        string userType = Table.Rows[0]["usertype"].ToString().Trim();

                        if (userType == "Administrator")
                        {
                            MessageBox.Show("Login successfully as Admin!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else if (userType == "Employee")
                        {
                            MessageBox.Show("Login successfully as Employee!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmDashboard emd = new EmDashboard();
                            emd.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password, please try again!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                mysql.Close();
            }
        }
    }
}

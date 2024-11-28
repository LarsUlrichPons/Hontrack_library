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
            if (UsernameInput == null || PasswordInput == null)
            {
                MessageBox.Show("UI components are not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(UsernameInput.Text) || string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                MessageBox.Show("Please fill in the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection mysql = new MySqlConnection(connect);

            try
            {
                mysql.Open();

                string selectData = "SELECT * FROM `users` WHERE username = @username AND password = @password";

                using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                {
                    cmd.Parameters.AddWithValue("@username", UsernameInput.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", PasswordInput.Text.Trim());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable Table = new DataTable();
                    adapter.Fill(Table);

                    if (Table.Rows.Count >= 1)
                    {
                        string userType = Table.Rows[0]["usertype"]?.ToString()?.Trim();
                        if (userType == "Administrator")
                        {
                            MessageBox.Show("Login successfully as Admin!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dashboard dashboard = new Dashboard();
                            dashboard?.Show();
                            this.Hide();
                        }
                        else if (userType == "Employee")
                        {
                            MessageBox.Show("Login successfully as Employee!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmDashboard emd = new EmDashboard();
                            emd?.Show();
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
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Null Reference Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mysql.Close();
            }
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

    }
}

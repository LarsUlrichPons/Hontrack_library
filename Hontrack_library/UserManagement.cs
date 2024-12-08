using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;


namespace Hontrack_library
{
    public partial class UserManagement : UserControl
    {
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private Timer refreshTimer; // Declare Timer here


        public UserManagement()
        {
            InitializeComponent();
            displayEmployeeData();
            addEmployee_Pass.PasswordChar = '\0';

            addEmployee_UT.DropDownStyle = ComboBoxStyle.DropDownList;

            addEmployee_id.ReadOnly = true;
            addEmployee_ST.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Refresh the book data every second
            displayEmployeeData();
        }
        public void displayEmployeeData()
        {
            EmployeeData employeeData = new EmployeeData();
            List<EmployeeData> listdata = employeeData.GetEmployeeListData();
            dataGridView1.DataSource = listdata;

            // Customizing DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Header styling
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Row styling
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Padding = new Padding(5);

            // Borders and grid lines
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Gray;

            // Disable extra rows
            dataGridView1.AllowUserToAddRows = false;

            // Ensure correct column headers
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Full Name";
            dataGridView1.Columns[2].HeaderText = "User Name";
            dataGridView1.Columns[3].HeaderText = "Password";
            dataGridView1.Columns[4].HeaderText = "User Type";
          

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            if (dataGridView1.Rows.Count > 0) // Ensure rows exist
            {
                dataGridView1.Rows[0].Cells["usertype"].ReadOnly = true; // Set the cell to read-only
                dataGridView1.Rows[0].Cells["usertype"].Style.BackColor = Color.LightGray; // Optional: Indicate read-only visually
                dataGridView1.Rows[0].Cells["usertype"].Style.ForeColor = Color.DarkGray;
            }


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                addEmployee_id.Text = row.Cells[0].Value.ToString();
                addEmployee_FN.Text = row.Cells[1].Value.ToString();
                addEmployee_UN.Text = row.Cells[2].Value.ToString();
                addEmployee_Pass.Text = row.Cells[3].Value.ToString();
                addEmployee_UT.Text = row.Cells[4].Value.ToString();
                addEmployee_ST.Text = row.Cells[5].Value.ToString();
                addEmployee_Pass.PasswordChar = '*';


            }
        }

        private bool ValidatePassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+[\]{};:'"",<>\./?\\|]).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        private bool ValidateUsername(string username)
        {
            // Check if the username contains spaces
            if (username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces. Please enter a valid username.", "Username Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the username length is less than 8 or greater than 50 characters
            if (username.Length < 8 || username.Length > 50)
            {
                MessageBox.Show("Username must be between 8 and 50 characters. Please enter a valid username.", "Username Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection(connect);

            if (addEmployee_FN.Text == "" || addEmployee_UN.Text == "" || addEmployee_Pass.Text == "" || addEmployee_UT.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateUsername(addEmployee_UN.Text.Trim()))
            {
                return;
            }

            if (!ValidatePassword(addEmployee_Pass.Text.Trim()))
            {
                MessageBox.Show("Password must be at least 8 characters long and include at least one number, one special character, and one uppercase letter.", "Password Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (mysql.State == ConnectionState.Closed)
                    mysql.Open();

                // Check if the username already exists
                string checkUsername = "SELECT COUNT(*) FROM tbl_users WHERE username = @username";
                
                using (MySqlCommand checkUser = new MySqlCommand(checkUsername, mysql))
                {
                    checkUser.Parameters.AddWithValue("@username", addEmployee_UN.Text.Trim());
                    int countUser = Convert.ToInt32(checkUser.ExecuteScalar());
                    if (countUser >= 1)
                    {
                        MessageBox.Show(addEmployee_UN.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Check if the full name already exists
                string checkFullname = "SELECT COUNT(*) FROM tbl_users WHERE fullname = @fullname";
                using (MySqlCommand checkName = new MySqlCommand(checkFullname, mysql))
                {
                    checkName.Parameters.AddWithValue("@fullname", addEmployee_FN.Text.Trim());
                    int countName = Convert.ToInt32(checkName.ExecuteScalar());
                    if (countName >= 1)
                    {
                        MessageBox.Show(addEmployee_FN.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insert new data
                string insertData = "INSERT INTO tbl_users (fullname, username, password, usertype, accountStatus,insertdate) VALUES (@fullname, @username, @password, @usertype, @status,@insertDate)";

                using (MySqlCommand cmd = new MySqlCommand(insertData, mysql))
                {
                    cmd.Parameters.AddWithValue("@username", addEmployee_UN.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullname", ToProperCase(addEmployee_FN.Text.Trim()));
                    cmd.Parameters.AddWithValue("@password", addEmployee_Pass.Text.Trim());
                    cmd.Parameters.AddWithValue("@usertype", addEmployee_UT.Text.Trim());
                    cmd.Parameters.AddWithValue("@insertDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status",addEmployee_ST.Text.Trim());


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                displayEmployeeData();
                clearfield();
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Step 1: Validate input fields
            if (string.IsNullOrWhiteSpace(addEmployee_FN.Text) ||
                string.IsNullOrWhiteSpace(addEmployee_UN.Text) ||
              
                string.IsNullOrWhiteSpace(addEmployee_UT.Text))
            {
                MessageBox.Show("Please fill all blank fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate username
            if (!ValidateUsername(addEmployee_UN.Text.Trim()))
            {
                return;
            }

            // Validate password
            if (!ValidatePassword(addEmployee_Pass.Text.Trim()))
            {
                MessageBox.Show("Password must be at least 8 characters long and include at least one number, one special character, and one uppercase letter.",
                                "Password Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent modification of the first record's user type
            if (dataGridView1.Rows.Count > 0 &&
                dataGridView1.Rows[0].Cells["fullname"].Value.ToString() == addEmployee_FN.Text.Trim())
            {
                MessageBox.Show("The user type for the first record cannot be modified.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 2: Prompt for admin password
          
            using (AdminPasswordPrompt passwordPrompt = new AdminPasswordPrompt())
            {
                if (passwordPrompt.ShowDialog() == DialogResult.OK)
                {
                    string adminPassword = passwordPrompt.AdminPassword;

                    // Step 3: Validate admin password
                    try
                    {
                        using (MySqlConnection mysql = new MySqlConnection(connect))
                        {
                            mysql.Open();

                            string query = "SELECT password FROM tbl_users WHERE username = @username AND usertype = 'Librarian'";
                            using (MySqlCommand cmd = new MySqlCommand(query, mysql))
                            {
                                cmd.Parameters.AddWithValue("@username", LoginForm.LoggedInUsername); // Use the logged-in admin's username

                                string storedPassword = cmd.ExecuteScalar()?.ToString();

                                if (storedPassword == null)
                                {
                                    MessageBox.Show("Admin user not found. Update operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (adminPassword != storedPassword)
                                {
                                    MessageBox.Show("Invalid admin password. Update operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }


                            // Step 4: Update user data
                            string updatedata = "UPDATE tbl_users SET fullname = @fullname, username = @username, password = @password, usertype = @usertype, updatedate = @updateDate,accountStatus = @accountStatus WHERE ID = @ID";
                            using (MySqlCommand cmd = new MySqlCommand(updatedata, mysql))
                            {
                                cmd.Parameters.AddWithValue("@ID", addEmployee_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@fullname", ToProperCase(addEmployee_FN.Text.Trim()));
                                cmd.Parameters.AddWithValue("@username", addEmployee_UN.Text.Trim());

                                // Directly store the password in plain text
                                cmd.Parameters.AddWithValue("@password", addEmployee_Pass.Text.Trim());

                                cmd.Parameters.AddWithValue("@usertype", addEmployee_UT.Text.Trim());
                                cmd.Parameters.AddWithValue("@accountStatus", addEmployee_ST.Text.Trim());

                                cmd.Parameters.AddWithValue("@updateDate", DateTime.Now);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Step 5: Notify success and refresh data
                        MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayEmployeeData();
                        clearfield();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

   

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Refresh data instantly
                displayEmployeeData();
                MessageBox.Show("Data refreshed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearfield();
        }


        public void clearfield() 
        {
            addEmployee_id.Clear();
            addEmployee_FN.Clear();
            addEmployee_Pass.Clear();
            addEmployee_UN.Clear();
            addEmployee_UT.SelectedIndex = -1;
            addEmployee_ST.SelectedIndex = -1;
            addEmployee_Pass.PasswordChar = '\0';

        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearfield();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addEmployee_id_TextChanged(object sender, EventArgs e)
        {

        }


        private string ToProperCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null) 
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

      
    }
}

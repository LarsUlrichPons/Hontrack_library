using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace Hontrack_library
{
    public partial class BorrowBook : UserControl
    {
       
       
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private Timer refreshTimer; // Declare Timer here

        public BorrowBook()
        {
            InitializeComponent();

            displayBookData();


            // Initialize and start the timer to refresh every 1 second
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // 1 second
            refreshTimer.Tick += RefreshTimer_Tick; // Event handler

            IDTextBox.ReadOnly = true;
            BookTitle.ReadOnly = true;
            Author.ReadOnly = true;
            BQuantity.ReadOnly = true;
            Status.ReadOnly = true;
           
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Refresh the book data every second
            displayBookData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            IDTextBox.Clear();
            BookTitle.Clear();
            Author.Clear();
        }

     

      
        public void displayBookData()
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();
            dataGridView1.Refresh();
            dataGridView1.DataSource = listdata;

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
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Book Number";
            dataGridView1.Columns[3].HeaderText = "Author";
            dataGridView1.Columns[4].HeaderText = "Published";
            dataGridView1.Columns[5].HeaderText = "Status";
            dataGridView1.Columns[6].HeaderText = "Quantity";


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private int BookID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                BookTitle.Text = row.Cells[1].Value.ToString();
                IDTextBox.Text = row.Cells[2].Value.ToString();
               
                Author.Text = row.Cells[3].Value.ToString();
                BQuantity.Text = row.Cells[6].Value.ToString();
                Status.Text = row.Cells[5].Value.ToString();
            }
        }

        public void clearField()
        {
            BookTitle.Clear();
            Author.Clear();
            Status.Clear();
            IDTextBox.Clear();
            BQuantity.Clear();
            NameTXT.Clear();
            SearchBox.Clear();
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            if (BookTitle.Text == "" || Author.Text == "" || IDTextBox.Text == "" || NameTXT.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to borrow Book Title: " + BookTitle.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connect))
                    {
                        MySqlTransaction transaction = null;
                        try
                        {
                            conn.Open();
                            transaction = conn.BeginTransaction();

                            // Retrieve the current book stock and status from the database
                            string getStockQuery = "SELECT book_stock, status FROM book WHERE book_num = @book_num";
                            MySqlCommand getStockCmd = new MySqlCommand(getStockQuery, conn, transaction);
                            getStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                            using (MySqlDataReader reader = getStockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = reader.GetInt32("book_stock");
                                    string currentStatus = reader.GetString("status");

                                    if (currentStock > 0 && currentStatus != "Unavailable")
                                    {
                                        // Deduct one from the stock
                                        int newStock = currentStock - 1;

                                        // Close the reader before executing the update command
                                        reader.Close();

                                        // Update the book stock in the database
                                        string updateStockQuery = "UPDATE book SET book_stock = @newStock WHERE book_num = @book_num";
                                        MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn, transaction);
                                        updateStockCmd.Parameters.AddWithValue("@newStock", newStock);
                                        updateStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        updateStockCmd.ExecuteNonQuery();

                                        // If the stock reaches zero, set the status to 'Unavailable'
                                        if (newStock == 0)
                                        {
                                            string updateStatusQuery = "UPDATE book SET status = 'Unavailable' WHERE book_num = @book_num";
                                            MySqlCommand updateStatusCmd = new MySqlCommand(updateStatusQuery, conn, transaction);
                                            updateStatusCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                                            updateStatusCmd.ExecuteNonQuery();
                                        }

                                        // Insert the transaction into the book_transaction table
                                        string insertTransactionQuery = @"
    INSERT INTO book_transactions (bookTitle, book_num, issue_date, status, user_name, borrow_date,return_due)
    VALUES (@bookTitle, @book_num, NOW(), 'Borrowed', @user_name, NOW(), @return_due)";

                                        MySqlCommand insertTransactionCmd = new MySqlCommand(insertTransactionQuery, conn, transaction);
                                        insertTransactionCmd.Parameters.AddWithValue("@bookTitle", BookTitle.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@user_name", NameTXT.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@return_due", ReturnDue.Value);

                                        insertTransactionCmd.ExecuteNonQuery();

                                        // Commit the transaction
                                        transaction.Commit();

                                        // Show success message
                                        MessageBox.Show("Book borrowed successfully! Remaining stock: " + newStock, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        reader.Close();

                                        // If the stock is 0 or the status is unavailable, show an error
                                        MessageBox.Show("Sorry, this book is out of stock and marked as 'Unavailable'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error: Book not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Refresh the book data in the DataGridView to reflect updated stock/status
                    displayBookData();
                    clearField();
                }
                else
                {
                    MessageBox.Show("Borrow operation canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Refresh data instantly
                displayBookData();
              
                MessageBox.Show("Data refreshed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            clearField();
        }

       

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = SearchBox.Text.Trim(); // Assuming you have a TextBox named searchBox
                BookData bookData = new BookData();
                Console.WriteLine("Search Query: " + searchQuery); // Add this to log the search query


                List<BookData> filteredData = bookData.BookListData(
                 searchQuery


                );

                // Refresh the DataGridView
                dataGridView1.Refresh();
                dataGridView1.DataSource = filteredData;

                if (filteredData.Count == 0)
                {
                    MessageBox.Show("No records found for the specified search query.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

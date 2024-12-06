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
    public partial class Returnbook : UserControl
    {
      
        private string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private Timer refreshTimer;

        public Returnbook()
        {
            InitializeComponent();
            displayBookData();


            NameTXT.ReadOnly = true;
            IDTextBox.ReadOnly = true;
            Status.ReadOnly = true;
            borrowDate.ReadOnly = true;
            bookTitle.ReadOnly = true;
            ReturnDueText.ReadOnly = true;
            bookGenre.ReadOnly = true;
            
        }

        
        public void displayBookData()
        {
            borrowedBookData bookData = new borrowedBookData();
            List<borrowedBookData> listdata = bookData.BookListTransaction();

            listdata = listdata.OrderBy(b => b.Borrow).ToList();

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
          //  dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].HeaderText = "School ID";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Book Number";
            dataGridView1.Columns[3].HeaderText = "Genre";
            dataGridView1.Columns[4].HeaderText = "Return Due";
            dataGridView1.Columns[5].HeaderText = "Borrow Date";
            dataGridView1.Columns[6].HeaderText = "Status";


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private int BookID = 0;

        public void clearField()
        {
          
            Status.Clear();
            IDTextBox.Clear();
            NameTXT.Clear();
            borrowDate.Clear();
            bookTitle.Clear();
            ReturnDueText.Clear();
            SearchBox.Clear();
            bookGenre.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
               // BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                NameTXT.Text = row.Cells[0].Value.ToString();
                bookTitle.Text = row.Cells[1].Value.ToString();
                IDTextBox.Text = row.Cells[2].Value.ToString();
                bookGenre.Text = row.Cells[3].Value.ToString();
                borrowDate.Text = row.Cells[4].Value.ToString();
                ReturnDueText.Text = row.Cells[5].Value.ToString();
                Status.Text = row.Cells[6].Value.ToString();
               
                
            }
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            if (IDTextBox.Text == "" || NameTXT.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to return Book ID: " + IDTextBox.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connect))
                    {
                        MySqlTransaction transaction = null;
                        try
                        {
                            conn.Open();
                            transaction = conn.BeginTransaction();

                            // Get book details and current stock
                            string getStockQuery = "SELECT bookStock, bookStatus FROM tbl_book WHERE bookISBN = @book_num";
                            MySqlCommand getStockCmd = new MySqlCommand(getStockQuery, conn, transaction);
                            getStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                            using (MySqlDataReader reader = getStockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = reader.GetInt32("bookStock");
                                    string currentStatus = reader.GetString("BookStatus");

                                    int newStock = currentStock + 1;
                                    reader.Close();

                                    // Update book stock
                                    string updateStockQuery = "UPDATE tbl_book SET bookStock = @newStock WHERE bookISBN = @book_num";
                                    MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn, transaction);
                                    updateStockCmd.Parameters.AddWithValue("@newStock", newStock);
                                    updateStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                    updateStockCmd.ExecuteNonQuery();

                                    // Update status if needed
                                    if (newStock > 0 && currentStatus == "Unavailable")
                                    {
                                        string updateStatusQuery = "UPDATE tbl_book SET bookStatus = 'Available' WHERE bookISBN = @book_num";
                                        MySqlCommand updateStatusCmd = new MySqlCommand(updateStatusQuery, conn, transaction);
                                        updateStatusCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        updateStatusCmd.ExecuteNonQuery();
                                    }

                                    // Update transaction to mark the book as returned
                                    string updateTransactionQuery = "UPDATE tbl_booktransac SET Status = 'Returned', returnDate = NOW() WHERE bookISBN = @book_num AND transac_id = @id";
                                    MySqlCommand updateTransactionCmd = new MySqlCommand(updateTransactionQuery, conn, transaction);
                                    updateTransactionCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                    updateTransactionCmd.Parameters.AddWithValue("@id", BookID);
                                    updateTransactionCmd.ExecuteNonQuery();

                                    transaction.Commit();

                                    // Show success message
                                    MessageBox.Show("Book returned successfully! Remaining stock: " + newStock, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh data and clear fields
                                    displayBookData();
                                    clearField();
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
                }
                else
                {
                    MessageBox.Show("Return operation canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = SearchBox.Text.Trim(); // Assuming you have a TextBox named searchBox
                borrowedBookData bookData = new borrowedBookData();
                Console.WriteLine("Search Query: " + searchQuery); // Add this to log the search query


                List<borrowedBookData> filteredData = bookData.BookListTransaction(
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

        private void NameTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void Status_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click_1(object sender, EventArgs e)
        {
            NameTXT.Clear();
            bookTitle.Clear();
            IDTextBox.Clear();
            Status.Clear();
            borrowDate.Clear();
            ReturnDueText.Clear();
        }

        private void borrowDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReturnDueText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

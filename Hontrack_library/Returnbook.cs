using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using PdfSharp.Snippets;
using System;
using System.Collections.Generic;
using System.Data;
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

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



        }


        public void displayBookData()
        {
            borrowedBookData bookData = new borrowedBookData();
            List<borrowedBookData> listdata = bookData.BookListTransaction();

            listdata = listdata.OrderByDescending(b => b.Borrow).ToList();
            dataGridView1.DataSource = listdata;

            dataGridView1.Refresh();


            // Ensure correct column headers
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "School ID";
            dataGridView1.Columns[2].HeaderText = "Title";
            dataGridView1.Columns[3].HeaderText = "Book Number";
            dataGridView1.Columns[4].HeaderText = "Genre";
            dataGridView1.Columns[5].HeaderText = "Borrow Date";
            dataGridView1.Columns[6].HeaderText = "Return Due";

            dataGridView1.Columns[7].HeaderText = "Status";

            if (dataGridView1.Columns[5] != null || dataGridView1.Columns[6] != null)
            {
                dataGridView1.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            }


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
                 BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                NameTXT.Text = row.Cells[1].Value.ToString();
                bookTitle.Text = row.Cells[2].Value.ToString();
                IDTextBox.Text = row.Cells[3].Value.ToString();
                bookGenre.Text = row.Cells[4].Value.ToString();
                borrowDate.Text = row.Cells[5].Value.ToString();
                ReturnDueText.Text = row.Cells[6].Value.ToString();
                Status.Text = row.Cells[7].Value.ToString();


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
            MySqlConnection conn = new MySqlConnection(connect);

            try
            {
                // Open the connection if it's closed
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    // Create a DataTable to hold the search results
                    using (DataTable dt = new DataTable())
                    {
                        // Correct SQL query with proper WHERE and ORDER BY placement
                        string searchData = @"
                SELECT 
                    transac_id, borrowerID, bookTitle, bookISBN, 
                    bookGenre, borrowDate, returnDue, Status
                FROM tbl_booktransac 
                WHERE (bookISBN LIKE @SearchQuery 
                    OR bookTitle LIKE @SearchQuery 
                    OR borrowerID LIKE @SearchQuery
                    OR bookGenre LIKE @SearchQuery
                    OR Status LIKE @SearchQuery)
                    AND Status = 'Borrowed' -- Ensure we're filtering borrowed books
                ORDER BY borrowDate DESC; -- Order by borrow date for recent entries";

                        // Create the command and add parameters
                        using (MySqlCommand cmd = new MySqlCommand(searchData, conn))
                        {
                            string searchQuery = "%" + SearchBox.Text.Trim() + "%"; // Add wildcards for LIKE search
                            cmd.Parameters.AddWithValue("@SearchQuery", searchQuery); // Use @SearchQuery for all fields

                            // Execute the command and fill the DataTable
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dt;
                            dataGridView1.Refresh();

                            // Set headers and formats (set this globally if possible)
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[1].HeaderText = "School ID";
                            dataGridView1.Columns[2].HeaderText = "Title";
                            dataGridView1.Columns[3].HeaderText = "Book Number";
                            dataGridView1.Columns[4].HeaderText = "Genre";
                            dataGridView1.Columns[5].HeaderText = "Borrow Date";
                            dataGridView1.Columns[6].HeaderText = "Return Due";
                            dataGridView1.Columns[7].HeaderText = "Status";

                            // Format date columns (if present)
                            if (dataGridView1.Columns[5] != null && dataGridView1.Columns[6] != null)
                            {
                                dataGridView1.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
                                dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed properly
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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

        private int rotationAngle = 0;

        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Refresh data instantly
                displayBookData();

                // Update rotation angle
                rotationAngle = (rotationAngle + 90) % 360;

                // Rotate the image and update the PictureBox
                Refresh.Image = RotateImage(Properties.Resources.icons8_refresh_50, rotationAngle);

                //MessageBox.Show("Data refreshed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clearField();
        }

        private Bitmap RotateImage(Image image, float angle)
        {
            // Determine the size of the rotated image
            float offset = Math.Max(image.Width, image.Height) * (float)Math.Sqrt(2); // Diagonal
            Bitmap rotatedImage = new Bitmap((int)offset, (int)offset);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution); // Maintain resolution

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.Clear(Color.Transparent); // Set a transparent background
                g.TranslateTransform(offset / 2, offset / 2); // Move to the center
                g.RotateTransform(angle); // Rotate the image
                g.TranslateTransform(-image.Width / 2, -image.Height / 2); // Move back to original top-left
                g.DrawImage(image, new Point(0, 0)); // Draw the image
            }

            return rotatedImage;
        }

        private bool isAscending = true; // Tracks the current sort order (default to Ascending)

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the book data
                borrowedBookData bookData = new borrowedBookData();
                List<borrowedBookData> listdata = bookData.BookListTransaction();

                // Sort the data based on the current order
                if (isAscending)
                {
                    listdata = listdata.OrderBy(b => b.Borrow).ToList();
                    pictureBox1.Image = Properties.Resources.icons8_sort_32; // Set the image to Descending
                }
                else
                {
                    listdata = listdata.OrderByDescending(b => b.Borrow).ToList();
                    pictureBox1.Image = Properties.Resources.icons8_sort_32__1_; // Set the image to Ascending
                }

                // Toggle the sort order for the next click
                isAscending = !isAscending;

                // Update the DataGridView
                dataGridView1.DataSource = null; // Clear the current data
                dataGridView1.DataSource = listdata; // Bind the sorted list
                dataGridView1.Refresh(); // Refresh the display

                MessageBox.Show("Books sorted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sorting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

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

         

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += RefreshTimer_Tick;

            NameTXT.ReadOnly = true;
            IDTextBox.ReadOnly = true;
            Status.ReadOnly = true;
            borrowDate.ReadOnly = true;
            
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            displayBookData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearField();
        }

      

      

       
       

        public void displayBookData()
        {
            borrowedBookData bookData = new borrowedBookData();
            List<borrowedBookData> listdata = bookData.BookListTransaction();
            dataGridView1.Refresh();
            dataGridView1.DataSource = listdata;
        }


        private int BookID = 0;

        public void clearField()
        {
          
            Status.Clear();
            IDTextBox.Clear();
            NameTXT.Clear();
            borrowDate.Clear();
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

                            string getStockQuery = "SELECT book_stock, status FROM book WHERE book_num = @book_num";
                            MySqlCommand getStockCmd = new MySqlCommand(getStockQuery, conn, transaction);
                            getStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                            using (MySqlDataReader reader = getStockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = reader.GetInt32("book_stock");
                                    string currentStatus = reader.GetString("status");

                                    int newStock = currentStock + 1;
                                    reader.Close();

                                    string updateStockQuery = "UPDATE book SET book_stock = @newStock WHERE book_num = @book_num";
                                    MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn, transaction);
                                    updateStockCmd.Parameters.AddWithValue("@newStock", newStock);
                                    updateStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                    updateStockCmd.ExecuteNonQuery();

                                    if (newStock > 0 && currentStatus == "Unavailable")
                                    {
                                        string updateStatusQuery = "UPDATE book SET status = 'Available' WHERE book_num = @book_num";
                                        MySqlCommand updateStatusCmd = new MySqlCommand(updateStatusQuery, conn, transaction);
                                        updateStatusCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        updateStatusCmd.ExecuteNonQuery();
                                    }

                                    string insertTransactionQuery = "UPDATE book_transactions set status = 'Returned', return_date = NOW()  WHERE book_num = @book_num AND transaction_id = @id";


                                    MySqlCommand insertTransactionCmd = new MySqlCommand(insertTransactionQuery, conn, transaction);
                                    insertTransactionCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                    insertTransactionCmd.Parameters.AddWithValue("@id",BookID);
                                   // insertTransactionCmd.Parameters.AddWithValue("@return_date",DateTime.Now);

                                    // insertTransactionCmd.Parameters.AddWithValue("@borrowed_date", borrowedDate); // Use borrowed date
                                    // insertTransactionCmd.Parameters.AddWithValue("@user_name", NameTXT.Text.Trim());
                                    insertTransactionCmd.ExecuteNonQuery();

                                    transaction.Commit();

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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                IDTextBox.Text = row.Cells[1].Value.ToString();
                NameTXT.Text = row.Cells[2].Value.ToString();
                Status.Text = row.Cells[3].Value.ToString();
                borrowDate.Text = row.Cells[4].Value.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        }
    }
}

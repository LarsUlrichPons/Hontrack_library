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
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private bool isCameraRunning = false;
        private string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private Timer refreshTimer;

        public Returnbook()
        {
            InitializeComponent();
            displayBookData();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filterInfoCollection != null && filterInfoCollection.Count > 0)
            {
                foreach (FilterInfo device in filterInfoCollection)
                {
                    Camera.Items.Add(device.Name);
                }
                Camera.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No camera devices found.");
            }

            this.VisibleChanged += ReturnBook_VisibleChanged;

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            displayBookData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void CameraBtn_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                StartCamera();
            }
            else
            {
                StopCamera();
            }
        }

        private void StartCamera()
        {
            if (filterInfoCollection.Count > 0)
            {
                StopCamera();
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[Camera.SelectedIndex].MonikerString);

                if (videoCaptureDevice.VideoCapabilities.Length > 0)
                {
                    var highestResolution = videoCaptureDevice.VideoCapabilities
                        .OrderByDescending(vc => vc.FrameSize.Width * vc.FrameSize.Height)
                        .First();
                    videoCaptureDevice.VideoResolution = highestResolution;
                }

                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
                isCameraRunning = true;
            }
            else
            {
                MessageBox.Show("No camera selected.");
            }
        }

        private void StopCamera()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                isCameraRunning = false;
            }
        }

        private void ReturnBook_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !isCameraRunning)
            {
                StartCamera();
            }
            else if (!this.Visible && isCameraRunning)
            {
                StopCamera();
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();

            Bitmap resizedBitmap = new Bitmap(bitmap, new Size(640, 480));
            var result = reader.Decode(resizedBitmap);
            if (result != null)
            {
                IDTextBox.Invoke(new MethodInvoker(delegate
                {
                    IDTextBox.Text = result.Text;
                }));
            }
            CameraFrame.Image = resizedBitmap;
        }

        private void BorrowBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        public void displayBookData()
        {
            BookTransaction bookData = new BookTransaction();
            List<BookTransaction> listdata = bookData.BookListTransaction();
            dataGridView1.Refresh();
            dataGridView1.DataSource = listdata;
        }

        private int BookID = 0;

        public void clearField()
        {
          
            Status.Clear();
            IDTextBox.Clear();
            ;
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            if (IDTextBox.Text == "" || NameTXT.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Confirm that the user wants to return the book
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

                            // Retrieve the current book stock and status from the database
                            string getStockQuery = "SELECT book_stock, status FROM book WHERE ID = @book_num";
                            MySqlCommand getStockCmd = new MySqlCommand(getStockQuery, conn, transaction);
                            getStockCmd.Parameters.AddWithValue("@book_num",BookID);

                            using (MySqlDataReader reader = getStockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = reader.GetInt32("book_stock");
                                    string currentStatus = reader.GetString("status");

                                    // Increase the stock by one
                                    int newStock = currentStock + 1;

                                    // Close the reader before executing the update command
                                    reader.Close();

                                    // Update the book stock in the database
                                    string updateStockQuery = "UPDATE book SET book_stock = @newStock WHERE ID = @book_num";
                                    MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn, transaction);
                                    updateStockCmd.Parameters.AddWithValue("@newStock", newStock);
                                    updateStockCmd.Parameters.AddWithValue("@book_num", BookID);
                                    updateStockCmd.ExecuteNonQuery();

                                    // If the stock goes above 0 and the book was unavailable, change the status back to 'Available'
                                    if (newStock > 0 && currentStatus == "Unavailable")
                                    {
                                        string updateStatusQuery = "UPDATE book SET status = 'Available' WHERE ID = @book_num";
                                        MySqlCommand updateStatusCmd = new MySqlCommand(updateStatusQuery, conn, transaction);
                                        updateStatusCmd.Parameters.AddWithValue("@book_num", BookID);                                  
                                        updateStatusCmd.ExecuteNonQuery();
                                    }

                                    // Insert the return transaction into the book_transaction table
                                    string insertTransactionQuery = @"
                            INSERT INTO book_transactions (book_num, issue_date, status, user_name, return_date)
                            VALUES (@book_num, NOW(), 'Returned', @user_name, NOW())";

                                    MySqlCommand insertTransactionCmd = new MySqlCommand(insertTransactionQuery, conn, transaction);
                                    insertTransactionCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                    insertTransactionCmd.Parameters.AddWithValue("@user_name", NameTXT.Text.Trim());
                                    insertTransactionCmd.ExecuteNonQuery();

                                    // Commit the transaction
                                    transaction.Commit();

                                    // Show success message
                                    MessageBox.Show("Book returned successfully! Remaining stock: " + newStock, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

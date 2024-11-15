using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hontrack_library
{
    public partial class IssueBook : UserControl
    {
        // Update connection string for MySQL
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private bool isCameraRunning = false;

        public IssueBook()
        {
            InitializeComponent();
            displayBookData();
            Status.DropDownStyle = ComboBoxStyle.DropDownList;

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

            // Handle form visibility changes
            this.VisibleChanged += BorrowBook_VisibleChanged;
        }

        // Display book data in DataGridView
        public void displayBookData()
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Create columns for each property
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookNumber", HeaderText = "Book Number" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "Book Title" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Author", HeaderText = "Author" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Published", HeaderText = "Published Date" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookQuantity", HeaderText = "Quantity" });  // Add BookQuantity column
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = listdata;
            dataGridView1.Refresh();
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            if (filterInfoCollection.Count > 0)
            {
                // Stop any running camera before starting a new one
                StopCamera();

                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[Camera.SelectedIndex].MonikerString);

                // Set the desired resolution (choose one supported by your camera)
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
                videoCaptureDevice.WaitForStop(); // Ensure camera stops completely
                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                isCameraRunning = false;
            }
        }

        private void BorrowBook_VisibleChanged(object sender, EventArgs e)
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
            if (result != null && !string.IsNullOrEmpty(result.Text))
            {
                BookNumTxt.Invoke(new MethodInvoker(delegate
                {
                    BookNumTxt.Text = result.Text;
                }));
            }
            else
            {
                // Add a log or message to show that the barcode wasn't recognized
                Console.WriteLine("Barcode not recognized or empty.");
            }

            CameraFrame.Image = resizedBitmap;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BookNumTxt.Text) || string.IsNullOrEmpty(bookTitle.Text) || string.IsNullOrEmpty(author.Text) || string.IsNullOrEmpty(Status.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connect))
                    {
                        conn.Open();

                       string insertData = "INSERT INTO book (book_num, bookTitle, author, published, status, book_stock, insert_date) VALUES (@book_num, @bookTitle, @author, @publishedDate, @status, @BQuantity, @insertDate)";

                        using (MySqlCommand cmd = new MySqlCommand(insertData, conn))
                        {
                            cmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim());  // Ensure BookNum is not empty
                            cmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@author", author.Text.Trim());
                            cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                            cmd.Parameters.AddWithValue("@status", Status.Text.Trim());
                            cmd.Parameters.AddWithValue("@BQuantity",BQuantityTXT.Text.Trim());
                            cmd.Parameters.AddWithValue("@insertDate", DateTime.Now);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    displayBookData();
                    clearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (bookTitle.Text == "" || author.Text == "" || Status.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Book Title: " + bookTitle.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connect))
                        {
                            conn.Open();

                            // Corrected query with table name 'book'
                            string updateData = "UPDATE book SET bookTitle = @bookTitle, author = @author, published = @publishedDate, status = @status,book_stock = @BQuantity ,update_date = @updateDate WHERE book_num = @book_num";

                            using (MySqlCommand cmd = new MySqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@book_num",BookNumTxt.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@author", author.Text.Trim());
                                cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                                cmd.Parameters.AddWithValue("@status", Status.Text.Trim());
                                cmd.Parameters.AddWithValue("@BQuantity",BQuantityTXT.Text.Trim());
                                cmd.Parameters.AddWithValue("@updateDate", DateTime.Now);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Update Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        displayBookData();
                        clearField();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Update canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int BookID = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                BookNumTxt.Text = row.Cells[1].Value.ToString();
                bookTitle.Text = row.Cells[2].Value.ToString();
                author.Text = row.Cells[3].Value.ToString();
                if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime publishedDateValue))
                {
                    publishedDate.Value = publishedDateValue;
                }
                else
                {
                    publishedDate.Value = DateTime.Now;
                }
                Status.Text = row.Cells[5].Value.ToString();
               // BQuantityTXT.Text = row.Cells[6].Value.ToString();
            }
        }

        public void clearField()
        {
            bookTitle.Text = "";
            author.Text = "";
            Status.SelectedIndex = -1;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to delete Book Title: " + bookTitle.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connect))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM book WHERE bookTitle = @bookTitle";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    displayBookData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopCamera();
        }
    }
}

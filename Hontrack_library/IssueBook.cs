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
    public partial class IssueBook : UserControl
    {
       
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

          
           

           
           // this.VisibleChanged += BorrowBook_VisibleChanged;
        }

      


       

      
        public void displayBookData()
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();
            dataGridView1.DataSource = listdata;
            dataGridView1.Refresh();

            // Enable data auto-generation and auto-sizing
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
            dataGridView1.Columns[0].HeaderText = "Book ID";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Book Number";
            dataGridView1.Columns[3].HeaderText = "Author";
            dataGridView1.Columns[4].HeaderText = "Published Date";
            dataGridView1.Columns[5].HeaderText = "Status";
            dataGridView1.Columns[6].HeaderText = "Quantity";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void StartBtn_Click(object sender, EventArgs e)
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
                StartBtn.Text = "Stop";
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
                StartBtn.Text = "Start";

                // Set the PictureBox to a blank (black) image
                CameraFrame.Image = new Bitmap(CameraFrame.Width, CameraFrame.Height);
                using (Graphics g = Graphics.FromImage(CameraFrame.Image))
                {
                    g.Clear(Color.Black); // Fill the image with black
                }
            }
        }


        /*  private void BorrowBook_VisibleChanged(object sender, EventArgs e)
          {
              if (this.Visible && !isCameraRunning)
              {
                  StartCamera();
                  //refreshTimer.Start();  
              }
              else if (!this.Visible && isCameraRunning)
              {
                  StopCamera();
                 // refreshTimer.Stop();
              }
          }*/

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
                            cmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim()); 
                            cmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@author", author.Text.Trim());
                            cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                            cmd.Parameters.AddWithValue("@status", Status.Text.Trim());
                            cmd.Parameters.AddWithValue("@BQuantity", BQuantityTXT.Text.Trim());
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

                          
                            string updateData = "UPDATE book SET bookTitle = @bookTitle, author = @author, published = @publishedDate, status = @status,book_stock = @BQuantity ,update_date = @updateDate WHERE book_num = @book_num";

                            using (MySqlCommand cmd = new MySqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@author", author.Text.Trim());
                                cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                                cmd.Parameters.AddWithValue("@status", Status.Text.Trim());
                                cmd.Parameters.AddWithValue("@BQuantity", BQuantityTXT.Text.Trim());
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
                BookID = (int)row.Cells[0].Value;  
              
                bookTitle.Text = row.Cells[1].Value.ToString(); 
                BookNumTxt.Text = row.Cells[2].Value.ToString();
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
                BQuantityTXT.Text = row.Cells[6].Value.ToString();
            }
        }

        public void clearField()
        {
            bookTitle.Clear();
            author.Clear();
            Status.SelectedIndex = -1;
            BookNumTxt.Clear();
            BQuantityTXT.Clear();
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

                        string deleteQuery = "DELETE FROM book WHERE book_num = @book_num";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = searchBox.Text.Trim(); // Assuming you have a TextBox named searchBox
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

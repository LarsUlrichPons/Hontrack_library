using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private bool isCameraRunning = false;

        public BorrowBook()
        {
            InitializeComponent();

            displayBookData();


            // Initialize and start the timer to refresh every 1 second


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

            IDTextBox.ReadOnly = true;
            BookTitle.ReadOnly = true;
            Author.ReadOnly = true;
            BQuantity.ReadOnly = true;
            Status.ReadOnly = true;
            bookGenre.ReadOnly = true;
            bookCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            Camera.DropDownStyle = ComboBoxStyle.DropDownList;

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


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearField();
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

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();

            Bitmap resizedBitmap = new Bitmap(bitmap, new Size(640, 480));

            var result = reader.Decode(resizedBitmap);
            if (result != null && !string.IsNullOrEmpty(result.Text))
            {
                string scannedBarcode = result.Text;

                // Ensure barcode is processed only once
                if (IDTextBox.InvokeRequired)
                {
                    IDTextBox.Invoke(new MethodInvoker(delegate
                    {
                        if (IDTextBox.Text != scannedBarcode)
                        {
                            IDTextBox.Text = scannedBarcode;
                            FetchBookDetails(scannedBarcode); // Call the method to fetch details
                        }
                    }));
                }
                else
                {
                    if (IDTextBox.Text != scannedBarcode)
                    {
                        IDTextBox.Text = scannedBarcode;
                        FetchBookDetails(scannedBarcode);
                    }
                }
            }

            CameraFrame.Image = resizedBitmap;
        }


        private void FetchBookDetails(string barcode)
        {
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT bookTitle, bookAuthor, bookStock, bookStatus,bookCondition,bookGenre FROM tbl_book WHERE bookISBN = @barcode";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@barcode", barcode);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate fields with book details
                            BookTitle.Text = reader["bookTitle"].ToString();
                            Author.Text = reader["bookAuthor"].ToString();
                            BQuantity.Text = reader["bookStock"].ToString();
                            bookGenre.Text = reader["bookGenre"].ToString();
                            Status.Text = reader["bookStatus"].ToString();
                            bookCondition.Text = reader["bookCondition"].ToString();
                        }
                        else
                        {
                            // Clear fields and show an error if the book is not found
                            ClearBtn_Click(null, null); // Clear all fields
                            MessageBox.Show($"No book registered with the scanned barcode.\nBook Number: {barcode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching book details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        public void displayBookData()
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();
            dataGridView1.Refresh();
            listdata = listdata.OrderBy(b=>b.BookTitle).ToList();
            dataGridView1.DataSource = listdata;

         

            // Ensure correct column headers
            // dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].HeaderText = "Title";
            dataGridView1.Columns[1].HeaderText = "Book Number";
            dataGridView1.Columns[2].HeaderText = "Author";
            dataGridView1.Columns[3].HeaderText = "Genre";
            dataGridView1.Columns[4].HeaderText = "Published Date";
            dataGridView1.Columns[5].HeaderText = "Status";
            dataGridView1.Columns[6].HeaderText = "Condition";
            dataGridView1.Columns[7].HeaderText = "Quantity";




        }

        private int BookID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // BookID = (int)row.Cells[0].Value;  // Ensure the ID column is the first column
                BookTitle.Text = row.Cells[0].Value.ToString();
                IDTextBox.Text = row.Cells[1].Value.ToString();

                Author.Text = row.Cells[2].Value.ToString();
                bookGenre.Text = row.Cells[3].Value.ToString();
                Status.Text = row.Cells[5].Value.ToString();
                bookCondition.Text = row.Cells[6].Value.ToString();
                BQuantity.Text = row.Cells[7].Value.ToString();


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
            bookCondition.SelectedIndex = -1;
            bookGenre.Clear();
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
                            string getStockQuery = "SELECT bookStock, bookStatus FROM tbl_book WHERE bookISBN = @book_num";
                            MySqlCommand getStockCmd = new MySqlCommand(getStockQuery, conn, transaction);
                            getStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                            using (MySqlDataReader reader = getStockCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentStock = reader.GetInt32("bookStock");
                                    string currentStatus = reader.GetString("bookStatus");

                                    if (currentStock > 0 && currentStatus != "Unavailable")
                                    {
                                        // Deduct one from the stock
                                        int newStock = currentStock - 1;

                                        // Close the reader before executing the update command
                                        reader.Close();

                                        // Update the book stock in the database
                                        string updateStockQuery = "UPDATE tbl_book SET bookStock = @newStock WHERE bookISBN = @book_num";
                                        MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn, transaction);
                                        updateStockCmd.Parameters.AddWithValue("@newStock", newStock);
                                        updateStockCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        updateStockCmd.ExecuteNonQuery();

                                        // If the stock reaches zero, set the status to 'Unavailable'
                                        if (newStock == 0)
                                        {
                                            string updateStatusQuery = "UPDATE tbl_book SET bookStatus = 'Unavailable' WHERE bookISBN = @book_num";
                                            MySqlCommand updateStatusCmd = new MySqlCommand(updateStatusQuery, conn, transaction);
                                            updateStatusCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());

                                            updateStatusCmd.ExecuteNonQuery();
                                        }

                                        // Insert the transaction into the book_transaction table
                                        string insertTransactionQuery = @"
    INSERT INTO tbl_booktransac (bookTitle, bookISBN,  Status,bookGenre,borrowerID, borrowDate,returnDue)
    VALUES (@bookTitle, @book_num, 'Borrowed',@Genre ,@user_name, NOW(), @return_due)";

                                        MySqlCommand insertTransactionCmd = new MySqlCommand(insertTransactionQuery, conn, transaction);
                                        insertTransactionCmd.Parameters.AddWithValue("@bookTitle", BookTitle.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@book_num", IDTextBox.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@user_name", NameTXT.Text.Trim());
                                        insertTransactionCmd.Parameters.AddWithValue("@return_due", ReturnDue.Value);
                                        insertTransactionCmd.Parameters.AddWithValue("@Genre", bookGenre.Text.Trim());


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

     



        private void searchBtn_Click(object sender, EventArgs e)
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
                        // Modify the query to include ORDER BY for alphabetical sorting
                        string searchData = @"
                SELECT bookTitle, bookISBN, bookAuthor, 
                       bookGenre, datePublished, 
                       bookStatus, bookCondition, bookStock 
                FROM tbl_book 
                WHERE bookISBN LIKE @SearchQuery 
                   OR bookTitle LIKE @SearchQuery 
                   OR bookAuthor LIKE @SearchQuery
                   OR bookGenre LIKE @SearchQuery
                ORDER BY bookTitle ASC"; // Sort alphabetically by bookTitle

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

                            // Set the custom headers after binding the data
                            dataGridView1.Columns[0].HeaderText = "Title";
                            dataGridView1.Columns[1].HeaderText = "Book Number";
                            dataGridView1.Columns[2].HeaderText = "Author";
                            dataGridView1.Columns[3].HeaderText = "Genre";
                            dataGridView1.Columns[4].HeaderText = "Published Date";
                            dataGridView1.Columns[5].HeaderText = "Status";
                            dataGridView1.Columns[6].HeaderText = "Condition";
                            dataGridView1.Columns[7].HeaderText = "Quantity";

                            // Optional: Format the 'Published Date' column (if it's a DateTime type)
                            if (dataGridView1.Columns[4] != null)
                            {
                                dataGridView1.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    

        private void ReturnDue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

       
      

    }
}

using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            Camera.DropDownStyle = ComboBoxStyle.DropDownList;
            bookCondition.DropDownStyle = ComboBoxStyle.DropDownList;


              dataGridView1.Refresh();
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

            listdata = listdata.OrderBy(b=>b.BookTitle).ToList();
            dataGridView1.DataSource = listdata;

            dataGridView1.Refresh();


            // Enable data auto-generation and auto-sizing
         

            // Ensure correct column headers
           // dataGridView1.Columns[0].HeaderText = "Book ID";
            dataGridView1.Columns[0].HeaderText = "Title";
            dataGridView1.Columns[1].HeaderText = "Book Number";
            dataGridView1.Columns[2].HeaderText = "Author";
            dataGridView1.Columns[3].HeaderText = "Genre";
            dataGridView1.Columns[4].HeaderText = "Published Date";
            dataGridView1.Columns[5].HeaderText = "Status";
            dataGridView1.Columns[6].HeaderText = "Condition";
            dataGridView1.Columns[7].HeaderText = "Quantity";

            if (dataGridView1.Columns[4] != null)
            {
                dataGridView1.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
            }


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
                if (BookNumTxt.InvokeRequired)
                {
                    BookNumTxt.Invoke(new MethodInvoker(delegate
                    {
                        if (BookNumTxt.Text != scannedBarcode)
                        {
                            BookNumTxt.Text = scannedBarcode;
                            FetchBookDetails(scannedBarcode); // Call the method to fetch details
                        }
                    }));
                }
                else
                {
                    if (BookNumTxt.Text != scannedBarcode)
                    {
                        BookNumTxt.Text = scannedBarcode;
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
                            bookTitle.Text = reader["bookTitle"].ToString();
                            author.Text = reader["bookAuthor"].ToString();
                            BQuantityTXT.Text = reader["bookStock"].ToString();
                            bookGenre.Text = reader["bookGenre"].ToString();
                            Status.Text = reader["bookStatus"].ToString();
                            bookCondition.Text = reader["bookCondition"].ToString();
                        }
                        else
                        {
                            // Clear fields and show an error if the book is not found

                            DialogResult dialogResult = MessageBox.Show(
                                                 $"No book registered with the scanned barcode.\nBook Number: {barcode}\n\nWould you like to add a new book with this barcode?",
                                                 "Book Not Found",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching book details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void AddBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection(connect);

            if (string.IsNullOrEmpty(BookNumTxt.Text) || string.IsNullOrEmpty(bookTitle.Text) ||
                string.IsNullOrEmpty(author.Text) || string.IsNullOrEmpty(Status.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (mysql.State == ConnectionState.Closed)
                    mysql.Open();

                // Check if the book title already exists
                string checkTitleQuery = "SELECT COUNT(*) FROM tbl_book WHERE bookTitle = @bookTitle";
                using (MySqlCommand checkTitleCmd = new MySqlCommand(checkTitleQuery, mysql))
                {
                    checkTitleCmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                    int titleCount = Convert.ToInt32(checkTitleCmd.ExecuteScalar());
                    if (titleCount >= 1)
                    {
                        MessageBox.Show($"Book Title '{bookTitle.Text.Trim()}' is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Check if the ISBN already exists
                string checkIsbnQuery = "SELECT COUNT(*) FROM tbl_book WHERE bookISBN = @bookISBN";
                using (MySqlCommand checkIsbnCmd = new MySqlCommand(checkIsbnQuery, mysql))
                {
                    checkIsbnCmd.Parameters.AddWithValue("@bookISBN", BookNumTxt.Text.Trim());
                    int isbnCount = Convert.ToInt32(checkIsbnCmd.ExecuteScalar());
                    if (isbnCount >= 1)
                    {
                        MessageBox.Show($"ISBN '{BookNumTxt.Text.Trim()}' is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();

                    // Process multi-genre input (split by commas, trim, and apply proper case)
                    string combinedGenres = string.Join(", ", bookGenre.Text
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(g => ToProperCase(g.Trim())));

                    // Insert the book data
                    string insertData = "INSERT INTO tbl_book (bookISBN, bookTitle, bookAuthor, datePublished, bookStatus,  bookCondition, bookGenre,bookStock, insertDate) " +
                                        "VALUES (@book_num, @bookTitle, @bookAuthor, @publishedDate, @status, @condition, @genre, @BQuantity, @insertDate)";

                    using (MySqlCommand cmd = new MySqlCommand(insertData, conn))
                    {
                        cmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@bookTitle", ToProperCase(bookTitle.Text.Trim())); // Apply proper case to title
                        cmd.Parameters.AddWithValue("@bookAuthor", ToProperCase(author.Text.Trim()));
                        cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                        cmd.Parameters.AddWithValue("@status", Status.Text.Trim());
                        cmd.Parameters.AddWithValue("@condition",bookCondition.Text.Trim());
                        cmd.Parameters.AddWithValue("@genre", ToProperCase(bookGenre.Text.Trim()));
                        cmd.Parameters.AddWithValue("@BQuantity", BQuantityTXT.Text.Trim());
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                displayBookData();
                clearField();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection(connect);
            if (string.IsNullOrEmpty(bookTitle.Text) || string.IsNullOrEmpty(author.Text) || string.IsNullOrEmpty(Status.Text))
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
                        if (mysql.State == ConnectionState.Closed)
                            mysql.Open();

                        // Check for duplicate bookTitle in other records
                        string checkTitleQuery = "SELECT COUNT(*) FROM tbl_book WHERE bookTitle = @bookTitle AND bookISBN != @bookISBN";
                        using (MySqlCommand checkTitleCmd = new MySqlCommand(checkTitleQuery, mysql))
                        {
                            checkTitleCmd.Parameters.AddWithValue("@bookTitle", bookTitle.Text.Trim());
                            checkTitleCmd.Parameters.AddWithValue("@bookISBN", BookNumTxt.Text.Trim());
                            int titleCount = Convert.ToInt32(checkTitleCmd.ExecuteScalar());
                            if (titleCount > 0)
                            {
                                MessageBox.Show("Book Title '" + bookTitle.Text.Trim() + "' is already in use.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Check for duplicate bookISBN in other records
                        string checkIsbnQuery = "SELECT COUNT(*) FROM tbl_book WHERE bookISBN = @bookISBN AND bookISBN != @book_num";
                        using (MySqlCommand checkIsbnCmd = new MySqlCommand(checkIsbnQuery, mysql))
                        {
                            checkIsbnCmd.Parameters.AddWithValue("@bookISBN", BookNumTxt.Text.Trim());
                            checkIsbnCmd.Parameters.AddWithValue("@book_num", BookNumTxt.Text.Trim());
                            int isbnCount = Convert.ToInt32(checkIsbnCmd.ExecuteScalar());
                            if (isbnCount > 0)
                            {
                                MessageBox.Show("ISBN '" + BookNumTxt.Text.Trim() + "' is already in use.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Combine and format genres
                        string combinedGenres = string.Join(", ", bookGenre.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(g => g.Trim()));
                        string properCaseGenre = ToProperCase(combinedGenres);

                        // Apply proper case to bookTitle
                        string properCaseTitle = ToProperCase(bookTitle.Text.Trim());
                        

                        // Proceed to update the record
                        using (MySqlConnection conn = new MySqlConnection(connect))
                        {
                            conn.Open();

                            string updateData = "UPDATE tbl_book SET bookTitle = @bookTitle, bookAuthor = @bookAuthor, datePublished = @publishedDate, " +
                                                "bookStatus = @bookStatus, bookCondition = @bookCondition, bookGenre = @bookGenre, " +
                                                "bookStock = @bookStock, updateDate = @updateDate WHERE bookISBN = @bookISBN";

                            using (MySqlCommand cmd = new MySqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@bookISBN", BookNumTxt.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookTitle", properCaseTitle);
                                cmd.Parameters.AddWithValue("@bookAuthor", ToProperCase(author.Text.Trim()));
                                cmd.Parameters.AddWithValue("@publishedDate", publishedDate.Value);
                                cmd.Parameters.AddWithValue("@bookStatus", Status.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookCondition", bookCondition.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookGenre", properCaseGenre);
                                cmd.Parameters.AddWithValue("@bookStock", BQuantityTXT.Text.Trim());
                                cmd.Parameters.AddWithValue("@updateDate", DateTime.Now);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
               // BookID = (int)row.Cells[0].Value;  
              
                bookTitle.Text = row.Cells[0].Value.ToString(); 
                BookNumTxt.Text = row.Cells[1].Value.ToString();
                author.Text = row.Cells[2].Value.ToString();
                bookGenre.Text = row.Cells[3].Value.ToString();
                if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime publishedDateValue))
                {
                    publishedDate.Value = publishedDateValue;
                }
                else
                {
                    publishedDate.Value = DateTime.Now;
                }
                Status.Text = row.Cells[5].Value.ToString();
                bookCondition.Text = row.Cells[6].Value.ToString();
                BQuantityTXT.Text = row.Cells[7].Value.ToString();
            }
        }

        public void clearField()
        {
            bookTitle.Clear();
            author.Clear();
            Status.SelectedIndex = -1;
            BookNumTxt.Clear();
            BQuantityTXT.Clear();
            searchBox.Clear();
            bookGenre.Clear();
            bookCondition.SelectedIndex = -1;
        }

      /*  private void RemoveBtn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to delete Book Title: " + bookTitle.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connect))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM tbl_book WHERE bookISBN = @book_num";

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
        }*/

       

      

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
                            string searchQuery = "%" + searchBox.Text.Trim() + "%"; // Add wildcards for LIKE search
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








        private string ToProperCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BQuantityTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}

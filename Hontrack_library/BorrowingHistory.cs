using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Drawing;
using Color = System.Drawing.Color;
using System.Runtime.InteropServices.ComTypes;


namespace Hontrack_library
{
    public partial class BorrowingHistory : UserControl
    {
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";

        private Timer refreshTimer; // Declare Timer here
        public BorrowingHistory()
        {
            InitializeComponent();
            displayBookData();

           
           

            IDtxt.ReadOnly = true;
            bookTitle.ReadOnly = true;
            UserNametxt.ReadOnly = true;    
            status.ReadOnly = true; 
            borrowdate.ReadOnly = true;
           
            returndate.ReadOnly = true;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Header styling
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Row styling
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9);
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
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
            BookTransaction bookData = new BookTransaction();
            List<BookTransaction> listdata = bookData.BookListTransaction();
            listdata = listdata.OrderByDescending(b => b.Borrow).ToList();

            dataGridView1.Refresh();
            dataGridView1.DataSource = listdata;

            

            // Ensure correct column headers
           // dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].HeaderText = "School ID";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Book Number";
            dataGridView1.Columns[3].HeaderText = "Genre";
          
            dataGridView1.Columns[4].HeaderText = "Borrow Date";
            dataGridView1.Columns[5].HeaderText = "Return Date";
            dataGridView1.Columns[6].HeaderText = "Status";

            dataGridView1.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                 UserNametxt.Text = row.Cells[0].Value.ToString();
                bookTitle.Text = row.Cells[1].Value.ToString();
                IDtxt.Text = row.Cells[2].Value.ToString();
                
               
              
                borrowdate.Text = row.Cells[4].Value.ToString();
                returndate.Text = row.Cells[5].Value.ToString();
                status.Text = row.Cells[6].Value.ToString();


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
                        // SQL query with proper WHERE and ORDER BY placement
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
                ORDER BY borrowDate DESC;"; // Order by borrow date for recent entries

                        // Create the command and add parameters
                        using (MySqlCommand cmd = new MySqlCommand(searchData, conn))
                        {
                            string searchQuery = "%" + searchBox.Text.Trim() + "%"; // Add wildcards for LIKE search
                            cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

                            // Execute the command and fill the DataTable
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dt;
                            dataGridView1.Refresh();

                            // Ensure column headers are correctly set
                            if (dataGridView1.Columns.Count > 0)
                            {
                                dataGridView1.Columns[0].HeaderText = "Transaction ID";
                                dataGridView1.Columns[1].HeaderText = "School ID";
                                dataGridView1.Columns[2].HeaderText = "Title";
                                dataGridView1.Columns[3].HeaderText = "Book Number";
                                dataGridView1.Columns[4].HeaderText = "Genre";
                                dataGridView1.Columns[5].HeaderText = "Borrow Date";
                                dataGridView1.Columns[6].HeaderText = "Return Due";
                                dataGridView1.Columns[7].HeaderText = "Status";

                                // Format date columns (if present)
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




        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Refresh data instantly
                displayBookData();
                clearField();
                MessageBox.Show("Data refreshed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PdfBtn_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Hontrack-BookHistory.pdf");

            try
            {
                // Get selected date range from DateTimePickers
                DateTime startDate = startDatePicker.Value.Date;
                DateTime endDate = endDatePicker.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("The start date cannot be later than the end date. Please select a valid date range.",
                                    "Invalid Date Range",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Exit the method without proceeding further
                }
                // Fetch data from the database using the selected date range
                var borrowingHistory = FetchBorrowingHistoryFromDatabase(startDate, endDate);
                var borrowedBooks = FetchBorrowedBooksFromDatabase(startDate, endDate);
                var returnedBooks = FetchReturnedBooksFromDatabase(startDate, endDate);
                var borrowCountData = FetchBorrowCountFromDatabase(startDate, endDate);
                var popularGenreData = FetchPopularGenresFromDatabase(startDate, endDate);

                // Create the MigraDoc document
                Document document = CreateDocument(
                    borrowingHistory,
                    borrowedBooks,
                    returnedBooks,
                    borrowCountData,
                    popularGenreData,
                    startDate,
                    endDate);

                // Render the document into a PDF
                PdfDocumentRenderer renderer = new PdfDocumentRenderer();
                renderer.Document = document;
                renderer.RenderDocument();

                // Save the PDF
                renderer.PdfDocument.Save(filePath);

                // Notify the user
                MessageBox.Show($"PDF generated successfully at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally open the PDF
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> FetchBorrowingHistoryFromDatabase(DateTime startDate, DateTime endDate)
        {
            var historyData = new List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = @"
            SELECT borrowerID, borrowDate, returnDate, Status, bookISBN, bookTitle 
            FROM tbl_booktransac 
            WHERE DATE(borrowDate) BETWEEN @StartDate AND @EndDate";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string borrower = reader["borrowerID"].ToString();
                                string bookNum = reader["bookISBN"].ToString();
                                string bookTitle = reader["bookTitle"].ToString();
                                string borrowDate = Convert.ToDateTime(reader["borrowDate"]).ToShortDateString();
                                string returnDate = reader["returnDate"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["returnDate"]).ToShortDateString()
                                    : "Not yet returned";
                                string status = reader["Status"].ToString();
                                historyData.Add((borrower, bookTitle, bookNum, borrowDate, returnDate, status));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return historyData;
        }



        private List<(string BookTitle, string BookNum, string BookGenre, int BorrowCount)> FetchBorrowCountFromDatabase(DateTime startDate, DateTime endDate)
        {
            var borrowCountData = new List<(string BookTitle, string BookNum, string BookGenre, int BorrowCount)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = @"
            SELECT bookTitle, COUNT(*) AS borrowCount, bookISBN, bookGenre 
            FROM tbl_booktransac 
            WHERE DATE(borrowDate) BETWEEN @StartDate AND @EndDate
            GROUP BY bookTitle, bookISBN
            ORDER BY borrowCount DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string bookTitle = reader["bookTitle"].ToString();
                                string bookNum = reader["bookISBN"].ToString();
                                string bookGenre = reader["bookGenre"].ToString();
                                int borrowCount = Convert.ToInt32(reader["borrowCount"]);
                                borrowCountData.Add((bookTitle, bookNum, bookGenre, borrowCount));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching borrow count data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return borrowCountData;
        }




        private List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> FetchBorrowedBooksFromDatabase(DateTime startDate, DateTime endDate)
        {
            var borrowedData = new List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = "SELECT borrowerID, borrowDate, returnDate, Status, bookISBN, bookTitle " +
                                   "FROM tbl_booktransac WHERE Status = 'Borrowed' AND  DATE(borrowDate) BETWEEN @StartDate AND @EndDate"; // Filter by selected date

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string borrower = reader["borrowerID"].ToString();
                                string bookNum = reader["bookISBN"].ToString();
                                string bookTitle = reader["bookTitle"].ToString();
                                string borrowDate = Convert.ToDateTime(reader["borrowDate"]).ToShortDateString();
                                string returnDate = reader["returnDate"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["returnDate"]).ToShortDateString()
                                    : "Not yet return";
                                string status = reader["Status"].ToString();
                                borrowedData.Add((borrower, bookTitle, bookNum, borrowDate, returnDate, status));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching borrowed data from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return borrowedData;
        }


        private List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> FetchReturnedBooksFromDatabase(DateTime startDate, DateTime endDate)
        {
            var returnedData = new List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = "SELECT borrowerID, borrowDate, returnDate, Status, bookISBN, bookTitle " +
                                   "FROM tbl_booktransac WHERE Status = 'Returned' AND DATE(borrowDate) BETWEEN @StartDate AND @EndDate"; // Filter by selected date

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string borrower = reader["borrowerID"].ToString();
                                string bookNum = reader["bookISBN"].ToString();
                                string bookTitle = reader["bookTitle"].ToString();
                                string borrowDate = Convert.ToDateTime(reader["borrowDate"]).ToShortDateString();
                                string returnDate = Convert.ToDateTime(reader["returnDate"]).ToShortDateString();
                                string status = reader["Status"].ToString();
                                returnedData.Add((borrower, bookTitle, bookNum, borrowDate, returnDate, status));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching returned data from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return returnedData;
        }



        private List<(string Genre, int BorrowCount)> FetchPopularGenresFromDatabase(DateTime startDate, DateTime endDate)
        {
            var genreData = new List<(string Genre, int BorrowCount)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = @"
                SELECT bookGenre, COUNT(*) AS borrowCount 
                FROM tbl_booktransac 
                WHERE DATE(borrowDate) BETWEEN @StartDate AND @EndDate
                GROUP BY bookGenre 
                ORDER BY borrowCount DESC";  // Filter by selected date

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string genre = reader["bookGenre"].ToString();
                                int borrowCount = Convert.ToInt32(reader["borrowCount"]);
                                genreData.Add((genre, borrowCount));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching genre data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return genreData;
        }



        // Create MigraDoc document from the fetched data
        private Document CreateDocument(
         List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> historyData,
         List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> borrowedBooks,
         List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> returnedBooks,
         List<(string BookTitle, string BookNum, string bookGenre, int BorrowCount)> borrowCountData,
         List<(string Genre, int BorrowCount)> genreData,
         DateTime startDate,
         DateTime endDate) // Pass startDate and endDate
        {
            Document document = new Document();
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 11;
            Section section = document.AddSection();

            // Add header with date range
            AddHeader(section, startDate, endDate);

            // Create Borrowing History Table
            AddTableToSection(section, historyData, "Borrowing History");

            // Create Borrowed Books Table
            AddTableToSection(section, borrowedBooks, "Borrowed Books");

            // Create Returned Books Table
            AddTableToSection(section, returnedBooks, "Returned Books");

            // Create Borrow Count Table
            AddBorrowCountTable(section, borrowCountData);

            // Create Popular Genres Table
            AddPopularGenresTable(section, genreData);

            return document;
        }

        private void AddHeader(Section section, DateTime startDate, DateTime endDate)
        {
            // Company Title
            Paragraph companyTitle = section.AddParagraph();
            companyTitle.AddFormattedText("Hontrack", TextFormat.Bold).Font.Color = Colors.Green;
            companyTitle.AddText(": Library Management");
            companyTitle.Format.Font.Name = "Times New Roman";
            companyTitle.Format.Font.Size = 20;
            companyTitle.Format.Alignment = ParagraphAlignment.Left;
            section.AddParagraph("\n");

            // PDF Generation Date
            // PDF Generated Date
            Paragraph dateParagraph = section.AddParagraph($"PDF Generated on: {DateTime.Now:MMMM dd, yyyy}");
            dateParagraph.Format.Font.Name = "Calibri";
            dateParagraph.Format.Font.Size = 10;
            dateParagraph.Format.Font.Italic = true; // Enable italics here
            dateParagraph.Format.Alignment = ParagraphAlignment.Right;
            section.AddParagraph("\n");

            // Date Range
            Paragraph dateRangeParagraph = section.AddParagraph($"Data Recorded from: {startDate:MMMM dd, yyyy} to {endDate:MMMM dd, yyyy}");
            dateRangeParagraph.Format.Font.Name = "Calibri";
            dateRangeParagraph.Format.Font.Size = 10;
            dateRangeParagraph.Format.Font.Italic = true; // Enable italics here as well
            dateRangeParagraph.Format.Alignment = ParagraphAlignment.Right;
            section.AddParagraph("\n");

        }

        private void AddTableToSection(Section section, List<(string Borrower, string BookTitle, string BookNum, string BorrowDate, string ReturnDate, string Status)> data, string title)
        {
            Paragraph reportTitle = section.AddParagraph(title);
            reportTitle.Format.Font.Name = "Arial";
            reportTitle.Format.Font.Size = 16;
            reportTitle.Format.Font.Bold = true;
            reportTitle.Format.Alignment = ParagraphAlignment.Left;
            section.AddParagraph("\n");

            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            // Table Columns
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Center; // Borrower
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Center; // Book Title
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Center; // Book Number
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Center; // Borrow Date
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Center; // Return Date
            table.AddColumn("2cm").Format.Alignment = ParagraphAlignment.Center; // Status

            // Table Header
            Row headerRow = table.AddRow();
            headerRow.Shading.Color = Colors.LightGray;
            headerRow.Format.Font.Name = "Verdana";
            headerRow.Format.Font.Size = 12;
            headerRow.Format.Font.Bold = true;
            headerRow.TopPadding = 5;
            headerRow.BottomPadding = 5;

            headerRow.Cells[0].AddParagraph("Borrower");
            headerRow.Cells[1].AddParagraph("Book Title");
            headerRow.Cells[2].AddParagraph("Book Number");
            headerRow.Cells[3].AddParagraph("Borrow Date");
            headerRow.Cells[4].AddParagraph("Return Date");
            headerRow.Cells[5].AddParagraph("Status");

            // If data is empty, add a single row with "No data available"
            if (data.Count == 0)
            {
                Row noDataRow = table.AddRow();
                noDataRow.Cells[0].AddParagraph("No data available");
                

            }
            else 
            {

                bool isAlternate = false;
                foreach (var entry in data)
                {
                    Row row = table.AddRow();
                    row.Format.Font.Name = "Arial";
                    row.Format.Font.Size = 11;
                    row.TopPadding = 7;
                    row.BottomPadding = 7;

                    // Apply alternating row color
                    if (isAlternate)
                        row.Shading.Color = Colors.WhiteSmoke;

                    isAlternate = !isAlternate;

                    row.Cells[0].AddParagraph(entry.Borrower);
                    row.Cells[1].AddParagraph(entry.BookTitle);
                    row.Cells[2].AddParagraph(entry.BookNum);
                    row.Cells[3].AddParagraph(entry.BorrowDate);
                    row.Cells[4].AddParagraph(entry.ReturnDate);
                    row.Cells[5].AddParagraph(entry.Status);
                }

            }
            // Table Content with Alternating Row Colors
           
            section.AddParagraph("\n\n");
        }

        private void AddBorrowCountTable(Section section, List<(string BookTitle, string BookNum, string bookGenre, int BorrowCount)> borrowCountData)
        {
            Paragraph countTitle = section.AddParagraph("Books Borrowed Count (Most to Least)");
            countTitle.Format.Font.Name = "Arial";
            countTitle.Format.Font.Size = 14;
            countTitle.Format.Font.Bold = true;
            countTitle.Format.Alignment = ParagraphAlignment.Left;
            section.AddParagraph("\n");

            Table countTable = section.AddTable();
            countTable.Borders.Width = 0.75;

            countTable.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center; // Book Title
            countTable.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center; // Book Number
            countTable.AddColumn("4cm").Format.Alignment= ParagraphAlignment.Center;
            countTable.AddColumn("5cm").Format.Alignment = ParagraphAlignment.Center; // Borrow Count

            Row countHeader = countTable.AddRow();
            countHeader.Shading.Color = Colors.LightGray;
            countHeader.Format.Font.Name = "Verdana";
            countHeader.Format.Font.Size = 12;
            countHeader.Format.Font.Bold = true;
            countHeader.TopPadding = 4;
            countHeader.BottomPadding = 4;
            countHeader.Cells[0].AddParagraph("Book Title");
            countHeader.Cells[1].AddParagraph("Book Number");
            countHeader.Cells[2].AddParagraph("Book Genre");
            countHeader.Cells[3].AddParagraph("Borrow Count");

            if (borrowCountData.Count == 0)
            {
                Row noDataRow = countTable.AddRow();
                noDataRow.Cells[0].AddParagraph("No data available");
            }
            else
            {
                bool isAlternate = false;
                foreach (var count in borrowCountData)
                {
                    Row countRow = countTable.AddRow();
                    countRow.Format.Font.Name = "Arial";
                    countRow.Format.Font.Size = 11;
                    countRow.TopPadding = 5;
                    countRow.BottomPadding = 5;

                    // Apply alternating row color
                    if (isAlternate)
                        countRow.Shading.Color = Colors.WhiteSmoke;

                    isAlternate = !isAlternate;

                    countRow.Cells[0].AddParagraph(count.BookTitle);
                    countRow.Cells[1].AddParagraph(count.BookNum);
                    countRow.Cells[2].AddParagraph(count.bookGenre);
                    countRow.Cells[3].AddParagraph(count.BorrowCount.ToString());
                }
            }
            section.AddParagraph("\n\n");
        }


        private void AddPopularGenresTable(Section section, List<(string Genre, int BorrowCount)> genreData)
        {
            Paragraph genreTitle = section.AddParagraph("Most Popular Genres (Most to Least)");
            genreTitle.Format.Font.Name = "Arial";
            genreTitle.Format.Font.Size = 14;
            genreTitle.Format.Font.Bold = true;
            genreTitle.Format.Alignment = ParagraphAlignment.Left;
            section.AddParagraph("\n");

            Table genreTable = section.AddTable();
            genreTable.Borders.Width = 0.75;

            // Add Columns
            genreTable.AddColumn("9cm").Format.Alignment = ParagraphAlignment.Center; // Genre
            genreTable.AddColumn("8cm").Format.Alignment = ParagraphAlignment.Center; // Borrow Count

            // Add Header
            Row headerRow = genreTable.AddRow();
            headerRow.Shading.Color = Colors.LightGray;
            headerRow.Format.Font.Name = "Verdana";
            headerRow.Format.Font.Size = 12;
            headerRow.Format.Font.Bold = true;
            headerRow.TopPadding = 4;
            headerRow.BottomPadding = 4;
            headerRow.Cells[0].AddParagraph("Genre");
            headerRow.Cells[1].AddParagraph("Borrow Count");

            // Add Rows
            if (genreData.Count == 0)
            {
                Row noDataRow = genreTable.AddRow();
                noDataRow.Cells[0].AddParagraph("No data available");
            }
            else
            {
                bool isAlternate = false;
                foreach (var genre in genreData)
                {
                    Row row = genreTable.AddRow();
                    row.Format.Font.Name = "Arial";
                    row.Format.Font.Size = 11;
                    row.TopPadding = 5;
                    row.BottomPadding = 5;

                    // Apply alternating row color
                    if (isAlternate)
                        row.Shading.Color = Colors.WhiteSmoke;

                    isAlternate = !isAlternate;

                    row.Cells[0].AddParagraph(genre.Genre);
                    row.Cells[1].AddParagraph(genre.BorrowCount.ToString());
                }
            }
            section.AddParagraph("\n\n");
        }


        public void clearField() 
        {
            searchBox.Clear();
            bookTitle.Clear();
            IDtxt.Clear();
            UserNametxt.Clear();    
            borrowdate.Clear();
            returndate.Clear();
            status.Clear();
        }

        private int rotationAngle = 0;

        private void Refresh_Click_1(object sender, EventArgs e)
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

        private void IDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private bool isAscending = true; // Tracks the current sort order (default to Ascending)

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the book data
                BookTransaction bookData = new BookTransaction();
                List<BookTransaction> listdata = bookData.BookListTransaction();

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

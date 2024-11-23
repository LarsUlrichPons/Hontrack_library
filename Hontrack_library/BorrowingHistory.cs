using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // 1 second
            refreshTimer.Tick += RefreshTimer_Tick; // Event handler
           

            IDtxt.ReadOnly = true;
            UserNametxt.ReadOnly = true;    
            status.ReadOnly = true; 
            borrowdate.ReadOnly = true;
            returndate.ReadOnly = true;
        }

       

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Refresh the book data every second
            displayBookData();
        }
        
        public void displayBookData()
        {
            BookTransaction bookData = new BookTransaction();
            List<BookTransaction> listdata = bookData.BookListTransaction();
            dataGridView1.Refresh();
            dataGridView1.DataSource = listdata;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                bookTitle.Text = row.Cells[1].Value.ToString();
                IDtxt.Text = row.Cells[2].Value.ToString();
               
                UserNametxt.Text = row.Cells[3].Value.ToString();
                borrowdate.Text = row.Cells[4].Value.ToString();
                returndate.Text = row.Cells[5].Value.ToString();
                status.Text = row.Cells[6].Value.ToString();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = searchBox.Text.Trim(); // Assuming you have a TextBox named searchBox
                BookTransaction bookData = new BookTransaction();
                List<BookTransaction> filteredData = bookData.BookListTransaction(searchQuery);

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

        private void searchBox_TextChanged(object sender, EventArgs e)
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

        private void PdfBtn_Click(object sender, EventArgs e)
        {
            // File path to save the PDF
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BorrowingHistory.pdf");

            try
            {
                // Fetch borrowing history data from the database
                var borrowingHistory = FetchBorrowingHistoryFromDatabase();

                // Create the MigraDoc document
                Document document = CreateDocument(borrowingHistory);

                // Render the document into a PDF
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
                {
                    Document = document
                };
                renderer.RenderDocument();

                // Save the PDF to the specified file path
                renderer.PdfDocument.Save(filePath);

                // Notify the user
                MessageBox.Show($"PDF generated successfully at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally open the PDF after generation
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to fetch borrowing history data from the database
        private List<(string Borrower, string BookNum, string BorrowDate, string ReturnDate, string Status)> FetchBorrowingHistoryFromDatabase()
        {
            var historyData = new List<(string Borrower, string BookNum,string BorrowDate, string ReturnDate, string Status)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string query = "SELECT user_name, borrow_date, return_date, status,book_num FROM book_transactions"; // Adjust table and column names as necessary

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string borrower = reader["user_name"].ToString();
                            string bookNum = $"Book Number: {reader["book_num"]}";
                            string borrowDate = $"Borrowed: {Convert.ToDateTime(reader["borrow_date"]).ToShortDateString()}";
                            string returnDate = reader["return_date"] != DBNull.Value
                        ? $"Return: {Convert.ToDateTime(reader["return_date"]).ToShortDateString()}"
                        : "Return: Not yet returned"; // If null, set a default value
                            string status =  $"Status: {reader["status"]}";
                            historyData.Add((borrower, bookNum,borrowDate,returnDate,status));
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

        // Create MigraDoc document from the fetched data
        private Document CreateDocument(List<(string Borrower, string BookNum, string BorrowDate, string ReturnDate, string Status)> historyData)
        {
            // Create a new MigraDoc document
            Document document = new Document();
            Section section = document.AddSection();

            // Add a title
            Paragraph title = section.AddParagraph("Borrowing History");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.Alignment = ParagraphAlignment.Center;
            section.AddParagraph("\n"); // Add spacing below title

            // Add a table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            // Define columns
            table.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Left; // Borrower
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Left; // Book Number
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Left; // Borrow Date
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Left; // Return Date
            table.AddColumn("3cm").Format.Alignment = ParagraphAlignment.Left; // Status

            // Add a row for headers
            Row headerRow = table.AddRow();
            headerRow.Shading.Color = Colors.LightGray;
            headerRow.Cells[0].AddParagraph("Borrower");
            headerRow.Cells[1].AddParagraph("Book Number");
            headerRow.Cells[2].AddParagraph("Borrow Date");
            headerRow.Cells[3].AddParagraph("Return Date");
            headerRow.Cells[4].AddParagraph("Status");

            // Populate the table with data
            foreach (var entry in historyData)
            {
                Row row = table.AddRow();
                row.Cells[0].AddParagraph(entry.Borrower);
                row.Cells[1].AddParagraph(entry.BookNum);
                row.Cells[2].AddParagraph(entry.BorrowDate);
                row.Cells[3].AddParagraph(entry.ReturnDate);
                row.Cells[4].AddParagraph(entry.Status);

            }

            return document;
        }

        private void IDtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

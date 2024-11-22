using Hontrack_library;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace Hontrack_library
{
    public class borrowedBookData
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }
        public long BookNumber { get; set; }
        public string User_name { get; set; }
        public string Borrow { get; set; }
        public string Return_due { get; set; }
        public string Status { get; set; }

        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public List<borrowedBookData> BookListTransaction()
        {
            List<borrowedBookData> bookTransactions = new List<borrowedBookData>();
            string query = "SELECT * FROM book_transactions WHERE Status = 'Borrowed'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            borrowedBookData transaction = new borrowedBookData
                            {
                                ID = reader.GetInt32("transaction_id"),
                                BookTitle = reader.IsDBNull(reader.GetOrdinal("bookTitle")) ? "Unknown Title" : reader.GetString("bookTitle"), // Handle nulls
                                BookNumber = reader.GetInt64("book_num"),
                                User_name = reader.GetString("user_name"),
                                Status = reader.GetString("Status"),
                                Borrow = reader.GetDateTime("borrow_date").ToString("yyyy-MM-dd"),
                                // Check if the return_due date is overdue
                                Return_due = reader.IsDBNull(reader.GetOrdinal("return_due"))
                                    ? "Not yet returned"
                                    : CheckIfOverdue(reader.GetDateTime("return_due"))
                            };
                            bookTransactions.Add(transaction);
                        }
                    }
                }
            }
            return bookTransactions;
        }

        // Method to check if the return_due date is overdue
        private string CheckIfOverdue(DateTime returnDueDate)
        {
            if (returnDueDate < DateTime.Now)
            {
                return $"{returnDueDate.ToString("MM-dd")} - Overdue";
            }
            return returnDueDate.ToString("yyyy-MM-dd");
        }
    }

}

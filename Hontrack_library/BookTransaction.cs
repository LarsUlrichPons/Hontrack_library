using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Hontrack_library
{
    internal class BookTransaction
    {
       //public int ID { get; set; }
       
       public string User_name { get; set; }
        public string BookTitle { get; set; }
        public long BookNumber { get; set; } 
        public string bookGenre { get; set; }

      
        // public DateTime Published { get; set; }
        public string Borrow { get; set; }
        public string Return { get; set; }  // Store return date as string for easy checking
        public string Status { get; set; }

        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public List<BookTransaction> BookListTransaction(string userNameFilter = null)
        {
            List<BookTransaction> listdata = new List<BookTransaction>();

            using (MySqlConnection mysql = new MySqlConnection(connectionString))
            {
                try
                {
                    mysql.Open();

                    // Start with the base query to get books that have not been deleted.
                    string selectData = "SELECT * FROM tbl_booktransac WHERE deleteDate IS NULL";

                    // Only add filters if the corresponding parameter is not null or empty
                  
                  
                 


                    using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                    {
                        
                       


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BookTransaction bookTransaction = new BookTransaction
                                {
                                  // ID = reader.GetInt32("transac_id"),
                                    BookTitle = reader.IsDBNull(reader.GetOrdinal("bookTitle")) ? "Unknown Title" : reader.GetString("bookTitle"),
                                    BookNumber = reader.GetInt64("bookISBN"),
                                    User_name = reader.GetString("borrowerID"),
                                    bookGenre = reader.GetString("bookGenre"),
                                    Borrow = reader.GetDateTime("borrowDate").ToString("yyyy-MM-dd"),
                                    Status = reader.GetString("Status"),
                                    Return = reader.IsDBNull(reader.GetOrdinal("returnDate"))
                                        ? "Not yet returned"
                                        : reader.GetDateTime("returnDate").ToString("yyyy-MM-dd")
                                };

                                listdata.Add(bookTransaction);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving data: " + ex.Message);
                }
            }

            return listdata;
        }

    }
}
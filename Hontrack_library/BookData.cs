using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hontrack_library
{
    internal class BookData
    {
        public int ID { get; set; }
        public long BookNumber { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public string Status { get; set; }
      public int Book_Quantity { get; set; }

        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public List<BookData> BookListData()
        {
            List<BookData> listdata = new List<BookData>();

            using (MySqlConnection mysql = new MySqlConnection(connectionString))
            {
                try
                {
                    mysql.Open();
                    string selectData = "SELECT * FROM book WHERE delete_date IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BookData book = new BookData
                                {
                                    ID = reader.GetInt32("id"),
                                    BookNumber = reader.GetInt64("book_num"),
                                    BookTitle = reader.GetString("bookTitle"),
                                    Author = reader.GetString("author"),
                                    Published = reader.GetDateTime("published"),
                                    Status = reader.GetString("status"),
                                    Book_Quantity = reader.GetInt32("book_stock") 
                                };
                                listdata.Add(book);
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

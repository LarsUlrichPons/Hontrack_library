using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hontrack_library
{
    internal class BookData
    {
     //   public int ID { get; set; }
       
        public string BookTitle { get; set; } 
        public long BookNumber { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }   
        public DateTime Published { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }
      public int Book_Quantity { get; set; }

        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public List<BookData> BookListData(string BookTitleFilter = null)
        {
            List<BookData> listdata = new List<BookData>();

            using (MySqlConnection mysql = new MySqlConnection(connectionString))
            {
                try
                {
                    mysql.Open();
                    string selectData = "SELECT * FROM tbl_book WHERE deleteDate IS NULL";

                    if (!string.IsNullOrEmpty(BookTitleFilter))
                    {
                        selectData += " AND bookTitle LIKE @bookTitleFilter";

                    }

                    using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                    {
                        if (!string.IsNullOrEmpty(BookTitleFilter))
                        {
                            cmd.Parameters.AddWithValue("@bookTitleFilter", "%" + BookTitleFilter + "%");
                        }
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BookData book = new BookData
                                {
                                    //ID = reader.GetInt32("ID"),
                                    BookNumber = reader.GetInt64("bookISBN"),
                                    BookTitle = reader.GetString("bookTitle"),
                                    Author = reader.GetString("bookAuthor"),
                                    Genre = reader.GetString("bookGenre"),
                                    Published = reader.GetDateTime("datePublished"),
                                    Status = reader.GetString("bookStatus"),
                                    Condition = reader.GetString("bookCondition"),
                                    Book_Quantity = reader.GetInt32("bookStock")
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

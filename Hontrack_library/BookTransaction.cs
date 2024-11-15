using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Hontrack_library
{

    internal class BookTransaction
    {
        public int ID { get; set; }
        public long BookNumber { get; set; }
        public string User_name { get; set; }
      //  public DateTime Published { get; set; }
       // public DateTime Borrow { get; set; }
       // public DateTime Return { get; set; }
        public string Status { get; set; }
      

        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public List<BookTransaction> BookListTransaction()
        {
            List<BookTransaction> listdata = new List<BookTransaction>();

            using (MySqlConnection mysql = new MySqlConnection(connectionString))
            {
                try
                {
                    mysql.Open();
                    string selectData = "SELECT * FROM book_transactions WHERE delete_date IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["transaction_id"]}, BookNum: {reader["book_num"]}, User: {reader["user_name"]}");
                                BookTransaction bookTransaction = new BookTransaction
                                {
                                    ID = reader.GetInt32("transaction_id"),
                                    BookNumber = reader.GetInt64("book_num"),
                                    User_name = reader.GetString("user_name"),
                                   // Borrow = reader.GetDateTime("borrow_date"),
                                    //Return = reader.GetDateTime("return_date"),
                                   // Published = reader.GetDateTime("issue_date"),
                                    Status = reader.GetString("status"),
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

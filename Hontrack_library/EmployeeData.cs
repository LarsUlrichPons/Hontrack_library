using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hontrack_library
{
    internal class EmployeeData
    {
        private readonly string connectionString = "server=127.0.0.1; user=root; database=hontrack; password=";

        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }

        public List<EmployeeData> GetEmployeeListData()
        {
            List<EmployeeData> listData = new List<EmployeeData>();

            using (MySqlConnection mysql = new MySqlConnection(connectionString))
            {
                try
                {
                    mysql.Open();
                    string selectData = "SELECT * FROM tbl_users WHERE deletedate IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, mysql))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeData employee = new EmployeeData
                                {
                                    ID = reader.GetInt32("ID"),
                                    Fullname = reader.GetString("fullname"),
                                    Username = reader.GetString("username"),
                                    Password = reader.GetString("password"),
                                    Usertype = reader.GetString("usertype")
                                };
                                listData.Add(employee);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return listData;
        }
    }
}

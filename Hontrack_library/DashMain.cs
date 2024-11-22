using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using LiveCharts.Wpf.Charts.Base;

namespace Hontrack_library
{
    public partial class DashMain : UserControl
    {
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        
       
        public DashMain()
        {
            InitializeComponent();
            displayAb();
            displayBb();
            displayRb();
            LoadPieChart(); // Initialize the live chart

          
        }

        public void displayAb()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string selectData = @"
                SELECT COUNT(ID) 
                FROM book 
                WHERE status = 'Available' AND delete_date IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempAb = 0;
                            if (reader.Read())
                            {
                                tempAb = reader.GetInt32(0); // Read the first column
                                BookQuantity.Text = tempAb.ToString(); // Update the label or textbox
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void displayBb()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string selectData = @"
                SELECT COUNT(ID) 
                FROM book_transactions
                WHERE status = 'borrowed' AND delete_date IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempBb = 0;
                            if (reader.Read())
                            {
                                tempBb = reader.GetInt32(0); // Read the first column
                                borrowQuantity.Text = tempBb.ToString(); // Update the label or textbox
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public void displayRb()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string selectData = @"
                SELECT COUNT(ID) 
                FROM book_transactions
                WHERE status = 'Returned' AND delete_date IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempRb = 0;
                            if (reader.Read())
                            {
                                tempRb = reader.GetInt32(0); // Read the first column
                                returnQuantity.Text = tempRb.ToString(); // Update the label or textbox
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public void LoadPieChart()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string selectData = @"
                        SELECT status, COUNT(*) as count 
                        FROM book_transactions 
                        WHERE delete_date IS NULL 
                        GROUP BY status";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            var statuses = new List<string>();
                            var counts = new ChartValues<int>();

                            while (reader.Read())
                            {
                                statuses.Add(reader.GetString("status"));
                                counts.Add(reader.GetInt32("count"));
                            }

                            // Update the pie chart
                            pieChart1.Series = new SeriesCollection();
                            for (int i = 0; i < statuses.Count; i++)
                            {
                                pieChart1.Series.Add(new PieSeries
                                {
                                    Title = statuses[i],
                                    Values = new ChartValues<int> { counts[i] },
                                    DataLabels = true
                                });
                            }

                            pieChart1.LegendLocation = LegendLocation.Right;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}


 
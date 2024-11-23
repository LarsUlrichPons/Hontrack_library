using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using LiveCharts.Wpf.Charts.Base;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

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
          // SetupPieChart();

           



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
            SELECT bookTitle, COUNT(*) as count 
            FROM book_transactions 
            WHERE delete_date IS NULL 
            GROUP BY bookTitle";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear existing chart data
                            chart1.Series.Clear();
                            chart1.ChartAreas.Clear();
                            chart1.Legends.Clear();

                            // Create a new chart area
                            ChartArea chartArea = new ChartArea("PieChartArea");
                            chart1.ChartAreas.Add(chartArea);

                            // Create a new series for the pie chart
                            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Book Title");
                            series.ChartType = SeriesChartType.Pie;

                            // Add data points from the query
                            while (reader.Read())
                            {
                                string status = reader.GetString("bookTitle");
                                int count = reader.GetInt32("count");

                                series.Points.AddXY(status, count);
                            }

                            // Add the series to the chart
                            chart1.Series.Add(series);

                            // Customize the chart
                            chart1.Legends.Clear(); // Clear existing legends
                            Legend legend = new Legend("Legend");
                            chart1.Legends.Add(legend);

                            // Set data labels
                            series.IsValueShownAsLabel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}


 
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using LiveCharts.Wpf.Charts.Base;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using System.Timers; // Add this for the timer
using Timer = System.Windows.Forms.Timer; // Alias for Windows Forms Timer

namespace Hontrack_library
{
    public partial class DashMain : UserControl
    {
        string connect = "server=127.0.0.1; user=root; database=hontrack; password=";
        private Timer refreshTimer; // Timer for real-time updates

        public DashMain()
        {
            InitializeComponent();

            // Call display methods to initialize data
            displayAb();
            displayBb();
            displayRb();
            LoadStackedColumnChart();
            // Set up the refresh timer
            SetupRealTimeUpdates();
        }

        private void SetupRealTimeUpdates()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Update every 5 seconds (5000 ms)
            refreshTimer.Tick += RefreshData; // Bind to the Tick event
            refreshTimer.Start(); // Start the timer
        }

        private void RefreshData(object sender, EventArgs e)
        {
            // Refresh data dynamically
            displayAb();
            displayBb();
            displayRb();
            LoadStackedColumnChart();
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

        public void LoadStackedColumnChart()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    conn.Open();
                    string selectData = @"
                SELECT 
                    bookTitle, 
                    COUNT(*) as count
                FROM book_transactions
               WHERE delete_date IS NULL
                GROUP BY bookTitle";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear previous chart data
                            chart1.Series.Clear();
                            chart1.ChartAreas.Clear();
                            chart1.Titles.Clear();
                            chart1.Legends.Clear();

                            // Set chart background
                            chart1.BackColor = Color.White; // Chart background
                            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
                            chart1.BorderlineColor = Color.Gray;
                            chart1.BorderlineWidth = 2;

                            // Create a chart area
                            ChartArea chartArea = new ChartArea("ChartArea1")
                            {
                                BackColor = Color.AliceBlue, // Plot area background
                                AxisX =
                        {
                            Title = "Book Titles",
                            LabelStyle = { Angle = -45, Font = new Font("Arial", 10, FontStyle.Regular) },
                            Interval = 1,
                            MajorGrid = { LineColor = Color.LightGray, Enabled = true }
                        },
                                AxisY =
                        {
                            Title = "Borrowed Count",
                            LabelStyle = { Font = new Font("Arial", 10, FontStyle.Regular) },
                            MajorGrid = { LineColor = Color.LightGray, Enabled = true }
                        }
                            };
                            chart1.ChartAreas.Add(chartArea);

                            // Create a single series for borrowed books
                            Series series = new Series("Borrowed Books")
                            {
                                ChartType = SeriesChartType.Column,
                                IsValueShownAsLabel = true,
                                Color = Color.SkyBlue,
                                Font = new Font("Arial", 10, FontStyle.Bold),
                                LabelForeColor = Color.Black,
                                ["LabelStyle"] = "Top"
                            };

                            // Read data and populate series
                            while (reader.Read())
                            {
                                string bookTitle = reader.GetString("bookTitle");
                                int count = reader.GetInt32("count");

                                // Add data point to the series
                                series.Points.AddXY(bookTitle, count);
                            }

                            // Add the series to the chart
                            chart1.Series.Add(series);

                            // Add a title to the chart
                            Title title = new Title("Borrowed Books Count")
                            {
                                Font = new Font("Arial", 14, FontStyle.Bold),
                                ForeColor = Color.DarkBlue,
                                Alignment = ContentAlignment.TopCenter
                            };
                            chart1.Titles.Add(title);
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










    }
}


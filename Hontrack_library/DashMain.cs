using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using LiveCharts.Wpf.Charts.Base;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;


using System.Timers; // Add this for the timer
using Timer = System.Windows.Forms.Timer;
using System.Data;
using System.Text; // Alias for Windows Forms Timer

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
          
        }

        private void DashMain_Load(object sender, EventArgs e)
        {
            displayAb();
            displayBb();
            displayRb();
            LoadChart();
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
            if (this.InvokeRequired)
            {
                // Use Invoke to update the UI from the main thread
                this.Invoke(new Action(() =>
                {
                    displayAb();
                    displayBb();
                    displayRb();
                    LoadChart();
                }));
            }
            else
            {
                // Directly update if already on the main thread
                displayAb();
                displayBb();
                displayRb();
                LoadChart();
            }
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
                        SELECT COUNT(transaction_id ) 
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
                        SELECT COUNT(transaction_id ) 
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

        public void LoadChart()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connect))
                {
                    string query = @"
                SELECT bookTitle, COUNT(*) AS count 
                FROM book_transactions 
                WHERE status = 'borrowed' 
                AND delete_date IS NULL 
                GROUP BY bookTitle";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                 
                    // Set up the chart's data source
                    chart1.DataSource = dataTable;

                    // Configure chart axes titles and appearance
                    ConfigureChartAxes();

                    // Configure chart series appearance
                    ConfigureChartSeries();

                    // Set up chart legend and other visual improvements
                    ConfigureChartAppearance();

                    // Bind data to the chart series
                    BindChartData();

                    // Refresh the chart to display the new data
                    chart1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Show error message if any exception occurs
                DisplayErrorMessage(ex);
            }
        }

        // Configure chart axis labels and appearance
        private void ConfigureChartAxes()
        {
            // Set X and Y axis titles with larger font for better readability
          

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Number of Borrows";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Arial", 8);

            // Rotate X-axis labels to avoid overlap
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 0;

            // Enable labels to fit in a readable format
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = false; // Default single row
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Arial", 8); // Smaller font

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; // Ensure labels are displayed for each bar
        }

        // Configure the chart series appearance
        private void ConfigureChartSeries()
        {
            // Set the bar chart type
            chart1.Series["bookChart"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            // Add data labels to show exact values on the chart
            chart1.Series["bookChart"].IsValueShownAsLabel = true;
            chart1.Series["bookChart"].LabelForeColor = Color.Black;

            // Enable automatic coloring of series
         
           
           // chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            // Set tooltip for data points
            chart1.Series["bookChart"].ToolTip = "#VALX: #VALY borrows";
        }




        // Set up chart legend and other visual improvements
        private void ConfigureChartAppearance()
        {
            // Enable and customize the legend
            chart1.Legends[0].Enabled = false;
            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            chart1.Legends[0].Font = new Font("Arial", 7, FontStyle.Bold);
            chart1.Legends[0].BackColor = Color.White;

            // Set chart background color
            chart1.BackColor = Color.LightGray;

            // Set chart area background color for better contrast
            chart1.ChartAreas["ChartArea1"].BackColor = Color.WhiteSmoke;
        }


        // Helper method to bind data to the chart series
        private void BindChartData()
        {
            // Set the X and Y axis data members for the chart
            chart1.Series["bookChart"].XValueMember = "bookTitle"; // Book titles on the X-axis
            chart1.Series["bookChart"].YValueMembers = "count";     // Count of books on the Y-axis
        }

        // Helper method to display error messages
        private void DisplayErrorMessage(Exception ex)
        {
            MessageBox.Show(
                $"Error: {ex.Message}\nStack Trace: {ex.StackTrace}",
                "Error Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

       






    }
}


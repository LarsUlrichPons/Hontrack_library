using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hontrack_library
{
    public partial class EmDashboard : Form
    {
        public EmDashboard()
        {
            InitializeComponent();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

        }

      
        

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = true;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = true;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = true;
            borrowingHistory1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = true;
        }

    }
}

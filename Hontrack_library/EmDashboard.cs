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
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dashMain2.Visible = true;
            borrowBook2.Visible = false;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dashMain2.Visible = false;
            borrowBook2.Visible = true;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashMain2.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = true;
            borrowingHistory2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashMain2.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = true;
        }

    }
}

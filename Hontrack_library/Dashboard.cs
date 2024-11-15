using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Hontrack_library
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          dashMain1.Visible = true;
            borrowBook2.Visible = true;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
            issueBook2.Visible = false;
            userManagement2.Visible = false;

        }

      

        private void BbButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook2.Visible = true;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
            issueBook2.Visible = false;
            userManagement2.Visible = false;
        }

        private void RbButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = true;
            borrowingHistory2.Visible = false;
            issueBook2.Visible = false;
            userManagement2.Visible = false;

        }

        private void BhButton_Click(object sender, EventArgs e)
        {
           dashMain1.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = true;
            issueBook2.Visible = false;
            userManagement2.Visible = false;
        }

        private void BiButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
            issueBook2.Visible = true;
            userManagement2.Visible = false;
        }

        private void MuButton_Click(object sender, EventArgs e)
        {

            dashMain1.Visible = false;
            borrowBook2.Visible = false;
            returnbook2.Visible = false;
            borrowingHistory2.Visible = false;
            issueBook2.Visible = false;
            userManagement2.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        
    }
}

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


        public void BookTransaction() 
        {
            borrowedBookData bookData = new borrowedBookData();
            List<borrowedBookData> listdata = bookData.BookListTransaction();


        }

        public void UserManagement() 
        {
            EmployeeData employeeData = new EmployeeData();
            List<EmployeeData> listdata = employeeData.GetEmployeeListData();
        }

        public void BorrowedBookData() 
        {

            BookTransaction bookData = new BookTransaction();
            List<BookTransaction> listdata = bookData.BookListTransaction();
        }
        public void BookData() 
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();

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

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        public void Refresh() 
        {

            try
            {
                // Refresh data instantly
                BookTransaction();
                UserManagement();
                BorrowedBookData();
                BookData();

                //MessageBox.Show("Data refreshed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void dashMain1_Load(object sender, EventArgs e)
         {

         }

        private void DbButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = true;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            Refresh();
        }

        private void BbButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = true;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            Refresh();
        }

        private void RbButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = true;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            Refresh();

        }

        private void BhButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = true;
            issueBook1.Visible = false;
            userManagement1.Visible = false;
            Refresh();
        }

        private void BiButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = true;
            userManagement1.Visible = false;
            Refresh();
        }

        private void MuButton_Click(object sender, EventArgs e)
        {
            dashMain1.Visible = false;
            borrowBook1.Visible = false;
            returnbook1.Visible = false;
            borrowingHistory1.Visible = false;
            issueBook1.Visible = false;
            userManagement1.Visible = true;
            Refresh();
        }
    }
}

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
    public partial class Returnbook : UserControl
    {
        public Returnbook()
        {
            InitializeComponent();
            Status.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void IDtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Contacttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BookTitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BIssueTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AuthorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {

            IDtextbox.Clear();
            Nametextbox.Clear();
            Contacttextbox.Clear();
            BookTitleTextBox.Clear();
            BIssueTextBox.Clear();
            AuthorTextBox.Clear();
            Status.SelectedIndex = -1;
        }

     
    }
}

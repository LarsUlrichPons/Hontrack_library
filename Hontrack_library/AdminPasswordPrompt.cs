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
    public partial class AdminPasswordPrompt : Form
    {
        public string AdminPassword { get; private set; }

        public AdminPasswordPrompt()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*'; // Mask password

        }

        private void ok_Click(object sender, EventArgs e)
        {
            AdminPassword = passwordTextBox.Text.Trim();
            DialogResult = DialogResult.OK; // Set the DialogResult
            this.Close(); // Close the form

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Handle cancel
            this.Close();
        }
    }
}

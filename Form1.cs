using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPG122_FINAL_ASSESSMENT
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    private void loginButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;

        if ((username == "admin" && password == "sot2025") ||
            (username == "locum" && password == "care2025"))
        {
            messageLabel.ForeColor = Color.LightGreen;
            messageLabel.Text = "Login successful";

            // Open Intake form and hide login while intake is open
            clientAndFeeCalc form2 = new clientAndFeeCalc();
            form2.FormClosed += (s, ev) => { this.Show(); }; // show login again if needed
            this.Hide();
            form2.Show(); // non-modal so user can come back to login when intake closes
        }
        else
        {
            messageLabel.ForeColor = Color.LightYellow;
            messageLabel.Text = "Invalid credentials. Try again.";
            passwordTextBox.Clear();
            passwordTextBox.Focus();
        }
    }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exit the application
            this.Close();
        }
    }
}

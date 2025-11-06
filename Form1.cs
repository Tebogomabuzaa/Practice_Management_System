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
            // Capture Input
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate Credentials (Hardcoded username & password)
            if (username == "admin" && password == "sot2025" ||
                username == "locum" && password == "care2025")
            {
                // Use module for password validation
                // If valid, message label show login successful
                messageLabel.ForeColor = Color.LightGreen;
                messageLabel.Text = "Login Successfull";

                // Open Form2 (Intake) and hide form
                clientAndFeeCalc Form2 = new clientAndFeeCalc();
                Form2.ShowDialog();

                // Hide Form1
                this.Hide();
            }
            else
            {
                // Display invalid credentials entered message
                messageLabel.ForeColor = Color.LightYellow;
                messageLabel.Text = "Invalid Credentials. Try again.";

                // Clear the password TextBox and set focus()
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

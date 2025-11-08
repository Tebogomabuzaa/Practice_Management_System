using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;      // For culture-aware parsing

namespace CMPG122_FINAL_ASSESSMENT
{
    public partial class clientAndFeeCalc : Form
    {
        // Data arrays for services
        private string[] serviceNames = { "Assessment", "Therapy Session", "Report" };
        private decimal[] servicePrices = { 500m, 300m, 250m };

        private Random rnd = new Random();
        private const string RecordsFile = "SOT_records.txt";

        public clientAndFeeCalc()
        {
            InitializeComponent();
            LoadRecordsFromFile();
            PopulateServices();
        }

        private void PopulateServices()
        {
            if (servicesListBox.Items.Count == 0)
            {
                for (int i = 0; i < serviceNames.Length; i++)
                {
                    servicesListBox.Items.Add(serviceNames[i]);
                }
            }
        }


        // Method that returns a value: calculates total fee using current form selections
        private decimal CalculateTotalFee()
        {
            decimal total = 0m;

            // Sum selected service fees (array search)
            for (int i = 0; i < servicesListBox.CheckedItems.Count; i++)
            {
                string selected = servicesListBox.CheckedItems[i].ToString();
                for (int k = 0; k < serviceNames.Length; k++)
                {
                    if (selected == serviceNames[k])
                    {
                        total += servicePrices[k];
                        break;
                    }
                }
            }

            // Determine funding type and apply multiplier using switch(string)
            string funding = "";
            if (privateRadioButton.Checked)
            {
                funding = "Private";
            }
            else if (medicalRadioButton.Checked)
            {
                funding = "Medical Aid";
            }

            switch (funding)
            {
                case "Private":
                    // No change
                    break;
                case "Medical Aid":
                    total = total * 80m / 100m;    // 20 % discount
                    break;
                default:
                    break;
            }

            // Add ons
            if (addOnReportCheckBox.Checked)
            {
                total = total + 300m;
            }

            return total;
        }

        // Method with paramter that changes a monetary value (ref)
        private void ApplyFeeAdjustment(ref decimal fee, decimal percentAdjustment)
        {
            if (percentAdjustment == 0m)
                return;
            fee = fee - (fee * percentAdjustment / 100m);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (servicesListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one service.");
                return;
            }

            decimal total = CalculateTotalFee();
            totalFeeTextBox.Text = "R " + total.ToString("F2");
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (servicesListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select at least one service before registering.");
                return;
            }

            // Calculate base total using the method that returns decimal
            decimal total = CalculateTotalFee();

            // Ref-method to modify the monetary value
            ApplyFeeAdjustment(ref total, 5m);

            // Generate simple client ID using loop
            string clientId = "SOT-";
            for (int i = 0; i < 6;  i++)
            {
                clientId = clientId + rnd.Next(0, 10).ToString();
            }

            string name = fullNameTextBox.Text;
            string age = ageTextBox.Text;
            string funding;

            if (privateRadioButton.Checked)
            {
                funding = "Private";
            }
            else
            {
                funding = "Medical Aid";
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Simple tab-separated reord (fee stored as F2 string)
            string line = timestamp + "\t" + clientId + "\t" + name + "\t" + age + "\t" + funding + "\t" + total.ToString("F2");

            try
            {
                StreamWriter writer = File.AppendText(RecordsFile);
                writer.WriteLine(line);
                writer.Close();

                listRecords.Items.Add(clientId + " | " + name + " | R " + total.ToString("F2"));
                totalFeeTextBox.Text = "R " + total.ToString("F2");
                MessageBox.Show("Client registered successfully. ID: " + clientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all textboxes, uncheck boxes, deselect list items
            fullNameTextBox.Clear();
            ageTextBox.Clear();

            // Uncheck all items in CheckedListBox
            for (int i = 0; i < servicesListBox.Items.Count; i++)
            {
                servicesListBox.SetItemChecked(i, false);
            }

            addOnReportCheckBox.Checked = false;
            privateRadioButton.Checked = true;
            totalFeeTextBox.Text = "R 0.00";
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            SOTDashboard dash = new SOTDashboard();
            dash.FormClosed += (s, ev) => { this.Show(); };
            dash.Show();
            this.Hide();
        }

        private void LoadRecordsFromFile()
        {
            if (!File.Exists(RecordsFile))
            {
                return;
            }

            try
            {
                StreamReader reader = new StreamReader(RecordsFile);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 6)
                    {
                        string id = parts[1];
                        string name = parts[2];
                        string fee = parts[5];
                        listRecords.Items.Add(id + " | " + name + " | R " + fee);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading records: " + ex.Message);
            }
        }
    }
}

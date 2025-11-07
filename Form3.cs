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

namespace CMPG122_FINAL_ASSESSMENT
{
    public partial class SOTDashboard : Form
    {
        private const string RecordsFile = "SOT_records.txt";
        public SOTDashboard()
        {
            InitializeComponent();
            LoadKpis();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            // Refresh button: reload KPIs and recent records
            LoadKpis();
        }

        // Export summary: Appends a short summary line to SOT_summary_exports.txt
        private void exportSummaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                int clients = 0;
                decimal revenue = 0m;

                if (File.Exists(RecordsFile))
                {
                    StreamReader reader = new StreamReader(RecordsFile);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            continue;
                        }
                        string[] parts = line.Split('\t');
                        if(parts.Length >= 6)
                        {
                            clients = clients + 1;
                            decimal fee = 0m;
                            decimal.TryParse(parts[5], out fee);
                            revenue = revenue + fee;
                        }
                    }
                    reader.Close();
                }

                StreamWriter writer = File.AppendText("SOT_summary_exports.txt");
                string summary = DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\tClients: " + "\tRevenue: R " + revenue.ToString("F2");
                writer.WriteLine(summary);
                writer.Close();

                MessageBox.Show("Summary exported (appended).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // LoadKpis: read records file, compute totals, determine background color, show recent rows
        internal void LoadKpis()
        {
            listViewRecent.Items.Clear();

            if (!File.Exists(RecordsFile))
            {
                // No records yet - set defaults and a neutral background
                totalClientsLabel.Text = "0";
                totalRevenueLabel.Text = "0";
                avgFeeLabel.Text = "R 0.00";
                outstandingClaimsLabel.Text = "0";
                this.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            int totalClients = 0;
            decimal totalRevenue = 0m;
            int outstanding = 0;

            try
            {
                StreamReader reader = new StreamReader(RecordsFile);
                string line;

                // Circular buffer for last 8 records (simple array)
                string[] recentBuffer = new string[0];
                int recentIndex = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }

                    string[] parts = line.Split('\t');

                    if (parts.Length < 6)
                    {
                        continue;
                    }

                    totalClients = totalClients + 1;

                    decimal fee = 0m;
                    decimal.TryParse(parts[5], out fee);
                    totalRevenue = totalRevenue + fee;

                    if (fee <= 0m)
                    {
                        outstanding = outstanding + 1;
                    }

                    recentBuffer[recentIndex % 8] = line;
                    recentIndex = recentIndex + 1;
                
                }

                reader.Close();

                decimal avg = 0m;
                if (totalClients > 0)
                {
                    avg = totalRevenue / totalClients;
                }

                // Update KPI labels
                totalClientsLabel.Text = totalClients.ToString();
                totalRevenueLabel.Text = "R " + totalRevenue.ToString("F2");
                avgFeeLabel.Text = "R " + avg.ToString("F2");
                outstandingClaimsLabel.Text = outstanding.ToString();

                // Background thresholds
                if (totalRevenue >= 10000m)
                {
                    this.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (totalRevenue >= 3000m)
                {
                    this.BackColor = System.Drawing.Color.LightYellow;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.LightCoral;
                }

                // Populate recent rows
                int count = recentIndex;
                int toTake = (count < 8) ? count : 8;
                for (int i = 0; i < toTake; i++)
                {
                    int index = (recentIndex - 1 - i) % 8;
                    if (index < 0)
                    {
                        index += 8;
                    }

                    string rec = recentBuffer[index];

                    if (string.IsNullOrEmpty(rec))
                    {
                        continue;
                    }

                    string[] parts = rec.Split('\t');

                    // Check again before indexing
                    if (parts.Length < 6)
                    {
                        continue;
                    }

                    string date = parts[0];
                    string id = parts[1];
                    string name = parts[2];
                    string feeStr = parts[5];
                    string feeDisplay = "R " + feeStr;

                    ListViewItem item = new ListViewItem
                        (new string[]
                        {
                            date,
                            id,
                            name,
                            feeDisplay,
                        });
                    listViewRecent.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPI data: " + ex.Message);
            }
        }
    }
}

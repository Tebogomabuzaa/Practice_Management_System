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
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    // Count every non-empty line as a client
                    clients++;

                    // Parse fee from tab-separated file
                    string[] parts = line.Split('\t');
                    string feeToken = null;
                    if (parts.Length >= 6)
                    {
                        feeToken = parts[5];
                    }
                    else
                    {
                        // Assume last token is the fee
                        string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length > 0) feeToken = tokens[tokens.Length - 1];
                    }

                    if (!string.IsNullOrWhiteSpace(feeToken))
                    {
                        // remove any leading "R" or currency symbols, then parse using current culture
                        feeToken = feeToken.Replace("R", "").Replace("r", "");
                        decimal fee = 0m;
                        decimal.TryParse(feeToken, NumberStyles.Any, CultureInfo.CurrentCulture, out fee);
                        revenue += fee;
                    }
                }

            }


            // Build summary (clients count). Use current culture formatting.
            string summary = $"{DateTime.Now:yyyy-MM-dd HH:mm}\tClients: {clients}\tRevenue: R {revenue.ToString("F2", CultureInfo.CurrentCulture)}";

            // Preview to confirm before writing
            DialogResult confirmation = MessageBox.Show("Export preview:\n\n" + summary + "\n\nWrite this to SOT_summary_exports.txt?", "Export Preview", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            // Append to file
            StreamWriter writer = File.AppendText("SOT_summary_exports.txt");
                
            writer.WriteLine(summary);

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
                totalRevenueLabel.Text = "R 0.00";
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
                int fileLineNumber = 0;

                // Circular buffer for last 8 records
                string[] recentBuffer = new string[8];
                int recentIndex = 0;

                int badLinesCount = 0;
                string firstBadLine = null;
                int firstBadLineNumber = -1;

                while ((line = reader.ReadLine()) != null)
                {
                    fileLineNumber++;
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Tab-split first
                    string[] parts = line.Split('\t');

                    string date = "";
                    string id = "";
                    string name = "";
                    string funding = "";
                    string feeStr = "";
                    decimal fee = 0m;
                    bool recordAccepted = false;

                    if (parts.Length >= 6)
                    {
                        // expected tab-separated format
                        date = parts[0];
                        id = parts[1];
                        name = parts[2];
                        funding = parts[4];
                        feeStr = parts[5];
                        decimal.TryParse(feeStr, out fee); // uses current culture
                        recordAccepted = true;
                    }
                    else
                    {
                        // fallback: tokenise by spaces
                        string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (tokens.Length >= 6)
                        {
                            // date likely first two tokens
                            date = tokens[0];
                            if (tokens.Length > 1)
                            {
                                date += " " + tokens[1];
                            }

                            if (tokens.Length >= 3)
                            {
                                id = tokens[2];
                            }

                            // find age token scanning from the end
                            int ageIndex = -1;
                            for (int i = tokens.Length - 1; i >= 3; i--)
                            {
                                if (int.TryParse(tokens[i], out int tmp)) 
                                {
                                    ageIndex = i;
                                    break; 
                                }
                            }

                            if (ageIndex != -1 && ageIndex < tokens.Length)
                            {
                                // fee assumed last token
                                feeStr = tokens[tokens.Length - 1];
                                decimal.TryParse(feeStr, out fee);

                                if (ageIndex - 1 >= 3)
                                {
                                    name = tokens[3];
                                    for (int j = 4; j <= ageIndex - 1; j++)
                                    {
                                        name += " " + tokens[j];
                                    }
                                }
                                else name = "";

                                // funding tokens between ageIndex+1 and tokens.Length-2
                                if (ageIndex + 1 <= tokens.Length - 2)
                                {
                                    funding = tokens[ageIndex + 1];
                                    for (int j = ageIndex + 2; j <= tokens.Length - 2; j++)
                                    {
                                        funding += " " + tokens[j];
                                    }
                                }
                                else funding = "";

                                recordAccepted = true;
                            }
                        }
                    }

                    if (!recordAccepted)
                    {
                        badLinesCount++;
                        if (firstBadLine == null)
                        {
                            firstBadLine = line;
                            firstBadLineNumber = fileLineNumber;
                        }

                        continue; // skip line
                    }

                    // Accept the record
                    totalClients++;
                    totalRevenue += fee;
                    if (fee <= 0m)
                    {
                        outstanding++;
                    }

                    recentBuffer[recentIndex % 8] = line;
                    recentIndex++;
                }

                reader.Close();

                // Compute averages
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

                // set the text to match the small KPI
                revenueLabelKPI.Text = totalRevenueLabel.Text;

                if (totalRevenue >= 10000m)
                {
                    revenueLabelKPI.BackColor = Color.FromArgb(0, 128, 0);
                    revenueLabelKPI.ForeColor = Color.White;
                }
                else
                {
                    revenueLabelKPI.BackColor = Color.FromArgb(178, 34, 34);
                    revenueLabelKPI.ForeColor = Color.White;
                }

                // Padding so text doesn't touch edges
                revenueLabelKPI.Padding = new Padding(8);

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

                // Populate recent rows (most recent first)
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

                    // extract display pieces from rec
                    string displayDate = "";
                    string displayId = "";
                    string displayName = "";
                    string displayFee = "";

                    string[] parts2 = rec.Split('\t');
                    if (parts2.Length >= 6)
                    {
                        displayDate = parts2[0];
                        displayId = parts2[1];
                        displayName = parts2[2];
                        displayFee = parts2[5];
                    }
                    else
                    {
                        string[] tokens = rec.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length >= 3)
                        {
                            displayDate = tokens[0];
                            if (tokens.Length > 1)
                            {
                                displayDate += " " + tokens[1];
                            }

                            displayId = (tokens.Length >= 3) ? tokens[2] : "";

                            // find age index
                            int ageIndex = -1;
                            for (int j = tokens.Length - 1; j >= 3; j--)
                            {
                                if (int.TryParse(tokens[j], out int tmp))
                                {
                                    ageIndex = j;
                                    break;
                                }
                            }

                            if (ageIndex != -1)
                            {
                                if (ageIndex - 1 >= 3)
                                {
                                    displayName = tokens[3];
                                    for (int j = 4; j <= ageIndex - 1; j++)
                                    {
                                        displayName += " " + tokens[j];
                                    }
                                }
                                displayFee = tokens[tokens.Length - 1];
                            }
                        }
                    }

                    string feeDisplay = "R " + displayFee;
                    ListViewItem item = new ListViewItem(new string[] { displayDate, displayId, displayName, feeDisplay });
                    listViewRecent.Items.Add(item);
                }

                if (badLinesCount > 0)
                {
                    string msg = "Warning: " + badLinesCount.ToString() + " malformed record(s) were skipped while loading KPIs.";
                    if (firstBadLine != null)
                    {
                        msg += Environment.NewLine + Environment.NewLine
                            + "First bad line (line " + firstBadLineNumber.ToString() + "):" + Environment.NewLine
                            + firstBadLine;
                    }
                    MessageBox.Show(msg, "SOT Dashboard - Data Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPI data: " + ex.Message);
            }
        }
    }
}

namespace CMPG122_FINAL_ASSESSMENT
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.recentRegistrationsGroupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewRecent = new System.Windows.Forms.ListBox();
            this.panelKpiVisual = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.exportSummaryButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.revenueLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.avgFeeLabel = new System.Windows.Forms.Label();
            this.outstandingClaimsLabel = new System.Windows.Forms.Label();
            this.totalRevenueLabel = new System.Windows.Forms.Label();
            this.totalClientsLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.recentRegistrationsGroupBox2.SuspendLayout();
            this.panelKpiVisual.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(140, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "SOT - Practice Dashboard";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMPG122_FINAL_ASSESSMENT.Properties.Resources.Untitled_design_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(31, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // recentRegistrationsGroupBox2
            // 
            this.recentRegistrationsGroupBox2.Controls.Add(this.listViewRecent);
            this.recentRegistrationsGroupBox2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentRegistrationsGroupBox2.Location = new System.Drawing.Point(31, 255);
            this.recentRegistrationsGroupBox2.Name = "recentRegistrationsGroupBox2";
            this.recentRegistrationsGroupBox2.Size = new System.Drawing.Size(463, 147);
            this.recentRegistrationsGroupBox2.TabIndex = 7;
            this.recentRegistrationsGroupBox2.TabStop = false;
            this.recentRegistrationsGroupBox2.Text = "Recent Registrations List";
            // 
            // listViewRecent
            // 
            this.listViewRecent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listViewRecent.FormattingEnabled = true;
            this.listViewRecent.ItemHeight = 20;
            this.listViewRecent.Location = new System.Drawing.Point(6, 32);
            this.listViewRecent.Name = "listViewRecent";
            this.listViewRecent.Size = new System.Drawing.Size(445, 104);
            this.listViewRecent.TabIndex = 0;
            // 
            // panelKpiVisual
            // 
            this.panelKpiVisual.Controls.Add(this.revenueLabel);
            this.panelKpiVisual.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelKpiVisual.Location = new System.Drawing.Point(500, 97);
            this.panelKpiVisual.Name = "panelKpiVisual";
            this.panelKpiVisual.Size = new System.Drawing.Size(274, 221);
            this.panelKpiVisual.TabIndex = 8;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Navy;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.backButton.Location = new System.Drawing.Point(500, 371);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(274, 31);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            // 
            // exportSummaryButton
            // 
            this.exportSummaryButton.BackColor = System.Drawing.Color.Navy;
            this.exportSummaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exportSummaryButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportSummaryButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportSummaryButton.Location = new System.Drawing.Point(640, 334);
            this.exportSummaryButton.Name = "exportSummaryButton";
            this.exportSummaryButton.Size = new System.Drawing.Size(134, 31);
            this.exportSummaryButton.TabIndex = 13;
            this.exportSummaryButton.Text = "Export Summary";
            this.exportSummaryButton.UseVisualStyleBackColor = false;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Navy;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.refreshButton.Location = new System.Drawing.Point(500, 334);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(134, 31);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            // 
            // revenueLabel
            // 
            this.revenueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.revenueLabel.Location = new System.Drawing.Point(15, 10);
            this.revenueLabel.Name = "revenueLabel";
            this.revenueLabel.Size = new System.Drawing.Size(246, 203);
            this.revenueLabel.TabIndex = 0;
            this.revenueLabel.Text = "label10";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.avgFeeLabel);
            this.panel2.Controls.Add(this.outstandingClaimsLabel);
            this.panel2.Controls.Add(this.totalRevenueLabel);
            this.panel2.Controls.Add(this.totalClientsLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(31, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 152);
            this.panel2.TabIndex = 15;
            // 
            // avgFeeLabel
            // 
            this.avgFeeLabel.AutoSize = true;
            this.avgFeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.avgFeeLabel.ForeColor = System.Drawing.Color.Navy;
            this.avgFeeLabel.Location = new System.Drawing.Point(222, 82);
            this.avgFeeLabel.Name = "avgFeeLabel";
            this.avgFeeLabel.Size = new System.Drawing.Size(66, 24);
            this.avgFeeLabel.TabIndex = 15;
            this.avgFeeLabel.Text = "label9";
            // 
            // outstandingClaimsLabel
            // 
            this.outstandingClaimsLabel.AutoSize = true;
            this.outstandingClaimsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.outstandingClaimsLabel.ForeColor = System.Drawing.Color.Navy;
            this.outstandingClaimsLabel.Location = new System.Drawing.Point(222, 116);
            this.outstandingClaimsLabel.Name = "outstandingClaimsLabel";
            this.outstandingClaimsLabel.Size = new System.Drawing.Size(66, 24);
            this.outstandingClaimsLabel.TabIndex = 14;
            this.outstandingClaimsLabel.Text = "label8";
            // 
            // totalRevenueLabel
            // 
            this.totalRevenueLabel.AutoSize = true;
            this.totalRevenueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalRevenueLabel.ForeColor = System.Drawing.Color.Navy;
            this.totalRevenueLabel.Location = new System.Drawing.Point(222, 47);
            this.totalRevenueLabel.Name = "totalRevenueLabel";
            this.totalRevenueLabel.Size = new System.Drawing.Size(66, 24);
            this.totalRevenueLabel.TabIndex = 13;
            this.totalRevenueLabel.Text = "label7";
            // 
            // totalClientsLabel
            // 
            this.totalClientsLabel.AutoSize = true;
            this.totalClientsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalClientsLabel.ForeColor = System.Drawing.Color.Navy;
            this.totalClientsLabel.Location = new System.Drawing.Point(222, 12);
            this.totalClientsLabel.Name = "totalClientsLabel";
            this.totalClientsLabel.Size = new System.Drawing.Size(66, 24);
            this.totalClientsLabel.TabIndex = 12;
            this.totalClientsLabel.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Outstanding Claims:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Avg Fee:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Revenue: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total Clients:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.panelKpiVisual);
            this.Controls.Add(this.exportSummaryButton);
            this.Controls.Add(this.recentRegistrationsGroupBox2);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "SOT - Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.recentRegistrationsGroupBox2.ResumeLayout(false);
            this.panelKpiVisual.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox recentRegistrationsGroupBox2;
        private System.Windows.Forms.ListBox listViewRecent;
        private System.Windows.Forms.Panel panelKpiVisual;
        private System.Windows.Forms.Label revenueLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button exportSummaryButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label avgFeeLabel;
        private System.Windows.Forms.Label outstandingClaimsLabel;
        private System.Windows.Forms.Label totalRevenueLabel;
        private System.Windows.Forms.Label totalClientsLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
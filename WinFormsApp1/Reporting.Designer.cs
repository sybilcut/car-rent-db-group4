namespace WinFormsApp1
{
    partial class Reporting
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
            this.button1 = new System.Windows.Forms.Button();
            this.IncomeButton = new System.Windows.Forms.RadioButton();
            this.HighRentedButton = new System.Windows.Forms.RadioButton();
            this.HighKMButton = new System.Windows.Forms.RadioButton();
            this.CityRentedButton = new System.Windows.Forms.RadioButton();
            this.AvgEarningButton = new System.Windows.Forms.RadioButton();
            this.nonMemberButton = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IncomeButton
            // 
            this.IncomeButton.AutoSize = true;
            this.IncomeButton.Location = new System.Drawing.Point(12, 12);
            this.IncomeButton.Name = "IncomeButton";
            this.IncomeButton.Size = new System.Drawing.Size(254, 29);
            this.IncomeButton.TabIndex = 7;
            this.IncomeButton.TabStop = true;
            this.IncomeButton.Text = "Branch with highest income";
            this.IncomeButton.UseVisualStyleBackColor = true;
            // 
            // HighRentedButton
            // 
            this.HighRentedButton.AutoSize = true;
            this.HighRentedButton.Location = new System.Drawing.Point(12, 47);
            this.HighRentedButton.Name = "HighRentedButton";
            this.HighRentedButton.Size = new System.Drawing.Size(312, 29);
            this.HighRentedButton.TabIndex = 8;
            this.HighRentedButton.TabStop = true;
            this.HighRentedButton.Text = "Most rented vehicle type anywhere";
            this.HighRentedButton.UseVisualStyleBackColor = true;
            // 
            // HighKMButton
            // 
            this.HighKMButton.AutoSize = true;
            this.HighKMButton.Location = new System.Drawing.Point(12, 79);
            this.HighKMButton.Name = "HighKMButton";
            this.HighKMButton.Size = new System.Drawing.Size(249, 29);
            this.HighKMButton.TabIndex = 9;
            this.HighKMButton.TabStop = true;
            this.HighKMButton.Text = "Highest kms of any vehicle";
            this.HighKMButton.UseVisualStyleBackColor = true;
            // 
            // CityRentedButton
            // 
            this.CityRentedButton.AutoSize = true;
            this.CityRentedButton.Location = new System.Drawing.Point(12, 114);
            this.CityRentedButton.Name = "CityRentedButton";
            this.CityRentedButton.Size = new System.Drawing.Size(249, 29);
            this.CityRentedButton.TabIndex = 10;
            this.CityRentedButton.TabStop = true;
            this.CityRentedButton.Text = "Most rented vehicle by city";
            this.CityRentedButton.UseVisualStyleBackColor = true;
            // 
            // AvgEarningButton
            // 
            this.AvgEarningButton.AutoSize = true;
            this.AvgEarningButton.Location = new System.Drawing.Point(12, 149);
            this.AvgEarningButton.Name = "AvgEarningButton";
            this.AvgEarningButton.Size = new System.Drawing.Size(225, 29);
            this.AvgEarningButton.TabIndex = 11;
            this.AvgEarningButton.TabStop = true;
            this.AvgEarningButton.Text = "Avg earnings by branch";
            this.AvgEarningButton.UseVisualStyleBackColor = true;
            // 
            // nonMemberButton
            // 
            this.nonMemberButton.AutoSize = true;
            this.nonMemberButton.Location = new System.Drawing.Point(12, 184);
            this.nonMemberButton.Name = "nonMemberButton";
            this.nonMemberButton.Size = new System.Drawing.Size(316, 29);
            this.nonMemberButton.TabIndex = 12;
            this.nonMemberButton.TabStop = true;
            this.nonMemberButton.Text = "Non-member w/ most transactions";
            this.nonMemberButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(364, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(424, 219);
            this.dataGridView1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(364, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(424, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // Reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(823, 286);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nonMemberButton);
            this.Controls.Add(this.AvgEarningButton);
            this.Controls.Add(this.CityRentedButton);
            this.Controls.Add(this.HighKMButton);
            this.Controls.Add(this.HighRentedButton);
            this.Controls.Add(this.IncomeButton);
            this.Controls.Add(this.button1);
            this.Name = "Reporting";
            this.Text = "Reporting";
            this.Load += new System.EventHandler(this.Reporting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label label5;
        private Label label6;
        private RadioButton IncomeButton;
        private RadioButton HighRentedButton;
        private RadioButton HighKMButton;
        private RadioButton CityRentedButton;
        private RadioButton AvgEarningButton;
        private RadioButton nonMemberButton;
        private DataGridView dataGridView1;
        private Label label7;
    }
}
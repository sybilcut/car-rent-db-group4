namespace WinFormsApp1
{
    partial class NewRental
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.switchViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.CheckAvailability = new System.Windows.Forms.Button();
            this.Customer = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.searchResult = new System.Windows.Forms.CheckedListBox();
            this.PickupLocation = new System.Windows.Forms.ComboBox();
            this.DropoffLocation = new System.Windows.Forms.ComboBox();
            this.VehicleTypes = new System.Windows.Forms.ComboBox();
            this.VehicleClass = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.customerDropoffDate = new System.Windows.Forms.DateTimePicker();
            this.customerPickupDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Customer.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 33);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // switchViewToolStripMenuItem
            // 
            this.switchViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.switchViewToolStripMenuItem.Name = "switchViewToolStripMenuItem";
            this.switchViewToolStripMenuItem.Size = new System.Drawing.Size(121, 29);
            this.switchViewToolStripMenuItem.Text = "Switch View";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Checked = true;
            this.customerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 713);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 21;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckAvailability
            // 
            this.CheckAvailability.Location = new System.Drawing.Point(12, 713);
            this.CheckAvailability.Name = "CheckAvailability";
            this.CheckAvailability.Size = new System.Drawing.Size(172, 34);
            this.CheckAvailability.TabIndex = 20;
            this.CheckAvailability.Text = "Check Availability";
            this.CheckAvailability.UseVisualStyleBackColor = true;
            this.CheckAvailability.Click += new System.EventHandler(this.button1_Click);
            // 
            // Customer
            // 
            this.Customer.Controls.Add(this.tabPage3);
            this.Customer.Location = new System.Drawing.Point(13, 126);
            this.Customer.Name = "Customer";
            this.Customer.SelectedIndex = 0;
            this.Customer.Size = new System.Drawing.Size(810, 581);
            this.Customer.TabIndex = 19;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.searchResult);
            this.tabPage3.Controls.Add(this.PickupLocation);
            this.tabPage3.Controls.Add(this.DropoffLocation);
            this.tabPage3.Controls.Add(this.VehicleTypes);
            this.tabPage3.Controls.Add(this.VehicleClass);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.customerDropoffDate);
            this.tabPage3.Controls.Add(this.customerPickupDate);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(802, 543);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "New Rental";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // searchResult
            // 
            this.searchResult.FormattingEnabled = true;
            this.searchResult.Location = new System.Drawing.Point(19, 272);
            this.searchResult.Name = "searchResult";
            this.searchResult.Size = new System.Drawing.Size(653, 256);
            this.searchResult.TabIndex = 30;
            this.searchResult.SelectedIndexChanged += new System.EventHandler(this.searchResult_SelectedIndexChanged);
            // 
            // PickupLocation
            // 
            this.PickupLocation.FormattingEnabled = true;
            this.PickupLocation.Location = new System.Drawing.Point(157, 108);
            this.PickupLocation.Name = "PickupLocation";
            this.PickupLocation.Size = new System.Drawing.Size(300, 33);
            this.PickupLocation.TabIndex = 29;
            this.PickupLocation.SelectedIndexChanged += new System.EventHandler(this.PickupLocation_SelectedIndexChanged);
            // 
            // DropoffLocation
            // 
            this.DropoffLocation.FormattingEnabled = true;
            this.DropoffLocation.Location = new System.Drawing.Point(157, 156);
            this.DropoffLocation.Name = "DropoffLocation";
            this.DropoffLocation.Size = new System.Drawing.Size(300, 33);
            this.DropoffLocation.TabIndex = 28;
            this.DropoffLocation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // VehicleTypes
            // 
            this.VehicleTypes.FormattingEnabled = true;
            this.VehicleTypes.Location = new System.Drawing.Point(157, 210);
            this.VehicleTypes.Name = "VehicleTypes";
            this.VehicleTypes.Size = new System.Drawing.Size(300, 33);
            this.VehicleTypes.TabIndex = 27;
            this.VehicleTypes.SelectedIndexChanged += new System.EventHandler(this.VehicleTypes_SelectedIndexChanged);
            // 
            // VehicleClass
            // 
            this.VehicleClass.AutoSize = true;
            this.VehicleClass.Location = new System.Drawing.Point(10, 213);
            this.VehicleClass.Name = "VehicleClass";
            this.VehicleClass.Size = new System.Drawing.Size(111, 25);
            this.VehicleClass.TabIndex = 26;
            this.VehicleClass.Text = "Vehicle Class";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 159);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(148, 25);
            this.label19.TabIndex = 24;
            this.label19.Text = "Dropoff Location";
            // 
            // customerDropoffDate
            // 
            this.customerDropoffDate.Location = new System.Drawing.Point(157, 63);
            this.customerDropoffDate.Name = "customerDropoffDate";
            this.customerDropoffDate.Size = new System.Drawing.Size(300, 31);
            this.customerDropoffDate.TabIndex = 23;
            this.customerDropoffDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // customerPickupDate
            // 
            this.customerPickupDate.Location = new System.Drawing.Point(157, 20);
            this.customerPickupDate.Name = "customerPickupDate";
            this.customerPickupDate.Size = new System.Drawing.Size(300, 31);
            this.customerPickupDate.TabIndex = 22;
            this.customerPickupDate.Value = new System.DateTime(2022, 4, 12, 20, 2, 28, 0);
            this.customerPickupDate.ValueChanged += new System.EventHandler(this.pickupDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pickup Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Dropoff Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pickup Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 65);
            this.label1.TabIndex = 18;
            this.label1.Text = "Rent a Car";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 713);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 23;
            this.button1.Text = "CheckOut";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // NewRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 759);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CheckAvailability);
            this.Controls.Add(this.Customer);
            this.Controls.Add(this.label1);
            this.Name = "NewRental";
            this.Text = "Search Available Rentals";
            this.Load += new System.EventHandler(this.NewRental_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Customer.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem switchViewToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private Button button2;
        private Button CheckAvailability;
        private TabControl Customer;
        private TabPage tabPage3;
        private Label label1;
        private Label label19;
        private DateTimePicker customerDropoffDate;
        private DateTimePicker customerPickupDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label VehicleClass;
        private ComboBox VehicleTypes;
        private ComboBox PickupLocation;
        private ComboBox DropoffLocation;
        private CheckedListBox searchResult;
        private Button button1;
    }
}
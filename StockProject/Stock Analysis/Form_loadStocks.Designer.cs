namespace Stock_Analysis
{
    partial class Form_stockLoader
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
            this.button_loadStock = new System.Windows.Forms.Button();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog_stockLoader = new System.Windows.Forms.OpenFileDialog();
            this.label_formTitle = new System.Windows.Forms.Label();
            this.label_downloadStockData = new System.Windows.Forms.Label();
            this.groupBox_period = new System.Windows.Forms.GroupBox();
            this.radioButton_month = new System.Windows.Forms.RadioButton();
            this.radioButton_week = new System.Windows.Forms.RadioButton();
            this.radioButton_day = new System.Windows.Forms.RadioButton();
            this.label_downloadStatus = new System.Windows.Forms.Label();
            this.button_download = new System.Windows.Forms.Button();
            this.textBox_enterTicker = new System.Windows.Forms.TextBox();
            this.radioButton_1min = new System.Windows.Forms.RadioButton();
            this.radioButton_5min = new System.Windows.Forms.RadioButton();
            this.radioButton_1hr = new System.Windows.Forms.RadioButton();
            this.groupBox_period.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_loadStock
            // 
            this.button_loadStock.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_loadStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_loadStock.Location = new System.Drawing.Point(309, 94);
            this.button_loadStock.Name = "button_loadStock";
            this.button_loadStock.Size = new System.Drawing.Size(84, 68);
            this.button_loadStock.TabIndex = 0;
            this.button_loadStock.Text = "Load Stock";
            this.button_loadStock.UseVisualStyleBackColor = false;
            this.button_loadStock.Click += new System.EventHandler(this.button_loadStock_Click);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startDate.Location = new System.Drawing.Point(124, 69);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(111, 18);
            this.label_startDate.TabIndex = 1;
            this.label_startDate.Text = "Starting Date:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_endDate.Location = new System.Drawing.Point(125, 120);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(104, 18);
            this.label_endDate.TabIndex = 2;
            this.label_endDate.Text = "Ending Date:";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(73, 94);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_start.TabIndex = 3;
            this.dateTimePicker_start.Value = new System.DateTime(2022, 12, 26, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(73, 143);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_end.TabIndex = 4;
            // 
            // openFileDialog_stockLoader
            // 
            this.openFileDialog_stockLoader.Filter = "All Stock Files|*.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly Sto" +
    "cks|*-Month.csv";
            this.openFileDialog_stockLoader.InitialDirectory = "C:\\Users\\patel\\Desktop\\Stock Project\\Stock Data";
            this.openFileDialog_stockLoader.Multiselect = true;
            this.openFileDialog_stockLoader.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockLoader_FileOk);
            // 
            // label_formTitle
            // 
            this.label_formTitle.AutoSize = true;
            this.label_formTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_formTitle.Location = new System.Drawing.Point(114, 24);
            this.label_formTitle.Name = "label_formTitle";
            this.label_formTitle.Size = new System.Drawing.Size(235, 29);
            this.label_formTitle.TabIndex = 5;
            this.label_formTitle.Text = "Analyze Stock Data";
            // 
            // label_downloadStockData
            // 
            this.label_downloadStockData.AutoSize = true;
            this.label_downloadStockData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_downloadStockData.Location = new System.Drawing.Point(155, 179);
            this.label_downloadStockData.Name = "label_downloadStockData";
            this.label_downloadStockData.Size = new System.Drawing.Size(144, 15);
            this.label_downloadStockData.TabIndex = 6;
            this.label_downloadStockData.Text = "Download Stock Data";
            // 
            // groupBox_period
            // 
            this.groupBox_period.Controls.Add(this.radioButton_1hr);
            this.groupBox_period.Controls.Add(this.radioButton_5min);
            this.groupBox_period.Controls.Add(this.radioButton_1min);
            this.groupBox_period.Controls.Add(this.radioButton_month);
            this.groupBox_period.Controls.Add(this.radioButton_week);
            this.groupBox_period.Controls.Add(this.radioButton_day);
            this.groupBox_period.Location = new System.Drawing.Point(29, 179);
            this.groupBox_period.Name = "groupBox_period";
            this.groupBox_period.Size = new System.Drawing.Size(106, 70);
            this.groupBox_period.TabIndex = 7;
            this.groupBox_period.TabStop = false;
            this.groupBox_period.Text = "Period";
            // 
            // radioButton_month
            // 
            this.radioButton_month.AutoSize = true;
            this.radioButton_month.Location = new System.Drawing.Point(3, 47);
            this.radioButton_month.Name = "radioButton_month";
            this.radioButton_month.Size = new System.Drawing.Size(55, 17);
            this.radioButton_month.TabIndex = 2;
            this.radioButton_month.Text = "Month";
            this.radioButton_month.UseVisualStyleBackColor = true;
            // 
            // radioButton_week
            // 
            this.radioButton_week.AutoSize = true;
            this.radioButton_week.Location = new System.Drawing.Point(3, 29);
            this.radioButton_week.Name = "radioButton_week";
            this.radioButton_week.Size = new System.Drawing.Size(54, 17);
            this.radioButton_week.TabIndex = 1;
            this.radioButton_week.Text = "Week";
            this.radioButton_week.UseVisualStyleBackColor = true;
            // 
            // radioButton_day
            // 
            this.radioButton_day.AutoSize = true;
            this.radioButton_day.Checked = true;
            this.radioButton_day.Location = new System.Drawing.Point(3, 11);
            this.radioButton_day.Name = "radioButton_day";
            this.radioButton_day.Size = new System.Drawing.Size(44, 17);
            this.radioButton_day.TabIndex = 0;
            this.radioButton_day.Text = "Day";
            this.radioButton_day.UseVisualStyleBackColor = true;
            // 
            // label_downloadStatus
            // 
            this.label_downloadStatus.AutoSize = true;
            this.label_downloadStatus.Location = new System.Drawing.Point(156, 239);
            this.label_downloadStatus.Name = "label_downloadStatus";
            this.label_downloadStatus.Size = new System.Drawing.Size(94, 13);
            this.label_downloadStatus.TabIndex = 8;
            this.label_downloadStatus.Text = "Download Status: ";
            // 
            // button_download
            // 
            this.button_download.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_download.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_download.Location = new System.Drawing.Point(279, 206);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(90, 25);
            this.button_download.TabIndex = 9;
            this.button_download.Text = "Download";
            this.button_download.UseVisualStyleBackColor = false;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // textBox_enterTicker
            // 
            this.textBox_enterTicker.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox_enterTicker.Location = new System.Drawing.Point(158, 208);
            this.textBox_enterTicker.MaxLength = 4;
            this.textBox_enterTicker.Name = "textBox_enterTicker";
            this.textBox_enterTicker.Size = new System.Drawing.Size(100, 20);
            this.textBox_enterTicker.TabIndex = 10;
            this.textBox_enterTicker.Text = "Enter Ticker Here";
            this.textBox_enterTicker.Enter += new System.EventHandler(this.textBox_enterTicker_Enter);
            this.textBox_enterTicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_enterTicker_KeyPress);
            this.textBox_enterTicker.Leave += new System.EventHandler(this.textBox_enterTicker_Leave);
            // 
            // radioButton_1min
            // 
            this.radioButton_1min.AutoSize = true;
            this.radioButton_1min.Location = new System.Drawing.Point(53, 11);
            this.radioButton_1min.Name = "radioButton_1min";
            this.radioButton_1min.Size = new System.Drawing.Size(51, 17);
            this.radioButton_1min.TabIndex = 3;
            this.radioButton_1min.Text = "1 Min";
            this.radioButton_1min.UseVisualStyleBackColor = true;
            // 
            // radioButton_5min
            // 
            this.radioButton_5min.AutoSize = true;
            this.radioButton_5min.Location = new System.Drawing.Point(53, 29);
            this.radioButton_5min.Name = "radioButton_5min";
            this.radioButton_5min.Size = new System.Drawing.Size(51, 17);
            this.radioButton_5min.TabIndex = 4;
            this.radioButton_5min.Text = "5 Min";
            this.radioButton_5min.UseVisualStyleBackColor = true;
            // 
            // radioButton_1hr
            // 
            this.radioButton_1hr.AutoSize = true;
            this.radioButton_1hr.Location = new System.Drawing.Point(53, 47);
            this.radioButton_1hr.Name = "radioButton_1hr";
            this.radioButton_1hr.Size = new System.Drawing.Size(45, 17);
            this.radioButton_1hr.TabIndex = 5;
            this.radioButton_1hr.Text = "1 Hr";
            this.radioButton_1hr.UseVisualStyleBackColor = true;
            // 
            // Form_stockLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 261);
            this.Controls.Add(this.textBox_enterTicker);
            this.Controls.Add(this.button_download);
            this.Controls.Add(this.label_downloadStatus);
            this.Controls.Add(this.label_downloadStockData);
            this.Controls.Add(this.label_formTitle);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.button_loadStock);
            this.Controls.Add(this.groupBox_period);
            this.MaximumSize = new System.Drawing.Size(473, 300);
            this.MinimumSize = new System.Drawing.Size(473, 300);
            this.Name = "Form_stockLoader";
            this.Text = "Read and Display Stock Data";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_stockLoader_MouseClick);
            this.groupBox_period.ResumeLayout(false);
            this.groupBox_period.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loadStock;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockLoader;
        private System.Windows.Forms.Label label_formTitle;
        private System.Windows.Forms.Label label_downloadStockData;
        private System.Windows.Forms.GroupBox groupBox_period;
        private System.Windows.Forms.RadioButton radioButton_day;
        private System.Windows.Forms.RadioButton radioButton_month;
        private System.Windows.Forms.RadioButton radioButton_week;
        private System.Windows.Forms.Label label_downloadStatus;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.TextBox textBox_enterTicker;
        private System.Windows.Forms.RadioButton radioButton_1hr;
        private System.Windows.Forms.RadioButton radioButton_5min;
        private System.Windows.Forms.RadioButton radioButton_1min;
    }
}


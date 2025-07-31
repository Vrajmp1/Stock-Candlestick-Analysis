namespace Stock_Analysis
{
    partial class Form_displayStock
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.smartCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_startingDate = new System.Windows.Forms.Label();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.label_endingDate = new System.Windows.Forms.Label();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.button_update = new System.Windows.Forms.Button();
            this.label_periodLow = new System.Windows.Forms.Label();
            this.label_lowest_value = new System.Windows.Forms.Label();
            this.label_peiodHigh = new System.Windows.Forms.Label();
            this.label_highest_value = new System.Windows.Forms.Label();
            this.label_patterns = new System.Windows.Forms.Label();
            this.comboBox_patternSelect = new System.Windows.Forms.ComboBox();
            this.label_currentPattern = new System.Windows.Forms.Label();
            this.button_clearPatterns = new System.Windows.Forms.Button();
            this.button_expandOHLC = new System.Windows.Forms.Button();
            this.button_shrinkOHLC = new System.Windows.Forms.Button();
            this.label_chartPatterns = new System.Windows.Forms.Label();
            this.comboBox_chartPatternSelect = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_1yr = new System.Windows.Forms.RadioButton();
            this.radioButton_9mo = new System.Windows.Forms.RadioButton();
            this.radioButton_6mo = new System.Windows.Forms.RadioButton();
            this.radioButton_3mo = new System.Windows.Forms.RadioButton();
            this.radioButton_2mo = new System.Windows.Forms.RadioButton();
            this.radioButton_1mo = new System.Windows.Forms.RadioButton();
            this.button_rangeBackward = new System.Windows.Forms.Button();
            this.button_rangeForward = new System.Windows.Forms.Button();
            this.numericUpDown_degreeOfExtrema = new System.Windows.Forms.NumericUpDown();
            this.label_degreeOfExtrema = new System.Windows.Forms.Label();
            this.label_mouseDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_degreeOfExtrema)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStock
            // 
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price";
            chartArea1.Name = "area_OHLC";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 45.5F;
            chartArea1.Position.Width = 76.55046F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 5F;
            chartArea2.AlignWithChartArea = "area_OHLC";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.Name = "area_Volume";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 45.5F;
            chartArea2.Position.Width = 76.55046F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 53.5F;
            this.chartStock.ChartAreas.Add(chartArea1);
            this.chartStock.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chartStock.Legends.Add(legend1);
            this.chartStock.Location = new System.Drawing.Point(0, 1);
            this.chartStock.MinimumSize = new System.Drawing.Size(873, 357);
            this.chartStock.Name = "chartStock";
            series1.BorderWidth = 2;
            series1.ChartArea = "area_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Black;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=ForestGreen, LabelValueType=Low, PointWidth=0.75" +
    "";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "low, high, open, close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "area_Volume";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series3.ChartArea = "area_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "MovingAvg";
            series3.XValueMember = "date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "movingAvg";
            this.chartStock.Series.Add(series1);
            this.chartStock.Series.Add(series2);
            this.chartStock.Series.Add(series3);
            this.chartStock.Size = new System.Drawing.Size(873, 357);
            this.chartStock.TabIndex = 0;
            this.chartStock.Text = "chart1";
            this.chartStock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartStock_MouseMove);
            // 
            // label_startingDate
            // 
            this.label_startingDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_startingDate.AutoSize = true;
            this.label_startingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startingDate.Location = new System.Drawing.Point(308, 362);
            this.label_startingDate.Name = "label_startingDate";
            this.label_startingDate.Size = new System.Drawing.Size(111, 18);
            this.label_startingDate.TabIndex = 1;
            this.label_startingDate.Text = "Starting Date:";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(263, 383);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startDate.TabIndex = 2;
            // 
            // label_endingDate
            // 
            this.label_endingDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_endingDate.AutoSize = true;
            this.label_endingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_endingDate.Location = new System.Drawing.Point(310, 406);
            this.label_endingDate.Name = "label_endingDate";
            this.label_endingDate.Size = new System.Drawing.Size(104, 18);
            this.label_endingDate.TabIndex = 3;
            this.label_endingDate.Text = "Ending Date:";
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(263, 427);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 4;
            // 
            // button_update
            // 
            this.button_update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_update.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_update.Location = new System.Drawing.Point(481, 391);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(84, 37);
            this.button_update.TabIndex = 5;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_periodLow
            // 
            this.label_periodLow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_periodLow.AutoSize = true;
            this.label_periodLow.Location = new System.Drawing.Point(22, 383);
            this.label_periodLow.Name = "label_periodLow";
            this.label_periodLow.Size = new System.Drawing.Size(63, 13);
            this.label_periodLow.TabIndex = 6;
            this.label_periodLow.Text = "Period Low:";
            // 
            // label_lowest_value
            // 
            this.label_lowest_value.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_lowest_value.AutoSize = true;
            this.label_lowest_value.Location = new System.Drawing.Point(97, 383);
            this.label_lowest_value.Name = "label_lowest_value";
            this.label_lowest_value.Size = new System.Drawing.Size(19, 13);
            this.label_lowest_value.TabIndex = 7;
            this.label_lowest_value.Text = "----";
            // 
            // label_peiodHigh
            // 
            this.label_peiodHigh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_peiodHigh.AutoSize = true;
            this.label_peiodHigh.Location = new System.Drawing.Point(22, 406);
            this.label_peiodHigh.Name = "label_peiodHigh";
            this.label_peiodHigh.Size = new System.Drawing.Size(65, 13);
            this.label_peiodHigh.TabIndex = 8;
            this.label_peiodHigh.Text = "Period High:";
            // 
            // label_highest_value
            // 
            this.label_highest_value.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_highest_value.AutoSize = true;
            this.label_highest_value.Location = new System.Drawing.Point(97, 407);
            this.label_highest_value.Name = "label_highest_value";
            this.label_highest_value.Size = new System.Drawing.Size(19, 13);
            this.label_highest_value.TabIndex = 9;
            this.label_highest_value.Text = "----";
            // 
            // label_patterns
            // 
            this.label_patterns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_patterns.AutoSize = true;
            this.label_patterns.BackColor = System.Drawing.SystemColors.Window;
            this.label_patterns.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_patterns.Location = new System.Drawing.Point(708, 111);
            this.label_patterns.Name = "label_patterns";
            this.label_patterns.Size = new System.Drawing.Size(153, 16);
            this.label_patterns.TabIndex = 10;
            this.label_patterns.Text = "Select Candlestick Pattern";
            // 
            // comboBox_patternSelect
            // 
            this.comboBox_patternSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox_patternSelect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_patternSelect.FormattingEnabled = true;
            this.comboBox_patternSelect.Location = new System.Drawing.Point(711, 130);
            this.comboBox_patternSelect.Name = "comboBox_patternSelect";
            this.comboBox_patternSelect.Size = new System.Drawing.Size(162, 21);
            this.comboBox_patternSelect.TabIndex = 11;
            this.comboBox_patternSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_patternSelect_SelectedIndexChanged);
            // 
            // label_currentPattern
            // 
            this.label_currentPattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_currentPattern.AutoSize = true;
            this.label_currentPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentPattern.Location = new System.Drawing.Point(606, 381);
            this.label_currentPattern.Name = "label_currentPattern";
            this.label_currentPattern.Size = new System.Drawing.Size(0, 16);
            this.label_currentPattern.TabIndex = 12;
            // 
            // button_clearPatterns
            // 
            this.button_clearPatterns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_clearPatterns.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_clearPatterns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clearPatterns.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_clearPatterns.Location = new System.Drawing.Point(753, 214);
            this.button_clearPatterns.Name = "button_clearPatterns";
            this.button_clearPatterns.Size = new System.Drawing.Size(75, 43);
            this.button_clearPatterns.TabIndex = 13;
            this.button_clearPatterns.Text = "Clear Patterns";
            this.button_clearPatterns.UseVisualStyleBackColor = false;
            this.button_clearPatterns.Click += new System.EventHandler(this.button_clearPatterns_Click);
            // 
            // button_expandOHLC
            // 
            this.button_expandOHLC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_expandOHLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_expandOHLC.Location = new System.Drawing.Point(25, 150);
            this.button_expandOHLC.Name = "button_expandOHLC";
            this.button_expandOHLC.Size = new System.Drawing.Size(19, 23);
            this.button_expandOHLC.TabIndex = 14;
            this.button_expandOHLC.Text = "+";
            this.button_expandOHLC.UseVisualStyleBackColor = false;
            this.button_expandOHLC.Click += new System.EventHandler(this.button_expandOHLC_Click);
            // 
            // button_shrinkOHLC
            // 
            this.button_shrinkOHLC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_shrinkOHLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_shrinkOHLC.Location = new System.Drawing.Point(25, 179);
            this.button_shrinkOHLC.Name = "button_shrinkOHLC";
            this.button_shrinkOHLC.Size = new System.Drawing.Size(19, 23);
            this.button_shrinkOHLC.TabIndex = 15;
            this.button_shrinkOHLC.Text = "-";
            this.button_shrinkOHLC.UseVisualStyleBackColor = false;
            this.button_shrinkOHLC.Click += new System.EventHandler(this.button_shrinkOHLC_Click);
            // 
            // label_chartPatterns
            // 
            this.label_chartPatterns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_chartPatterns.AutoSize = true;
            this.label_chartPatterns.BackColor = System.Drawing.SystemColors.Window;
            this.label_chartPatterns.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chartPatterns.Location = new System.Drawing.Point(708, 163);
            this.label_chartPatterns.Name = "label_chartPatterns";
            this.label_chartPatterns.Size = new System.Drawing.Size(120, 16);
            this.label_chartPatterns.TabIndex = 16;
            this.label_chartPatterns.Text = "Select Chart Pattern";
            // 
            // comboBox_chartPatternSelect
            // 
            this.comboBox_chartPatternSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox_chartPatternSelect.FormattingEnabled = true;
            this.comboBox_chartPatternSelect.Items.AddRange(new object[] {
            "Bottoms",
            "Tops",
            "Bullish ABCD",
            "Bearish ABCD",
            "Head and Shoulders",
            "Inverted Head and Shoulders"});
            this.comboBox_chartPatternSelect.Location = new System.Drawing.Point(711, 182);
            this.comboBox_chartPatternSelect.Name = "comboBox_chartPatternSelect";
            this.comboBox_chartPatternSelect.Size = new System.Drawing.Size(162, 21);
            this.comboBox_chartPatternSelect.TabIndex = 17;
            this.comboBox_chartPatternSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_chartPatternSelect_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.radioButton_1yr);
            this.groupBox1.Controls.Add(this.radioButton_9mo);
            this.groupBox1.Controls.Add(this.radioButton_6mo);
            this.groupBox1.Controls.Add(this.radioButton_3mo);
            this.groupBox1.Controls.Add(this.radioButton_2mo);
            this.groupBox1.Controls.Add(this.radioButton_1mo);
            this.groupBox1.Location = new System.Drawing.Point(711, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 65);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
            // 
            // radioButton_1yr
            // 
            this.radioButton_1yr.AutoSize = true;
            this.radioButton_1yr.Checked = true;
            this.radioButton_1yr.Location = new System.Drawing.Point(101, 39);
            this.radioButton_1yr.Name = "radioButton_1yr";
            this.radioButton_1yr.Size = new System.Drawing.Size(42, 17);
            this.radioButton_1yr.TabIndex = 6;
            this.radioButton_1yr.TabStop = true;
            this.radioButton_1yr.Text = "1 yr";
            this.radioButton_1yr.UseVisualStyleBackColor = true;
            this.radioButton_1yr.CheckedChanged += new System.EventHandler(this.radioButton_1yr_CheckedChanged);
            // 
            // radioButton_9mo
            // 
            this.radioButton_9mo.AutoSize = true;
            this.radioButton_9mo.Location = new System.Drawing.Point(53, 39);
            this.radioButton_9mo.Name = "radioButton_9mo";
            this.radioButton_9mo.Size = new System.Drawing.Size(48, 17);
            this.radioButton_9mo.TabIndex = 5;
            this.radioButton_9mo.Text = "9 mo";
            this.radioButton_9mo.UseVisualStyleBackColor = true;
            this.radioButton_9mo.CheckedChanged += new System.EventHandler(this.radioButton_9mo_CheckedChanged);
            // 
            // radioButton_6mo
            // 
            this.radioButton_6mo.AutoSize = true;
            this.radioButton_6mo.Location = new System.Drawing.Point(7, 39);
            this.radioButton_6mo.Name = "radioButton_6mo";
            this.radioButton_6mo.Size = new System.Drawing.Size(48, 17);
            this.radioButton_6mo.TabIndex = 4;
            this.radioButton_6mo.Text = "6 mo";
            this.radioButton_6mo.UseVisualStyleBackColor = true;
            this.radioButton_6mo.CheckedChanged += new System.EventHandler(this.radioButton_6mo_CheckedChanged);
            // 
            // radioButton_3mo
            // 
            this.radioButton_3mo.AutoSize = true;
            this.radioButton_3mo.Location = new System.Drawing.Point(101, 16);
            this.radioButton_3mo.Name = "radioButton_3mo";
            this.radioButton_3mo.Size = new System.Drawing.Size(48, 17);
            this.radioButton_3mo.TabIndex = 3;
            this.radioButton_3mo.Text = "3 mo";
            this.radioButton_3mo.UseVisualStyleBackColor = true;
            this.radioButton_3mo.CheckedChanged += new System.EventHandler(this.radioButton_3mo_CheckedChanged);
            // 
            // radioButton_2mo
            // 
            this.radioButton_2mo.AutoSize = true;
            this.radioButton_2mo.Location = new System.Drawing.Point(53, 16);
            this.radioButton_2mo.Name = "radioButton_2mo";
            this.radioButton_2mo.Size = new System.Drawing.Size(48, 17);
            this.radioButton_2mo.TabIndex = 2;
            this.radioButton_2mo.Text = "2 mo";
            this.radioButton_2mo.UseVisualStyleBackColor = true;
            this.radioButton_2mo.CheckedChanged += new System.EventHandler(this.radioButton_2mo_CheckedChanged);
            // 
            // radioButton_1mo
            // 
            this.radioButton_1mo.AutoSize = true;
            this.radioButton_1mo.Location = new System.Drawing.Point(7, 16);
            this.radioButton_1mo.Name = "radioButton_1mo";
            this.radioButton_1mo.Size = new System.Drawing.Size(48, 17);
            this.radioButton_1mo.TabIndex = 1;
            this.radioButton_1mo.Text = "1 mo";
            this.radioButton_1mo.UseVisualStyleBackColor = true;
            this.radioButton_1mo.CheckedChanged += new System.EventHandler(this.radioButton_1mo_CheckedChanged);
            // 
            // button_rangeBackward
            // 
            this.button_rangeBackward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_rangeBackward.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_rangeBackward.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_rangeBackward.Location = new System.Drawing.Point(729, 330);
            this.button_rangeBackward.Name = "button_rangeBackward";
            this.button_rangeBackward.Size = new System.Drawing.Size(28, 23);
            this.button_rangeBackward.TabIndex = 19;
            this.button_rangeBackward.Text = "<";
            this.button_rangeBackward.UseVisualStyleBackColor = false;
            this.button_rangeBackward.Click += new System.EventHandler(this.button_rangeBackward_Click);
            // 
            // button_rangeForward
            // 
            this.button_rangeForward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_rangeForward.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_rangeForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_rangeForward.Location = new System.Drawing.Point(821, 330);
            this.button_rangeForward.Name = "button_rangeForward";
            this.button_rangeForward.Size = new System.Drawing.Size(28, 23);
            this.button_rangeForward.TabIndex = 20;
            this.button_rangeForward.Text = ">";
            this.button_rangeForward.UseVisualStyleBackColor = false;
            this.button_rangeForward.Click += new System.EventHandler(this.button_rangeForward_Click);
            // 
            // numericUpDown_degreeOfExtrema
            // 
            this.numericUpDown_degreeOfExtrema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_degreeOfExtrema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_degreeOfExtrema.Location = new System.Drawing.Point(743, 418);
            this.numericUpDown_degreeOfExtrema.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_degreeOfExtrema.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_degreeOfExtrema.Name = "numericUpDown_degreeOfExtrema";
            this.numericUpDown_degreeOfExtrema.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown_degreeOfExtrema.TabIndex = 21;
            this.numericUpDown_degreeOfExtrema.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_degreeOfExtrema.ValueChanged += new System.EventHandler(this.numericUpDown_scan_ValueChanged);
            // 
            // label_degreeOfExtrema
            // 
            this.label_degreeOfExtrema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_degreeOfExtrema.AutoSize = true;
            this.label_degreeOfExtrema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_degreeOfExtrema.Location = new System.Drawing.Point(740, 388);
            this.label_degreeOfExtrema.Name = "label_degreeOfExtrema";
            this.label_degreeOfExtrema.Size = new System.Drawing.Size(116, 26);
            this.label_degreeOfExtrema.TabIndex = 22;
            this.label_degreeOfExtrema.Text = "Chart Patterns-\r\nDegree of Extrema:";
            // 
            // label_mouseDate
            // 
            this.label_mouseDate.AutoSize = true;
            this.label_mouseDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_mouseDate.Location = new System.Drawing.Point(606, 166);
            this.label_mouseDate.Name = "label_mouseDate";
            this.label_mouseDate.Size = new System.Drawing.Size(0, 13);
            this.label_mouseDate.TabIndex = 23;
            // 
            // Form_displayStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 450);
            this.Controls.Add(this.label_mouseDate);
            this.Controls.Add(this.label_degreeOfExtrema);
            this.Controls.Add(this.numericUpDown_degreeOfExtrema);
            this.Controls.Add(this.button_rangeForward);
            this.Controls.Add(this.button_rangeBackward);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_chartPatternSelect);
            this.Controls.Add(this.label_chartPatterns);
            this.Controls.Add(this.button_shrinkOHLC);
            this.Controls.Add(this.button_expandOHLC);
            this.Controls.Add(this.button_clearPatterns);
            this.Controls.Add(this.label_currentPattern);
            this.Controls.Add(this.comboBox_patternSelect);
            this.Controls.Add(this.label_patterns);
            this.Controls.Add(this.label_highest_value);
            this.Controls.Add(this.label_peiodHigh);
            this.Controls.Add(this.label_lowest_value);
            this.Controls.Add(this.label_periodLow);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.label_endingDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.label_startingDate);
            this.Controls.Add(this.chartStock);
            this.MinimumSize = new System.Drawing.Size(891, 489);
            this.Name = "Form_displayStock";
            this.Text = "Form_displayStock";
            this.SizeChanged += new System.EventHandler(this.Form_displayStock_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_degreeOfExtrema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.Label label_startingDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.Label label_endingDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_periodLow;
        private System.Windows.Forms.Label label_lowest_value;
        private System.Windows.Forms.Label label_peiodHigh;
        private System.Windows.Forms.Label label_highest_value;
        private System.Windows.Forms.Label label_patterns;
        private System.Windows.Forms.ComboBox comboBox_patternSelect;
        private System.Windows.Forms.Label label_currentPattern;
        private System.Windows.Forms.Button button_clearPatterns;
        private System.Windows.Forms.BindingSource smartCandlestickBindingSource;
        private System.Windows.Forms.Button button_expandOHLC;
        private System.Windows.Forms.Button button_shrinkOHLC;
        private System.Windows.Forms.Label label_chartPatterns;
        private System.Windows.Forms.ComboBox comboBox_chartPatternSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_1yr;
        private System.Windows.Forms.RadioButton radioButton_9mo;
        private System.Windows.Forms.RadioButton radioButton_6mo;
        private System.Windows.Forms.RadioButton radioButton_3mo;
        private System.Windows.Forms.RadioButton radioButton_2mo;
        private System.Windows.Forms.RadioButton radioButton_1mo;
        private System.Windows.Forms.Button button_rangeBackward;
        private System.Windows.Forms.Button button_rangeForward;
        private System.Windows.Forms.NumericUpDown numericUpDown_degreeOfExtrema;
        private System.Windows.Forms.Label label_degreeOfExtrema;
        private System.Windows.Forms.Label label_mouseDate;
    }
}
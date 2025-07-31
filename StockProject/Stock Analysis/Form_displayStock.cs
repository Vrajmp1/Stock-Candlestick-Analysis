using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Stock_Analysis
{
    /* Class Form_displayStock represents an instance of the Windows Form class
       with all specified components and methods to display and analyze a candlestick chart. */
    public partial class Form_displayStock : Form
    {
        // This is the name of the ticker displayed by this form
        public string fileName { get; private set; }

        // This is the list of all the candlestick data passed to this form
        public List<smartCandlestick> allCandlesticks { get; private set; }

        // This is the binding list that is the source of the chart's data
        public BindingList<smartCandlestick> candlesticks { get; private set; }

        // Basic constructor with no arguments, not used in the project.
        public Form_displayStock() { }

        // List of recognizer objects to recognize various patterns
        public List<recognizer> lr { get; private set; }

        // Constructor that takes in candlestick data, initial start/end dates, and stock file name
        public Form_displayStock(List<smartCandlestick> allData, string sourceFileName, DateTime startDate, DateTime endDate)
        {
            // Always initialize form controls first
            InitializeComponent();

            // Set up the recognizer list
            initializeRecognizers();

            // Set title of the form
            Text = fileName = sourceFileName;

            // Set the title of the stock chart
            chartStock.Titles.Add(Path.GetFileNameWithoutExtension(sourceFileName));

            // Set the dates in the date time pickers
            dateTimePicker_startDate.Value = startDate;
            dateTimePicker_endDate.Value = endDate;

            // Make a copy of the candlesticks argument
            allCandlesticks = allData;

            // Compute 10-day moving avereage for each candlestick
            computeMovingAvg(10);

            // Initialize the candlesticks
            candlesticks = new BindingList<smartCandlestick>();

            // Add candlesticks in date range to the binding list to display
            getCandlesticksInDateRange();
        }

        /* Function initializeRecognizers sets up the recognizer list and the combo box */
        private void initializeRecognizers()
        {
            // instantiate a new list of recognizers
            lr = new List<recognizer>();

            // add each type of recognizer to that list
            lr.Add(new bullishRecognizer());
            lr.Add(new bearishRecognizer());
            lr.Add(new neutralRecognizer());
            lr.Add(new marubozuRecognizer());
            lr.Add(new dojiRecognizer());
            lr.Add(new dragonFlyDojiRecognizer());
            lr.Add(new graveStoneDojiRecognizer());
            lr.Add(new hammerRecognizer());
            lr.Add(new invertedHammerRecognizer());
            lr.Add(new engulfingRecognizer());
            lr.Add(new bullishEngulfingRecognizer());
            lr.Add(new bearishEngulfingRecognizer());
            lr.Add(new haramiRecognizer());
            lr.Add(new bullishHaramiRecognizer());
            lr.Add(new bearishHaramiRecognizer());
            lr.Add(new peakRecognizer());
            lr.Add(new valleyRecognizer());
            // set up combo box entries
            foreach (recognizer r in lr)
                comboBox_patternSelect.Items.Add(r.patternName);
        }
        /* Function computeMovingAvg() takes in the list of all candlesticks and
           computes the average of the previous 10 candlesticks each candlestick */
        private void computeMovingAvg(int numDays)
        {
            Decimal sum = allCandlesticks[0].close;
            allCandlesticks[0].movingAvg = allCandlesticks[0].close;
            for (int i = 1; i < allCandlesticks.Count; i++)
            {
                if (i < numDays)
                {
                    allCandlesticks[i].movingAvg = sum / (i);
                    sum += allCandlesticks[i].close;
                }
                else
                {
                    allCandlesticks[i].movingAvg = sum / numDays;
                    sum = sum - allCandlesticks[i - numDays].close + allCandlesticks[i].close;
                }
            }
        }

        /* function colorVolumeBars() shows bullish and bearish volume bars */
        private void colorVolumeBars() {
            for (int i=0; i< candlesticks.Count; i++)
            {
                // Set color based on your condition
                if (candlesticks[i].isBullish)
                    chartStock.Series["Series_Volume"].Points[i].Color = Color.Green;
                else if (candlesticks[i].isBearish)
                    chartStock.Series["Series_Volume"].Points[i].Color = Color.Red;
                else
                    chartStock.Series["Series_Volume"].Points[i].Color = Color.Gray;
            }
        }

        /* Function lowest() takes in the candlestick datasource and
           computes the lowest price of the stock in the given period */
        private decimal lowest(BindingList<smartCandlestick> candlesticks)
        {
            Decimal lowest = 0;
            if (candlesticks.Count == 0)
                return lowest;

            lowest = candlesticks[0].low;
            foreach (aCandlestick candlestick in candlesticks)
            {
                if (candlestick.low < lowest)
                    lowest = candlestick.low;
            }
            return Math.Round(lowest, 2);
        }

        /* Function highest() takes in the candlestick datasource and
           computes the highest price of the stock in the given period */
        private decimal highest(BindingList<smartCandlestick> candlesticks)
        {
            Decimal highest = 0;
            if (candlesticks.Count == 0)
                return highest;

            highest = candlesticks[0].high;
            foreach (aCandlestick candlestick in candlesticks)
            {
                if (candlestick.low > highest)
                    highest = candlestick.high;
            }
            return Math.Round(highest, 2);
        }

        /* function getCandlesticksInDateRange() puts only those candlesticks that are
           within the specified range into the candlesticks chart binding data source */
        private void getCandlesticksInDateRange()
        {
            // Here we should make sure the candlesticks are in chronological order
            // I.e earliest to newest
            candlesticks.Clear();
            foreach (smartCandlestick cs in allCandlesticks)
            {
                // Break loop when date after ending date is encountered
                if (cs.date > dateTimePicker_endDate.Value)
                    break;
                // Filter out the candlesticks that are out of range
                if (cs.date >= dateTimePicker_startDate.Value)
                {
                    candlesticks.Add(cs);
                }
            }
            //the following lines serve to produce a better Yaxis range (longer candlesticks)
            int period_low = (int)lowest(candlesticks);
            int period_high = (int)highest(candlesticks);
            label_lowest_value.Text = $"$ {period_low}";
            label_highest_value.Text = $"$ {period_high}";
            this.chartStock.ChartAreas[0].AxisY.Minimum = Math.Floor((period_low - period_low * .05) / 10) * 10;

            // Connect the chart to the list of candlesticks and bind
            chartStock.DataSource = candlesticks;
            chartStock.DataBind();

            // Establish tops and bottoms
            identifyExtrema();

            // color volume bars green if bullish, red if bearish, gray if neutral
            colorVolumeBars();

            // If the patternSelect combo box is not empty, update annotations as well
            if (comboBox_patternSelect.SelectedIndex != -1)
            {
                annotateChart(comboBox_patternSelect.SelectedIndex);
            }
            // If the chartPatternSelect combo box is not empty, update annotations as well
            if (comboBox_chartPatternSelect.SelectedIndex != -1)
            {
                annotateChartPatterns();
            }
        }

        /* This event handler updates the candlestick data source with new start & end dates
           as well as reassigns annotations based on the new date range */
        private void button_update_Click(object sender, EventArgs e)
        {
            getCandlesticksInDateRange();
        }

        /* The function below adds an arrow annotation 
           to a candlestick at the provided index */
        private void addArrowAnnotation(int dataPointIndex, string patternName="")
        {
            // Create a new arrow annotation
            ArrowAnnotation arrowAnnotation = new ArrowAnnotation();

            // Set the annotation properties
            arrowAnnotation.AxisX = chartStock.ChartAreas[0].AxisX; // X-axis for the annotation
            arrowAnnotation.AxisY = chartStock.ChartAreas[0].AxisY; // Y-axis for the annotation
            arrowAnnotation.AnchorDataPoint = chartStock.Series[0].Points[dataPointIndex]; // The anchor data point for the annotation
            arrowAnnotation.AnchorAlignment = ContentAlignment.TopCenter; // Alignment of the annotation relative to the anchor point
            arrowAnnotation.Width = 0; // Width of the arrow (negative value to point inward)
            arrowAnnotation.Height = 4; // Height of the arrow (negative value to point inward)
            arrowAnnotation.LineWidth = 1; // Width of the arrow line
            arrowAnnotation.LineColor = System.Drawing.Color.Purple; // Color of the arrow line
            arrowAnnotation.BackColor = System.Drawing.Color.Purple;
            arrowAnnotation.ArrowStyle = ArrowStyle.Simple; // Style of the arrow head
            arrowAnnotation.ArrowSize = 2; // Size of the arrowhead (adjust as needed)
            arrowAnnotation.AnchorOffsetY = 3;  // Allow some space between arrow and candlestick
            
            // Add the annotation to the chart
            chartStock.Annotations.Add(arrowAnnotation);
        }

        /* function annotateChart takes in a the index for required recognizer
           makes arrow annotations on the chart for all candlesticks that match
           the desired pattern (as specified in the combo box by the user) */
        private void annotateChart(int recognizerIndex)
        {
            chartStock.Annotations.Clear();
            string patternName = lr[recognizerIndex].patternName;
            List<int> markIndices = lr[recognizerIndex].recognize(candlesticks.ToList());
            foreach (int index in markIndices)
            {
                addArrowAnnotation(index, patternName);
            }
        }

        /* This event handler fires when user changes the selected pattern in the combo box.
           When called, this function annotates the candlestick chart for the selected pattern. */
        private void comboBox_patternSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Annotations on chart when value of combobox is changed to a valid index
            if (comboBox_patternSelect.SelectedIndex != -1)
            {
                // This function takes care of the annotations
                annotateChart(comboBox_patternSelect.SelectedIndex);
                // This label control displays which pattern is currently being displayed
                label_currentPattern.Text = $"Now displaying the {comboBox_patternSelect.SelectedItem as string} pattern";
            }
        }

        /* This event handler fires when the clear button is pressed. Upon being called, it wipes
           the annotations from the chart and resets the comboBox's value to blank.*/
        private void button_clearPatterns_Click(object sender, EventArgs e)
        {
            // wipes the chart clean of all annotations
            chartStock.Annotations.Clear();
            // label identifying the pattern being displayed is cleared as well
            label_currentPattern.Text = "";
            // reset both comboBoxes
            comboBox_patternSelect.SelectedIndex = -1;
            comboBox_chartPatternSelect.SelectedIndex = -1;
        }
        //================== Visualization Effects and Aids ===================//
        private void Form_displayStock_SizeChanged(object sender, EventArgs e)
        {
            chartStock.Width = this.Width;
            chartStock.Height = this.Height - 132;
        }

        private void button_expandOHLC_Click(object sender, EventArgs e)
        {
            try
            {
                chartStock.ChartAreas[0].Position.Height = chartStock.ChartAreas[0].Position.Height + 5;
                chartStock.ChartAreas[1].Position.Y = chartStock.ChartAreas[1].Position.Y + 5;
                chartStock.ChartAreas[1].Position.Height = chartStock.ChartAreas[1].Position.Height - 5;
            }
            catch { label_currentPattern.Text = "Max height reached!"; }
        }

        private void button_shrinkOHLC_Click(object sender, EventArgs e)
        {
            try
            {
                chartStock.ChartAreas[0].Position.Height = chartStock.ChartAreas[0].Position.Height - 5;
                chartStock.ChartAreas[1].Position.Y = chartStock.ChartAreas[1].Position.Y - 5;
                chartStock.ChartAreas[1].Position.Height = chartStock.ChartAreas[1].Position.Height + 5;
            }
            catch { label_currentPattern.Text = "Minimum height reached!"; }
        }

        // functions below help set the range
        private void radioButton_1mo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-1);
            getCandlesticksInDateRange();
        }

        private void radioButton_2mo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-2);
            getCandlesticksInDateRange();
        }

        private void radioButton_3mo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-3);
            getCandlesticksInDateRange();
        }

        private void radioButton_6mo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-6);
            getCandlesticksInDateRange();
        }

        private void radioButton_9mo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-9);
            getCandlesticksInDateRange();
        }

        private void radioButton_1yr_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = dateTimePicker_endDate.Value.AddMonths(-12);
            getCandlesticksInDateRange();
        }

        private void button_rangeBackward_Click(object sender, EventArgs e)
        {
            if (radioButton_1mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-1);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-1);
            }
            else if (radioButton_2mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-2);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-2);
            }
            else if (radioButton_3mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-3);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-3);
            }
            else if (radioButton_6mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-6);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-6);
            }
            else if (radioButton_9mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-9);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-9);
            }
            else if (radioButton_1yr.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(-12);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(-12);
            }
            else
            {
                label_currentPattern.Text = "Something went wrong. :-(";
            }
            getCandlesticksInDateRange();
        }

        private void button_rangeForward_Click(object sender, EventArgs e)
        {
            if (radioButton_1mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(1);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(1);
            }
            else if (radioButton_2mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(2);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(2);
            }
            else if (radioButton_3mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(3);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(3);
            }
            else if (radioButton_6mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(6);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(6);
            }
            else if (radioButton_9mo.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(9);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(9);
            }
            else if (radioButton_1yr.Checked)
            {
                dateTimePicker_startDate.Value = dateTimePicker_startDate.Value.AddMonths(12);
                dateTimePicker_endDate.Value = dateTimePicker_endDate.Value.AddMonths(12);
            }
            else
            {
                label_currentPattern.Text = "Something went wrong. :-(";
            }
            getCandlesticksInDateRange();
        }

        private void chartStock_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the mouse is over the chart
            if (e.X >= chartStock.ClientRectangle.Left && e.X <= chartStock.ClientRectangle.Right &&
                e.Y >= chartStock.ClientRectangle.Top && e.Y <= chartStock.ClientRectangle.Bottom)
            {
                // Convert the mouse position to chart area coordinates
                HitTestResult result = chartStock.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    // Get the x-value (date) of the data point under the mouse
                    DateTime xDate = DateTime.FromOADate(result.Series.Points[result.PointIndex].XValue);
                    // Format the date and update the label
                    string formattedDate = xDate.ToShortDateString();
                    try
                    {
                        // Get y-value low, high, open, close
                        double yValueLow = result.Series.Points[result.PointIndex].YValues[0];
                        double yValueHigh = result.Series.Points[result.PointIndex].YValues[1];
                        double yValueOpen = result.Series.Points[result.PointIndex].YValues[2];
                        double yValueClose = result.Series.Points[result.PointIndex].YValues[3];
                        label_mouseDate.Text = $"Date: {formattedDate}\nOpen: {yValueOpen}\nHigh: {yValueHigh}\nLow: {yValueLow}\nClose: {yValueClose}";
                    }
                    catch
                    {
                        label_mouseDate.Text = $"Date: {formattedDate}";
                    }

                    // Set the label position below the cursor
                    label_mouseDate.Location = new System.Drawing.Point(e.X - label_mouseDate.Width / 2, e.Y + 15);
                }
                else
                    label_mouseDate.Text = "";
            }
            else
            {
                // If the mouse is outside the chart, hide the label
                label_mouseDate.Text = "";
            }
        }
    }
}

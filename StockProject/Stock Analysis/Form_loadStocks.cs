using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO.IsolatedStorage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Stock_Analysis
{
    /* Class Form_stockLoader represents an instance of the Windows Form class
       with all specified components and methods for the stock loader GUI application.
       Specifically it allows user to select multiple stock files to display and analyze
       as well as provides the option for initial starting and ending dates. */
    public partial class Form_stockLoader : Form
    {
        // class variable is a referenceString to cross check a stock file's header
        private static String referenceHeaderString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";
        private static String referenceHeaderString1 = "Ticker,Period,Date,Open,High,Low,Close,Volume";

        // The basic constructor for the form initializes the controls to be displayed
        public Form_stockLoader()
        {
            InitializeComponent();
        }

        /* function loadStockFromFile() reads candlestick data of a
           single stock file and returns a list of smartCandlesticks */
        private List<smartCandlestick> loadStockFromFile(string filename)
        {
            List<smartCandlestick> resultingList = new List<smartCandlestick>(1024);
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                // line is the header
                // If the header is correct
                if (line == referenceHeaderString1 || line == referenceHeaderString)
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.

                    while ((line = sr.ReadLine()) != null)
                    {
                        // Instantiate a new candlestick from the line string
                        smartCandlestick cs = new smartCandlestick(line);
                        // Add the candlestick to the list of candlesticks
                        resultingList.Add(cs);
                    }
                    resultingList.Reverse();
                }
            }
            return resultingList;
        }

        /* function loadStocks takes in an array of stock file names and returns a full
           list of list of candlesticks representing a master list of all stocks' data */
        private List<List<smartCandlestick>> loadStocks(string[] filenames)
        {
            // Instantiate a List of LIsts with capacity for numberOfFileNames
            List<List<smartCandlestick>>listOfListOfCandlesticks = new List<List<smartCandlestick>>(filenames.Length);
            // Now go load each filename
            // Use a foreach loop to go through each filename in the filenames array
            foreach (String filename in filenames)
            {
                // Go read the candlesticks stored in the file named filename
                List<smartCandlestick> listOfCandlesticks = loadStockFromFile(filename);
                // Add the resulting list of candlesticks to the list of list of candlesticks
                listOfListOfCandlesticks.Add(listOfCandlesticks);
            }
            // Return the list of lists of candlesticks
            return listOfListOfCandlesticks;
        }

        /* function openDisplayChartForms() uses the list of list of candlesticks to construct
           and display the user specified displayStock forms to display candlestick data and analyze*/
        private void openDisplayChartForms(string[] filenames, List<List<smartCandlestick>> allFileData)
        {
            int count = 0;
            foreach (List<smartCandlestick> stockData in allFileData)
            {
                // Construct a new displayStock form to display chart data of the stock
                Form_displayStock displayForm = new Form_displayStock(stockData, openFileDialog_stockLoader.FileNames[count], dateTimePicker_start.Value, dateTimePicker_end.Value);
                // Display the chart
                displayForm.Show();
                count += 1;
            }
        }

        /* function downloadData() downloads data of a stock with given ticker */
        private void downloadData(string ticker, string period)
        {

            string pythonPath = "python"; // assuming python executable is in PATH
            string scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "pullStockHistoricalData.py");
            // Specify the path to the Python executable, the script, and command line arguments
            string arguments = $"{ticker} {period}"; // Add your command line arguments here

            // Create a process start info
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonPath, 
                Arguments = $"\"{scriptPath}\" {arguments}", // Include script path and arguments
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Create a new process and start it
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                // Read the standard output and standard error
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Wait for the process to exit
                process.WaitForExit();

                // Display the output and error if needed
                Console.WriteLine("Output:\n" + output);
                Console.WriteLine("Error:\n" + error);

                // Display exit code
                Console.WriteLine("Exit Code: " + process.ExitCode);
            }
        }

        /* function fileExists() checks is a given file name exists in the stock directory */
        private Boolean fileExists(string stockFile)
        {
            // Specify the directory path and filename
            string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\.."));
            string filename = stockFile;
            string directoryPath = Path.Combine(projectRoot, "Stock Data");
            // Full path to the file
            string filePath = Path.Combine(directoryPath, stockFile);
            Console.WriteLine("Checking for file at: " + filePath); // debug line

            // Check if the file exists
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* This event handler opens the file dialog to select multiple stock files 
           when user clicks the respective button on the initial form*/
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog_stockLoader.ShowDialog();
        }

        /* This event handler is fired when the user selects and opens files from the 
           file dialog box. This event handler loads all required data and instantiates
           and displays all the candlestick charts specified by the user in separate forms */
        private void openFileDialog_stockLoader_FileOk(object sender, CancelEventArgs e)
        {
            List<List<smartCandlestick>> allFileData = loadStocks(openFileDialog_stockLoader.FileNames);
            openDisplayChartForms(openFileDialog_stockLoader.FileNames, allFileData);
        }

        private void textBox_enterTicker_Leave(object sender, EventArgs e)
        {
            // Add the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(textBox_enterTicker.Text))
            {
                textBox_enterTicker.Text = "Enter Ticker Here";
                textBox_enterTicker.ForeColor = SystemColors.GrayText; // Set the text color to gray
            }
        }

        private void textBox_enterTicker_Enter(object sender, EventArgs e)
        {
            // Remove the placeholder text when the TextBox gets focus
            if (textBox_enterTicker.Text == "Enter Ticker Here")
            {
                textBox_enterTicker.Text = string.Empty;
                textBox_enterTicker.ForeColor = SystemColors.WindowText; // Set the text color to default
            }
        }

        private void textBox_enterTicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is a letter or backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Disallow non-letter characters (except Backspace)
                e.Handled = true;
            }
            // Convert the entered character to uppercase
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void Form_stockLoader_MouseClick(object sender, MouseEventArgs e)
        {
            label_downloadStatus.Focus();
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            label_downloadStatus.Text = "Download Status: Fetching Data";
            Thread.Sleep(1000);
            string interval;
            string ticker = textBox_enterTicker.Text;
            Dictionary<string,string> intervalMap = new Dictionary<string,string>();
            intervalMap["1d"] = "Day";
            intervalMap["1wk"] = "Week";
            intervalMap["1mo"] = "Month";
            intervalMap["1m"] = "1_Minute";
            intervalMap["5m"] = "5_Minute";
            intervalMap["1h"] = "1_Hour";

            if (radioButton_day.Checked)
            {
                interval = "1d";
            }
            else if (radioButton_week.Checked)
            {
                interval = "1wk";
            }
            else if (radioButton_month.Checked)
            {
                interval = "1mo";
            }
            else if (radioButton_1min.Checked)
            {
                interval = "1m";
            }
            else if (radioButton_5min.Checked)
            {
                interval = "5m";
            }
            else
            {
                interval = "1h";
            }
            // download data of desired stock for desired interval
            downloadData(ticker, interval);

            string stockFileName = $"{ticker}-{intervalMap[interval]}.csv";
            Console.WriteLine(stockFileName);

            if (fileExists(stockFileName))
            {
                label_downloadStatus.Text = $"Download Status: {ticker}-{intervalMap[interval]} downloaded successfully.";
                string fileName = $"C:\\Users\\patel\\Desktop\\StockProject\\Stock Data\\{stockFileName}";
                List<smartCandlestick> candlestickData = loadStockFromFile(fileName);
                Form_displayStock displayForm = new Form_displayStock(candlestickData, fileName, dateTimePicker_start.Value, dateTimePicker_end.Value);
                // Display the chart
                displayForm.Show();
            }
            else
            {
                label_downloadStatus.Text = "Download Status: Download failed! Check Ticker.";
            }
        }
    }
}

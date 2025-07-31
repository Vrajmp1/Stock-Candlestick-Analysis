# downloads stock historical data from yahoo finance
# output is a .csv file that can be read by C# .NET project
import yfinance as yf
import pandas as pd
from datetime import datetime, timedelta
import sys, os

interval_strings = {'1d':'Day',
                    '1wk':'Week',
                    '1mo':'Month',
                    '1m':'1_Minute',
                    '5m':'5_Minute',
                    '1h':'1_Hour'}

def download_stock_data(ticker, start_date, end_date, interval, output_file):
    # Download historical data from Yahoo Finance with specified interval
    stock_data = yf.download(ticker, start=start_date, end=end_date, interval=interval)

    # Keep only the desired columns
    stock_data = stock_data[['Open', 'High', 'Low', 'Close', 'Volume']]
    stock_data.columns = stock_data.columns.get_level_values(0)

    # Add a 'Ticker' column with the stock ticker
    stock_data['Ticker'] = ticker

    # Add a 'Period' column with the specified interval
    stock_data['Period'] = interval_strings[interval]

    # Add a 'Date' column with the date index
    stock_data['Date'] = stock_data.index

    # Format the 'Date' column to "Mon DD, YYYY" format
    stock_data['Date'] = stock_data['Date'].dt.strftime("%b %d, %Y")

    # Convert 'Ticker', 'Period', and 'Date' columns to strings with quotes
    stock_data[['Ticker', 'Period', 'Date']] = stock_data[['Ticker', 'Period', 'Date']].astype(str)

    # Reorder columns with the requested order
    stock_data = stock_data[['Ticker', 'Period', 'Date', 'Open', 'High', 'Low', 'Close', 'Volume']]

    # Reverse the DataFrame order
    stock_data = stock_data[::-1]
    
    # Save the data to a CSV file
    stock_data.to_csv(output_file,index=False)

if __name__ == "__main__":
    start_date = (datetime.today()-timedelta(days=500)).strftime('%Y-%m-%d')
    end_date = (datetime.today()+timedelta(days=1)).strftime('%Y-%m-%d')  # Use today's date as the end date
    
    if len(sys.argv) > 1:
        # Access additional arguments starting from sys.argv[1]
        stock_ticker = sys.argv[1]
        data_interval = sys.argv[2]
        output_file_path = os.path.abspath(os.path.join(os.getcwd(), os.pardir, os.pardir, os.pardir, f"Stock Data\\{stock_ticker}-{interval_strings[data_interval]}.csv"))
        if os.path.exists(output_file_path):
            os.remove(output_file_path)
        # Download and save stock data
        if data_interval in ["1m","5m","1h"]:
            start_date = (datetime.today()-timedelta(days=20)).strftime('%Y-%m-%d')
        download_stock_data(stock_ticker, start_date, end_date, data_interval, output_file_path)
        print(f"Stock data for {stock_ticker} downloaded and saved to {output_file_path}")
    else:
        print("No additional command line arguments provided.")
        # Replace these values with the desired default stock symbol, start date, interval, and output file path
        stock_ticker = "AAPL"  # Example: Apple Inc.
        data_interval = "1d"  # "1d" for daily, "1wk" for weekly, "1mo" for monthly
        output_file_path = os.path.abspath(os.path.join(os.getcwd(), os.pardir, os.pardir, os.pardir, f"Stock Data\\{stock_ticker}-{interval_strings[data_interval]}.csv"))
        if os.path.exists(output_file_path):
            os.remove(output_file_path)
        # Download and save stock data
        download_stock_data(stock_ticker, start_date, end_date, data_interval, output_file_path)
        print(f"Stock data for {stock_ticker} downloaded and saved to {output_file_path}")

    
    

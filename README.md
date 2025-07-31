# Stock-Candlestick-Analysis
A C#/.NET application for loading, visualizing, and analyzing candlestick chart data. 

Designed for traders and students of technical analysis, this tool allows users to load historical stock data from a CSV file or fetch it directly from Yahoo Finance. Users can interactively explore charts, highlight candlestick patterns, and adjust date ranges.

# Features
• Load daily, weekly, or monthly candlestick data from CSV files<br>
• Visual, interactive chart display with zoomable date ranges<br>
• Highlight individual candlesticks and common technical patterns (Dragonfly Doji, Marubozu, Head and Shoulders, ABCD, Double Top/Bottom, etc.)<br>
• Download historical stock data directly from Yahoo Finance via integrated Python backend<br>
• Smooth and intuitive .NET GUI<br>
• Starter csv files provided in stock data directory<br>

# Technologies Used
• C# (.NET Framework)<br>
• Microsoft Visual Studio<br>
• Python (for Yahoo Finance API integration)<br>
• CSV data parsing and in-memory object modeling<br>

# How to Run
• Download the StockProject directory with all contents<br>
• Double click the executable located at "StockProject\Stock Analysis\bin\Debug\COP 4365 Project 2.exe"<br>
• Make sure python is an environmental variable and yfinance library has been installed with pip<br>

From the startup screen:<br>
• Load a compatible CSV file with candlestick data or<br>
• Enter a ticker symbol to fetch data from Yahoo Finance<br>
• Use the interface to navigate and analyze the chart<br>

Note: The Python script must be properly linked and accessible by the C# application for API integration to work. The .csv file must be formatted as follows:<br>
<img width="515" height="42" alt="image" src="https://github.com/user-attachments/assets/8e9d4c29-4cb5-4117-9741-3c1373a66093" />

# Project Context
Created to explore real-world applications of stock market data visualization and technical pattern detection. Emphasis was placed on a smooth user experience, efficient data modeling, and integrating multiple languages (C# and Python) for a full-stack desktop tool.

# Example Screenshots
Initial Loading Screen:<br>
<img width="459" height="290" alt="image" src="https://github.com/user-attachments/assets/0395b22d-5ee5-4b24-98dd-4f362dc3a8d2" />


Amazon Daily Candlestick Data:<br>
<img width="1366" height="727" alt="image" src="https://github.com/user-attachments/assets/ba6f4afa-dd8e-4370-9b09-88ddc33965bb" />

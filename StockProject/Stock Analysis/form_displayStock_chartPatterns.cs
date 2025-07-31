using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Analysis
{
    /* Class Form_displayStock represents an instance of the Windows Form class
       with all specified components and methods to display and analyze a candlestick chart. 
       This code file is dedicated for identifying and analyzing chart patterns. */
    public partial class Form_displayStock : Form
    {
        // list of candlesticks that are tops and bottoms, stores index and 'T' or 'B' for extrema type
        List<Tuple<int, char>> topsAndBottoms = new List<Tuple<int, char>>();

        // fills the list of topsAndBottoms
        private void identifyExtrema()
        {
            topsAndBottoms.Clear();
            int extremaDegree = (int)numericUpDown_degreeOfExtrema.Value;
            int scanOut = 4; //# of candlesticks to scan forward to confirm top/bottom

            for (int i = extremaDegree; i < candlesticks.Count - Math.Max(extremaDegree, scanOut); i++)
            {
                if (isLocalBottom(i, extremaDegree))
                {
                    topsAndBottoms.Add(Tuple.Create(i, 'B'));
                    /*for (int j = 1; j <= scanOut; j++)
                    {
                        if (candlesticks[i + j].close >= candlesticks[i + j].movingAvg)
                        {
                            
                            break;
                        }
                    }*/
                }
                else if (isLocalTop(i, extremaDegree))
                {
                    topsAndBottoms.Add(Tuple.Create(i, 'T'));
                    /*for (int j = 1; j <= scanOut; j++)
                    {
                        if (candlesticks[i + j].close <= candlesticks[i + j].movingAvg)
                        {
                            
                            break;
                        }
                    }*/
                }
            }
        }
        private Boolean isLocalBottom(int bI, int scan)
        {
            for (int i = 1; i <= scan; i++)
            {
                if (candlesticks[bI].low > candlesticks[bI - i].low || candlesticks[bI].low > candlesticks[bI + i].low)
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean isLocalTop(int tI, int scan)
        {
            for (int i = 1; i <= scan; i++)
            {
                if (candlesticks[tI].high < candlesticks[tI - i].high || candlesticks[tI].high < candlesticks[tI + i].high)
                {
                    return false;
                }
            }
            return true;
        }

        /* function annotateChartPatterns marks tops and bottoms on the chart */
        private void annotateChartPatterns()
        {
            chartStock.Annotations.Clear();
            // annotate bottoms
            if (comboBox_chartPatternSelect.SelectedIndex == 0)
            {
                for (int i = 0; i < topsAndBottoms.Count; i++)
                {
                    if (topsAndBottoms[i].Item2 == 'B')
                    {
                        addArrowAnnotation(topsAndBottoms[i].Item1, "bottom");
                        //Console.WriteLine("Close: " + candlesticks[topsAndBottoms[i].Item1].date.ToString() + ": " + candlesticks[topsAndBottoms[i].Item1].close.ToString());
                        //Console.WriteLine("Low: "+ candlesticks[topsAndBottoms[i].Item1].date.ToString() + ": " + candlesticks[topsAndBottoms[i].Item1].low.ToString());
                    }
                }
                    
            } // annotate tops
            else if (comboBox_chartPatternSelect.SelectedIndex == 1)
            {
                for (int i = 0; i < topsAndBottoms.Count; i++)
                {
                    if (topsAndBottoms[i].Item2 == 'T')
                        addArrowAnnotation(topsAndBottoms[i].Item1, "top");
                }
            }
            else if (comboBox_chartPatternSelect.SelectedIndex == 2)
            {
                bullishABCD();
            }
        }

        // function addTextAnnotation() places an annotation at a given index
        private void addTextAnnotation(int dataPointIndex, string label)
        {
            // Create a new arrow annotation
            TextAnnotation textAnnotation = new TextAnnotation();

            // Set the annotation properties
            textAnnotation.Text = label;
            textAnnotation.AxisX = chartStock.ChartAreas[0].AxisX; // X-axis for the annotation
            textAnnotation.AxisY = chartStock.ChartAreas[0].AxisY; // Y-axis for the annotation
            textAnnotation.AnchorDataPoint = chartStock.Series[0].Points[dataPointIndex]; // The anchor data point for the annotation
            textAnnotation.AnchorAlignment = ContentAlignment.TopCenter; // Alignment of the annotation relative to the anchor point
            //textAnnotation.Width = 0; // Width of the arrow (negative value to point inward)
            //textAnnotation.Height = 4; // Height of the arrow (negative value to point inward)
            //textAnnotation.LineWidth = 1; // Width of the arrow line
            textAnnotation.LineColor = System.Drawing.Color.Purple; // Color of the arrow line
            textAnnotation.BackColor = System.Drawing.Color.Purple;
            textAnnotation.AnchorOffsetY = 8;  // Allow some space between arrow and candlestick

            // Add the annotation to the chart
            chartStock.Annotations.Add(textAnnotation);
        }

        // Identify and label the Bullish ABCD Pattern
        private void bullishABCD()
        {
            string extremaPattern;
            for (int i = 0; i < topsAndBottoms.Count - 3; i++)
            {
                int extremaDegree = (int)numericUpDown_degreeOfExtrema.Value;
                extremaPattern = topsAndBottoms[i].Item2.ToString() + topsAndBottoms[i + 1].Item2;
                extremaPattern += topsAndBottoms[i + 2].Item2.ToString();
                Console.WriteLine(i.ToString() + ": " + extremaPattern);
                if (extremaPattern == "BTB")
                {
                    Console.WriteLine("Matched" + i.ToString() + ": " + extremaPattern);
                    //addArrowAnnotation(topsAndBottoms[i].Item1,"Begin"); addArrowAnnotation(topsAndBottoms[i+1].Item1);
                    //addArrowAnnotation(topsAndBottoms[i+2].Item1); addArrowAnnotation(topsAndBottoms[i+3].Item1);
                    smartCandlestick A = candlesticks[topsAndBottoms[i].Item1];
                    smartCandlestick B = candlesticks[topsAndBottoms[i + 1].Item1];
                    smartCandlestick C = candlesticks[topsAndBottoms[i + 2].Item1];
                    //smartCandlestick D = candlesticks[topsAndBottoms[i + 3].Item1];
                    int ABLegInterval = topsAndBottoms[i + 1].Item1 - topsAndBottoms[i].Item1;
                    int BCLegInterval = topsAndBottoms[i + 2].Item1 - topsAndBottoms[i + 1].Item1;
                    int CDLegInterval = topsAndBottoms[i + 3].Item1 - topsAndBottoms[i + 2].Item1;
                    Decimal ABLegSpan = B.close - A.close;
                    Decimal BCLegSpan = B.close - C.close;
                    //Decimal CDLegSpan = D.close - C.close;
                    if (Math.Abs(BCLegSpan / ABLegSpan) <= (Decimal)0.61 && BCLegSpan / ABLegSpan >= (Decimal)0.32 && ABLegInterval >= extremaDegree)
                    {
                        addTextAnnotation(topsAndBottoms[i].Item1,"ABCD");
                        addArrowAnnotation(topsAndBottoms[i].Item1);
                    }
                }
            }
        }
        private void comboBox_chartPatternSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            identifyExtrema();
            annotateChartPatterns();
        }

        private void numericUpDown_scan_ValueChanged(object sender, EventArgs e)
        {
            identifyExtrema();
            annotateChartPatterns();
        }



    }
}
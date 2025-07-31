using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analysis
{
    /* Abstract class recognizer serves as the base class from which various candlestick
       pattern recognizers are derived. This class cannot be instantiated since each 
       derived class must provide a definition for the abstract function recognizePattern()*/
    abstract public class recognizer
    {
        // define two variables - patternName and patternSize inherent to all recognizers
        public string patternName { get; set; }
        public int patternSize { get; set; }

        // constructor to set the value of the patternName and patternSize
        public recognizer(string patternName, int patternSize)
        {
            this.patternName = patternName;
            this.patternSize = patternSize;
        }

        /* The method recognize() takes in a list of smartCandlesticks and returns a 
           list of integers of indicies where the specificed pattern is observed */
        public List<int> recognize(List<smartCandlestick> scs)
        {
            List<int> indices = new List<int>();
            // iterate through scs starting at the minimum index allowed by patternSize
            for (int i = patternSize - 1; i < scs.Count(); i++)
            {
                // send the required number of candlesticks to the recognize pattern function
                if (recognizePattern(scs.GetRange(i-patternSize+1,patternSize)))
                    indices.Add(i);     // add the index if the pattern is observed
            }
            return indices;     // return all indices where pattern was found
        }

        /* Abstract method recognizePattern() must be implemented by each derived type of 
           recognizer. Given the minimum number of candlesticks to determine a given pattern,
           this function should return a boolean indicating whether the pattern exists.*/
        abstract public Boolean recognizePattern(List<smartCandlestick> scsGroup);
    }

    /* Beginning definitions of all concrete recognizer classes derived from base class above
       Note that each constructor below gives its pattern name and number of candlesticks 
       required directly to the base constructor. Also, each derived class offers a override 
       definition for the patternRecognize() function to tell its caller, the recognize() method 
       whether its assigned pattern exists for the given set of candlesticks. Use of polymorphism. */

    // ========================== Single Candlestick Patterns =========================== //
    // bullishRecognizer class
    public class bullishRecognizer : recognizer
    {

        // general constructor
        public bullishRecognizer() : base("Bullish", 1) { }

        // determine if given candlestick is bullish
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isBullish;
        }
    }

    // bearishRecognizer class
    public class bearishRecognizer : recognizer
    {

        // general constructor
        public bearishRecognizer() : base("Bearish", 1) { }

        // determine if given candlestick is bearish
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isBearish;
        }
    }

    // neutralRecognizer class
    public class neutralRecognizer : recognizer
    {

        // general constructor
        public neutralRecognizer() : base("Neutral", 1) { }

        // determine if given candlestick is neutral
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isNeutral;
        }
    }

    // marubozuRecognizer class
    public class marubozuRecognizer : recognizer
    {

        // general constructor
        public marubozuRecognizer() : base("Marubozu", 1) { }

        // determine if given candlestick is a marubozu
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isMarubozu;
        }
    }

    // dojiRecognizer class
    public class dojiRecognizer : recognizer
    {

        // general constructor
        public dojiRecognizer() : base("Doji", 1) { }

        // determine if given candlestick is a doji
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isDoji;
        }
    }

    // dragonflyDojiRecognizer class
    public class dragonFlyDojiRecognizer : recognizer
    {

        // general constructor
        public dragonFlyDojiRecognizer() : base("Dragonfly Doji", 1) { }

        // determine if given candlestick is a dragonfly doji
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isDragonFlyDoji;
        }
    }

    // graveStoneDojiRecognizer class
    public class graveStoneDojiRecognizer : recognizer
    {

        // general constructor
        public graveStoneDojiRecognizer() : base("Gravestone Doji", 1) { }

        // determine if given candlestick is a gravestone doji
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isGraveStoneDoji;
        }
    }

    // hammerRecognizer class
    public class hammerRecognizer : recognizer
    {

        // general constructor
        public hammerRecognizer() : base("Hammer", 1) { }

        // determine if given candlestick is a hammer
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isHammer;
        }
    }

    // invertedHammerRecognizer class
    public class invertedHammerRecognizer : recognizer
    {

        // general constructor
        public invertedHammerRecognizer() : base("Inverted Hammer", 1) { }

        // determine if given candlestick is an inverted hammer
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return scsGroup[0].isInvertedHammer;
        }
    }

    // ========================== 2 Candlestick Patterns =========================== //

    // engulfingRecognizer class
    public class engulfingRecognizer : recognizer
    {
        // general constructor
        public engulfingRecognizer() : base("Engulfing", 2) { }

        // determine if given dual candlesticks constitute an engulfing pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[0].topPrice < scsGroup[1].topPrice) && (scsGroup[0].bottomPrice > scsGroup[1].bottomPrice) && (scsGroup[0].isBullish ^ scsGroup[1].isBullish) && (scsGroup[0].isBearish ^ scsGroup[1].isBearish);
        }
    }

    // bullishEngulfingRecognizer class
    public class bullishEngulfingRecognizer : recognizer
    {
        // general constructor
        public bullishEngulfingRecognizer() : base("Bullish Engulfing", 2) { }

        // determine if given dual candlesticks constitute a bullish engulfing pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[0].topPrice < scsGroup[1].topPrice) && (scsGroup[0].bottomPrice > scsGroup[1].bottomPrice) && scsGroup[1].isBullish && scsGroup[0].isBearish;
        }
    }

    // bearishEngulfingRecognizer class
    public class bearishEngulfingRecognizer : recognizer
    {
        // general constructor
        public bearishEngulfingRecognizer() : base("Bearish Engulfing", 2) { }

        // determine if given dual candlesticks constitute a bearish engulfing pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[0].topPrice < scsGroup[1].topPrice) && (scsGroup[0].bottomPrice > scsGroup[1].bottomPrice) && scsGroup[1].isBearish && scsGroup[0].isBullish;
        }
    }

    // haramiRecognizer class
    public class haramiRecognizer : recognizer
    {
        // general constructor
        public haramiRecognizer() : base("Harami", 2) { }

        // determine if given dual candlesticks constitute a harami pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[1].topPrice < scsGroup[0].topPrice) && (scsGroup[1].bottomPrice > scsGroup[0].bottomPrice) && (scsGroup[0].isBullish ^ scsGroup[1].isBullish) && (scsGroup[0].isBearish ^ scsGroup[1].isBearish);
        }
    }

    // bullishHaramiRecognizer class
    public class bullishHaramiRecognizer : recognizer
    {
        // general constructor
        public bullishHaramiRecognizer() : base("Bullish Harami", 2) { }

        // determine if given dual candlesticks constitute a bullish harami pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[1].topPrice < scsGroup[0].topPrice) && (scsGroup[1].bottomPrice > scsGroup[0].bottomPrice) && scsGroup[1].isBullish && scsGroup[0].isBearish;
        }
    }

    // bearishHaramiRecognizer class
    public class bearishHaramiRecognizer : recognizer
    {
        // general constructor
        public bearishHaramiRecognizer() : base("Bearish Harami", 2) { }

        // determine if given dual candlesticks constitute a bearish harami pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[1].topPrice < scsGroup[0].topPrice) && (scsGroup[1].bottomPrice > scsGroup[0].bottomPrice) && scsGroup[1].isBearish && scsGroup[0].isBullish;
        }
    }

    // ========================== 3 Candlestick Patterns =========================== //

    // peakRecognizer class
    public class peakRecognizer : recognizer
    {
        // general constructor
        public peakRecognizer() : base("Peak", 3) { }

        // determine if given triple candlesticks constitute a peak pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[0].high < scsGroup[1].high) && (scsGroup[2].high < scsGroup[1].high);
        }
    }

    // valleyRecognizer class
    public class valleyRecognizer : recognizer
    {
        // general constructor
        public valleyRecognizer() : base("Valley", 3) { }

        // determine if given triple candlesticks constitute a valley pattern
        public override Boolean recognizePattern(List<smartCandlestick> scsGroup)
        {
            return (scsGroup[0].low > scsGroup[1].low) && (scsGroup[2].low > scsGroup[1].low);
        }
    }

    // ============== end of all types of derived recognizers class definitions ============//
}

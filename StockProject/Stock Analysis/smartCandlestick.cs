using System;

namespace Stock_Analysis
{
    /* smartCandlestick is the child class of the regular aCandlestick class,
       and contains higher level properties of candlesticks, as well as 
       boolean variables to identify itself as single candlestick patterns. */
    public class smartCandlestick : aCandlestick
    {
        // higher level properties for smart candlesticks
        public decimal range { get; private set; }
        public decimal bodyRange { get; private set; }
        public decimal topPrice { get; private set; }
        public decimal bottomPrice {  get; private set; }
        public decimal topTail {  get; private set; }
        public decimal bottomTail { get; private set; }

        // pattern Booleans
        public Boolean isBullish { get; private set; }
        public Boolean isBearish { get; private set; }
        public Boolean isNeutral { get; private set; }
        public Boolean isMarubozu { get; private set; }
        public Boolean isDoji { get; private set; }
        public Boolean isDragonFlyDoji { get; private set; }
        public Boolean isGraveStoneDoji { get; private set; }
        public Boolean isHammer { get; private set; }
        public Boolean isInvertedHammer { get; private set; }

        //leeway is a static variable common to all candlesticks to be used when computing patterns
        static double leeway = 0.15;

        /* This is the constructor for smartCandlestick that calls the base constructor
           to initialize its derived properties and then uses those to set its higher
           level properties as well as its pattern boolean descriptors.*/
        public smartCandlestick(String line) :  base(line)
        {
            computeHigherProperties();
            computePatterns();
        }

        /* computeHigherProperties() is a function called by the constructor to
           initialize the higher level properties from the basic derived properties*/
        private void computeHigherProperties()
        {
            range = high - low;
            bodyRange = Math.Abs(open - close);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = high - topPrice;
            bottomTail = bottomPrice - low;
        }

        /* computePatterns() is a function called by the constructor that computes
           and sets the various isPattern variables based on the higher level properties.
           Note that properties are computed with a certain amount of leeway.*/
        private void computePatterns()
        {
            isBullish = (double)(close - open) > 0.0005*(double)close;
            isBearish = (double)(open - close) > 0.0005*(double)close;
            isNeutral = !isBullish && !isBearish;
            if (range == 0)
            {
                isMarubozu = false;
                isDoji = false;
                isHammer = false;
                isInvertedHammer = false;
                isDragonFlyDoji = false;
                isGraveStoneDoji = false;
            }
            else
            {
                isMarubozu = (double)(bodyRange / range) > (1 - leeway);
                isDoji = (double)(bodyRange / range) < leeway;
                isHammer = (.18 < (double)(bodyRange / range)) && ((double)(bodyRange / range) < .42) && ((double)(topTail / range) < .09);
                isInvertedHammer = (.18 < (double)(bodyRange / range)) && ((double)(bodyRange / range) < .42) && ((double)(bottomTail / range) < .09);
                isDragonFlyDoji = ((double)(topTail / range) < .12) && isDoji;
                isGraveStoneDoji = ((double)(bottomTail / range) < .12) && isDoji;
            }
        }

    }
}

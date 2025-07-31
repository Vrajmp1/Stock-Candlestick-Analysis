using System;
using System.Collections.Generic;

namespace Stock_Analysis
{
    // class aCandlestick encapsulates all price data associated with one candlestick
    public class aCandlestick
    {
        // The following are the data varaibles needed for each candlestick,
        // along with their getters and setters to accomodate controls' data binding 
        public DateTime date { get; set; }
        public Decimal open { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal close { get; set; }
        public long volume { get; set; }
        public Decimal movingAvg {  get; set; }

        // The following is the default constructor that takes in no arguments and
        // assigns default values to all class variables
        public aCandlestick() { }

        // The following constructor instantiates a candlestick,
        // but requires all class variables be specified. Otherwise,
        // default values will be used in the new candlestick
        public aCandlestick(DateTime date, decimal open = 0, decimal high = 0, decimal low = 0, decimal close = 0, long volume = 0)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        // The following constuctor is used to instantiate a candlestick by parsing a line
        // of data from the .csv file. Relevant data is indexed and assigned to class variables
        public aCandlestick(string rowOfData)
        {
            char[] separators = new char[] { ',', ' ', '"', '-' };
            //StringSplitOptions is an enumerations to help ignore empty strings
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> map = new Dictionary<string, int>();
            int i = 1;
            map.Add("Jan", i++);
            map.Add("Feb", i++);
            map.Add("Mar", i++);
            map.Add("Apr", i++);
            map.Add("May", i++);
            map.Add("Jun", i++);
            map.Add("Jul", i++);
            map.Add("Aug", i++);
            map.Add("Sep", i++);
            map.Add("Oct", i++);
            map.Add("Nov", i++);
            map.Add("Dec", i++);

            Console.WriteLine($"Parsed year: '{subs[4]}'");
            Console.WriteLine($"Parsed month: '{subs[2]}'");
            Console.WriteLine($"Parsed day: '{subs[3]}'");

            //class variables are initialized according to their order
            try { this.date = new DateTime(int.Parse(subs[4]), map[subs[2]], int.Parse(subs[3])); }
            catch {
                Console.WriteLine($"Parsed year: '{subs[4]}'");
                Console.WriteLine($"Parsed month: '{subs[2]}'");
                Console.WriteLine($"Parsed day: '{subs[3]}'");
            }

            this.open = Decimal.Parse(subs[5]);
            this.high = Decimal.Parse(subs[6]);
            this.low = Decimal.Parse(subs[7]);
            this.close = Decimal.Parse(subs[8]);
            this.volume = long.Parse(subs[9]);

        }
    }
}

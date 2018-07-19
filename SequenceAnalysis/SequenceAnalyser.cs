using System;
using System.Linq;

namespace SequenceAnalysis
{
    public class SequenceAnalyser:ISequenceAnalyser
    {
        private static SequenceAnalyser instance = null;
        private static readonly object padlock = new object();

        SequenceAnalyser()
        {
            instance = this;
        }

        public static SequenceAnalyser Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SequenceAnalyser();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Return the string with all UpperCase in Alphabetical Order or null 
        /// </summary>
        /// <param name="inputString">User string</param>
        public string StringAnalyser(string inputString)
        {
            string stringwithCaps = String.Concat(inputString.Where(x => Char.IsUpper(x)));
            if(stringwithCaps == "")
            {
                return null;
            }
            string outputStr = Alphabetize(stringwithCaps);
            return outputStr;
           
        }

        /// <summary>
        /// Return the string in alphabetical order.
        /// </summary>
        /// <param name="str">input string for sorting</param>
        private string Alphabetize(string str)
        {
            char[] a = str.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }
    }
}

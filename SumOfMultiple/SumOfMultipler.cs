namespace SumOfMultiple
{
    public  class SumOfMultipler:ISumOfMultipler
    {

        private static SumOfMultipler instance = null;
        private static readonly object padlock = new object();

        SumOfMultipler()
        {
            instance = this;
        }

        public static SumOfMultipler Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SumOfMultipler();
                        }
                    }
                }
                return instance;
            }
        }


        /// <summary>
        /// Return the sum of all natural numbers which are multiple of 3 and 5 within given range/limit
        /// </summary>
        /// <param name="limit">Range defined by User in Long</param>
        public long Find_SumOfMultiple_ThreeAndFive(long limit)
        {
            long result;
            long sum_Of_Three = Calculate_Sum(3, limit);
            long sum_Of_Five = Calculate_Sum(5, limit);
            long sum_Of_Fifteen = Calculate_Sum(15, limit);

            return result = (sum_Of_Three + sum_Of_Five - sum_Of_Fifteen);

        }


        /// <summary>
        /// Return the sum of all natural numbers which are multiple of any number within given range/limit
        /// </summary>
        /// <param name="a">Number for which total sum of all natural numbersis required</param>
        /// <param name="N">Range defined by user</param>
        private long Calculate_Sum(long a, long N)
        {
            long m = N / a;
            long sum = m * (m + 1) / 2;
            long ans = a * sum;
            return ans;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SequenceAnalysis;
using SumOfMultiple;
using System.IO;

namespace Runner
{
    public class RunnerLogic
    {
        private ISequenceAnalyser sequenceAnalyser;
        private ISumOfMultipler sumOfMultipler;

        private static RunnerLogic instance = null;
        private static readonly object padlock = new object();

        RunnerLogic()
        {
            instance = this;
        }

        public static RunnerLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new RunnerLogic();
                        }
                    }
                }
                return instance;
            }
        }

        public void Init()
        {     
            StartRunner();
        }

        /// <summary>
        /// Starting point of Runner Application
        /// </summary>
        private void StartRunner()
        {
            Console.WriteLine("*****************************\nWelcome to Runner Console Application\n*****************************");
            bool isExit = true;

            do
            {
                isExit = GetUserSelection();
            }
            while (!isExit);
        }

        /// <summary>
        /// Return the user input to Runner application Console
        /// </summary>
        private bool GetUserSelection()
        {
            bool shouldExit = false;
            int input = GetProblemStatements();

            if (input == 1) 
            {
                GetSumOfMultiplie();
            }
            else if (input == 2) 
            {
                GetSequenceAnalysis();
            }
            else if (input == 3)
            {
                Console.WriteLine("Closing.....Thankyou for using Runner Application");
                Thread.Sleep(3000);
                shouldExit = true;
            }
            else
            {
                Console.WriteLine("You have not choosen the available option, Please select again!!!!!\n");
            }
            return shouldExit;

        }

        /// <summary>
        /// Display the result of Sequence Analysis Problem in Console
        /// </summary>
        private void GetSequenceAnalysis()
        {
            try
            {
                sequenceAnalyser = SequenceAnalysis.SequenceAnalyser.Instance;
                Console.WriteLine("Entering to Sequence Analyser Problem: \n * Enter your Input String");
                string inputValue = Console.ReadLine();
                string result = sequenceAnalyser.StringAnalyser(inputValue);
                Console.WriteLine("\n*************************");
                Console.WriteLine("Input: {0}", inputValue);
                if (result != null)
                {                                    
                    Console.WriteLine("Output: {0}", result);                   
                }
                else
                {
                    Console.WriteLine("Output: Sorry no capital alphabets avialable in input");
                }
                Console.WriteLine("*************************\n");
            }
            catch( Exception ex)
            {
                // We can write all these exception in log file which I have not implemented for this application
            }
            
        }

        /// <summary>
        /// Display the result of Sum Of Multiple Problem in Console 
        /// </summary>
        private void GetSumOfMultiplie()
        {
            try
            {
                sumOfMultipler = SumOfMultiple.SumOfMultipler.Instance;
                Console.WriteLine("Entering to Sum of Multiple Problem: \n * Enter the limit value from 1 to 9223372036854775805");
                string inputValue = Console.ReadLine();
                long limit;
                bool result = long.TryParse(inputValue, out limit);
                Console.WriteLine("\n*************************");
                Console.WriteLine("Input: {0}", inputValue);
                if (!result)
                {
                    Console.WriteLine("Output: Input value is incorrect or exceeding the limit");
                }
                else
                {
                    if (!((limit < 0) || (limit > 9223372036854775805)))
                    {
                        long sum = sumOfMultipler.Find_SumOfMultiple_ThreeAndFive(limit);
                        Console.WriteLine("Output: {0}", sum);
                    }
                    else
                    {
                        Console.WriteLine("Output: Input value is incorrect or exceeding the limit");                  
                    }
                    
                }
                Console.WriteLine("*************************\n");
            }
            catch(Exception ex)
            {   // We can write all these exception in log file which I have not implemented for this application
            }
        }

        /// <summary>
        /// Display all supported problem statement an instruction to user.
        /// </summary>
        private int GetProblemStatements()
        {
            int result = 0;
            try
            {
                Console.WriteLine("Please enter which problem you want to solve:\n * Press 1 for Sum Of Multiple \n * Press 2 for Sequence Analysis \n * Press 3 for Exit");
                result = Convert.ToInt32(Console.ReadLine());               
            }
            catch (Exception ex)
            {
                // We can write all these exception in log file which I have not implemented for this application
            }
            return result;
        }
    }
}

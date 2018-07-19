using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace Runner
{
    class Program
    {
        /// <summary>
        /// The main entry point for the Runner application.
        /// </summary>
        static void Main(string[] args)
        {
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            // Check that no other instance is running before doing anything
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1) 
            {
                Console.Write("Runner application is already running");
                Thread.Sleep(3000);   // Application Process kils automatically after 3 seconds
                return;
            }
            else
            {
                RunnerLogic runnerLogic = RunnerLogic.Instance;
                runnerLogic.Init();
            }        
        }
    }
}

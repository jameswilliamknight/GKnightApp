using System;
using System.Collections.Generic;
using System.Diagnostics;
using AppKill.Windows;

namespace AppKill.Workflow
{
    internal class Lister : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            var temp = new KeyValuePair<Process[], string>(
                ProcessRepository.GetProcesses(true),
                "All Processes");

            Log.Processes(temp);

            if (appArgs.InteractiveMode)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            return 0;
        }
    }
}
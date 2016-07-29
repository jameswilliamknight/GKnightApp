using System;
using System.Collections.Generic;
using System.Diagnostics;
using AppKill.Util;
using AppKill.Windows;

namespace AppKill.Workflow
{
    internal class Lister : IWorkflowUnit
    {
        private readonly AppArgs _appArgs;

        public Lister(AppArgs appArgs)
        {
            _appArgs = appArgs;
        }

        public int Run()
        {
            var temp = new KeyValuePair<Process[], string>(
                ProcessRepository.GetProcesses(true),
                "All Processes");

            Log.Processes(temp);

            if (_appArgs.InteractiveMode)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            return 0;
        }
    }
}
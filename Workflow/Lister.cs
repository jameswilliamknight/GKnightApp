using System;
using AppKiller.Windows;

namespace AppKiller.Workflow
{
    internal class Lister : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            ProcessRepository.GetProcesses(true);

            if (appArgs.InteractiveMode)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            return 0;
        }
    }
}
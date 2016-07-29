using System;
using AppKiller.Windows;

namespace AppKiller.Workflow
{
    internal class Lister : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            ProcessRepository.GetProcesses(true);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            return 0;
        }
    }
}
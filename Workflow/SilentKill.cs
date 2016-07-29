using System;
using AppKill.Windows;
using AppKill.Workflow.Types;

namespace AppKill.Workflow
{
    internal class SilentKill : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            var killList = appArgs.KillList.ToArray();

            var processToEnd = ProcessRepository
                .GetProcesses(false)
                .Filter(killList);

            Console.WriteLine($"{processToEnd.Length} processes killed.");

            foreach (var processName in ProcessRepository.EndProcesses(processToEnd, ProcessAction.Exit))
            {
                if (appArgs.Verbose)
                {
                    Console.WriteLine($"Killed {processName}");
                }
            }
            
            return 0;
        }
    }
}
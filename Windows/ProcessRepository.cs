using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AppKiller.Workflow;
using AppKiller.Workflow.Types;

namespace AppKiller.Windows
{
    internal static class ProcessRepository
    {
        /// <summary>
        ///     Prints and returns a collection of all currently running processes
        /// </summary>
        /// <param name="log"></param>
        public static IOrderedEnumerable<Process> GetProcesses(bool log)
        {
            var currentProcesses = Process
                .GetProcesses()
                .OrderBy(p => p.ProcessName);

            var processNames = currentProcesses
                .Select(p => p.ProcessName)
                .ToList();

            if (log)
            {
                Console.WriteLine("All Processes:");
                Console.WriteLine(string.Join(", ", processNames));
            }

            return currentProcesses;
        }

        public static IEnumerable<string> EndProcesses(IEnumerable<Process> toEndProcess, ProcessAction action)
        {
            foreach (var process in toEndProcess)
            {
                switch (action)
                {
                    case ProcessAction.Exit:
                        if (!process.HasExited)
                        {
                            process.Kill();
                            yield return process.ProcessName;
                        }
                        break;

                    case ProcessAction.Close:
                        process.CloseMainWindow();
                        yield return process.ProcessName;
                        break;
                }
            }
        }
    }
}
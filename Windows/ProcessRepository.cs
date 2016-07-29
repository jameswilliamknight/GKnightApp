using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AppKill.Workflow.Types;

namespace AppKill.Windows
{
    internal static class ProcessRepository
    {
        /// <summary>
        ///     Prints and returns a collection of all currently running processes
        /// </summary>
        /// <param name="log"></param>
        public static Process[] GetProcesses(bool log)
        {
            return Process
                .GetProcesses()
                .OrderBy(p => p.ProcessName)
                .ToArray();
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
using System;
using System.Linq;
using AppKiller.Windows;
using AppKiller.Workflow.Types;

namespace AppKiller.Workflow
{
    internal class Interactive : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            var killList = appArgs.KillList.ToArray();

            var _keyPressed = '\0';

            do
            {
                var currentProcesses = ProcessRepository.GetProcesses(true);

                var toEndProcess = currentProcesses.Filter(killList);

                Console.WriteLine("Kill Processes:");
                Console.WriteLine(String.Join(", ", toEndProcess.Select(p => p.ProcessName)));

                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine();
                Console.WriteLine("Q - Quit");
                Console.WriteLine("C - Close Main Window");
                Console.WriteLine("K - Kill");

                _keyPressed = Console.ReadKey().KeyChar;

                switch (_keyPressed)
                {
                    case 'k':
                    case 'K':
                        ProcessRepository.EndProcesses(toEndProcess, ProcessAction.Exit);
                        break;
                    case 'c':
                    case 'C':
                        ProcessRepository.EndProcesses(toEndProcess, ProcessAction.Close);
                        break;
                    case 'q':
                    case 'Q':
                        break;
                    default:
                        // set the key to null so we get prompted again.
                        _keyPressed = '\0';
                        break;
                }
                Console.Clear();
            } while (_keyPressed == '\0');

            return 0;
        }
    }
}
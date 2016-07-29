using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AppKiller.Windows;
using AppKiller.Workflow.Types;

namespace AppKiller.Workflow
{
    internal class Interactive : IWorkflowUnit
    {
        /// <summary>
        ///     Displays all the available keys.
        /// </summary>
        private static void PrintMenuFooter()
        {
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine();
            Console.WriteLine("Q - Quit");
            Console.WriteLine("C - Close Main Window");
            Console.WriteLine("K - Kill");
        }

        public int Run(AppArgs appArgs)
        {
            var killList = appArgs.KillList.ToArray();

            var _keyPressed = '\0';

            do
            {
                var json = new List<KeyValuePair<Process[], string>>();

                var currentProcesses = new KeyValuePair<Process[], string>(
                    ProcessRepository.GetProcesses(true),
                    "All Processes");

                json.Add(currentProcesses);
                
                var toEndProcess = new KeyValuePair<Process[], string>(
                    currentProcesses.Key.Filter(killList), 
                    "Kill Processes");

                json.Add(toEndProcess);

                // TODO: Seperate concerns - generating JSON and Displaying.
                foreach (var jsonPair in json)
                {
                    LogProcesses(jsonPair);
                }

                PrintMenuFooter();

                _keyPressed = Console.ReadKey().KeyChar;

                switch (_keyPressed)
                {
                    case 'k':
                    case 'K':
                        ProcessRepository.EndProcesses(toEndProcess.Key, ProcessAction.Exit);
                        break;
                    case 'c':
                    case 'C':
                        ProcessRepository.EndProcesses(toEndProcess.Key, ProcessAction.Close);
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

        private static void LogProcesses(KeyValuePair<Process[], string> processCategory)
        {
            var currentProcesses = processCategory.Key;
            var heading = processCategory.Value;

            var processNames = currentProcesses
                .Select(p => p.ProcessName)
                .ToList();

            
            if (processNames.Any())
            {
                Console.Write("\"" + heading + "\"" + ": \n[");
                Console.Write("\n    '");
                Console.Write(string.Join("',\n    '", processNames.Distinct()));
                Console.WriteLine("'\n]\n");
            }
            else
            {
                Console.WriteLine("\"" + heading + "\"" + ": null");
            }

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using AppKill.Core;
using AppKill.Util;
using AppKill.Workflow.Types;

namespace AppKill.Workflow
{
    internal class Interactive : IWorkflowUnit
    {
        private readonly AppArgs _appArgs;

        public Interactive(AppArgs appArgs)
        {
            _appArgs = appArgs;
        }

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

        public int Run()
        {
            var killList = _appArgs.KillList.ToArray();

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
                    Log.Processes(jsonPair);
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
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AppKiller.Workflow
{
    internal static class Log
    {
        public static void Processes(KeyValuePair<Process[], string> processCategory)
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
                Console.Write(String.Join("',\n    '", processNames.Distinct()));
                Console.WriteLine("'\n]\n");
            }
            else
            {
                Console.WriteLine("\"" + heading + "\"" + ": null");
            }

            
        }
    }
}
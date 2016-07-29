using System;
using System.Collections.Generic;
using System.Linq;
using Fclp;

namespace AppKill
{
    internal class AppArgs
    {
        // State
        // -------------------------------------------------------------------------------------------------------------
        public bool InteractiveMode { get; set; }

        public bool ListProcesses { get; set; }

        public List<string> KillList { get; set; }

        public bool Verbose { get; set; }

        public bool HelpMode { get; set; }


        // -------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Factory method to create this class.
        /// </summary>
        public static AppArgs Build(string[] args)
        {
            var fclp = new FluentCommandLineParser<AppArgs>();
            var appArgs = new AppArgs();

            fclp.Setup(arg => arg.HelpMode)
                .As('h', "help")
                .Callback(result => appArgs.HelpMode = result)
                .SetDefault(false);

            fclp.Setup(arg => arg.InteractiveMode)
                .As('i', "interactive")
                .Callback(result => appArgs.InteractiveMode = result)
                .SetDefault(false);

            fclp
                .Setup(arg => arg.KillList)
                .As('k', "kill")
                .Callback(result => appArgs.KillList = result)
                .SetDefault(new List<string>());

            fclp.Setup(arg => arg.ListProcesses)
                .As('l', "list")
                .Callback(result => appArgs.ListProcesses = result)
                .SetDefault(false);

            fclp.Setup(arg => arg.Verbose)
                .As('v', "verbose")
                .Callback(result => appArgs.Verbose = result)
                .SetDefault(false);

            fclp.Parse(args);

            if (appArgs.Verbose)
            {
                Console.WriteLine($"Verbose = {appArgs.Verbose}");
                Console.WriteLine($"Interactive Mode = {appArgs.InteractiveMode}");
                Console.WriteLine($"ListProcesses = {appArgs.ListProcesses}");
                if (appArgs.KillList.Any())
                {
                    Console.WriteLine("\"Kill List\": [ \"{0}\" ]", string.Join("\", \"", appArgs.KillList));
                }
            }

            return appArgs;
        }
    }
}
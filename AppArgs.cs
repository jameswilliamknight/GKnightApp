using System.Linq;
using Fclp;

namespace AppKiller
{
    internal class AppArgs
    {
        // State
        // -------------------------------------------------------------------------------------------------------------
        public bool InteractiveMode { get; set; }

        public bool ListProcesses { get; set; }

        public string[] KillList { get; set; }


        // -------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Factory method to create this class.
        /// </summary>
        public static AppArgs Build(string[] args)
        {
            var fclp = new FluentCommandLineParser<AppArgs>();
            var appArgs = new AppArgs();

            fclp.Setup(arg => arg.InteractiveMode)
                .As('i', "interactive")
                .Callback(result => appArgs.InteractiveMode = result)
                .SetDefault(false);

            fclp
                .Setup(arg => arg.KillList)
                .As('k', "kill")
                .Callback(result => appArgs.KillList = result)
                .SetDefault(new string[0]);

            fclp.Setup(arg => arg.ListProcesses)
                .As('l', "list")
                .Callback(result => appArgs.ListProcesses = result)
                .SetDefault(false);

            fclp.Parse(args);
            return appArgs;
        }
    }
}
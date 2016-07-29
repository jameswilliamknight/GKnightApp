using System;
using AppKill.Extensions;
using AppKill.Workflow;
using AppKill.Workflow.Types;

namespace AppKill
{
    public class Program
    {
        static void Main(string[] args)
        {
            var appArgs = AppArgs.Build(args);

            var exitCode = Bootstrap(appArgs)?.Run();

            Environment.Exit(exitCode ?? 64); // http://stackoverflow.com/a/24121322
        }

        private static IWorkflowUnit Bootstrap(AppArgs appArgs)
        {
            IWorkflowUnit workflowUnit = null;

            switch (appArgs.Mode())
            {
                case AppMode.Help:
                    workflowUnit = new Help(appArgs);
                    break;

                case AppMode.List:
                case AppMode.List | AppMode.Interactive:
                    workflowUnit = new Lister(appArgs);
                    break;

                case AppMode.Interactive | AppMode.SilentKill:
                case AppMode.Interactive:
                    workflowUnit = new Interactive(appArgs);
                    break;

                case AppMode.SilentKill:
                    workflowUnit = new SilentKill(appArgs);
                    break;
            }

            return workflowUnit;
        }
    }
}
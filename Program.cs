using System;
using AppKill.Extensions;
using AppKill.Workflow;
using AppKill.Workflow.Types;

namespace AppKill
{
    public class Program
    {
        public bool Interactive { get; set; }

        static void Main(string[] args)
        {
            Environment.Exit(
                Bootstrap(
                    AppArgs.Build(args)));
        }

        private static int Bootstrap(AppArgs appArgs)
        {
            IWorkflowUnit workflowUnit;

            switch (AppArgsExtension.GetMode(appArgs))
            {
                case AppMode.Help:
                    workflowUnit = new Help();
                    break;

                case AppMode.List:
                case AppMode.List | AppMode.Interactive:
                    workflowUnit = new Lister();
                    break;

                case AppMode.Interactive | AppMode.SilentKill:
                case AppMode.Interactive:
                    workflowUnit = new Interactive();
                    break;

                case AppMode.SilentKill:
                    workflowUnit = new SilentKill();
                    break;

                default:
                    // http://stackoverflow.com/a/24121322
                    return 64;
            }

            return workflowUnit.Run(appArgs);
        }
    }
}
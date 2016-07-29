using System;
using AppKiller.Extensions;
using AppKiller.Workflow;
using AppKiller.Workflow.Types;

namespace AppKiller
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
            IWorkflowUnit WorkflowUnit;
            switch (AppArgsExtension.GetMode(appArgs))
            {
                case AppMode.List:
                case AppMode.List | AppMode.Interactive:
                    WorkflowUnit = new Lister();
                    break;

                case AppMode.Interactive:
                    WorkflowUnit = new Interactive();
                    break;

                case AppMode.SilentKill:
                    WorkflowUnit = new SilentKill();
                    break;

                default:
                    // http://stackoverflow.com/a/24121322
                    return 64;
            }

            return WorkflowUnit.Run(appArgs);
        }
    }
}
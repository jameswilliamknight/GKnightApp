using AppKiller.Windows;
using AppKiller.Workflow.Types;

namespace AppKiller.Workflow
{
    internal class Silent : IWorkflowUnit
    {
        public int Run(AppArgs appArgs)
        {
            var processToEnd = ProcessRepository.GetProcesses(false).Filter(appArgs.KillList);

            ProcessRepository.EndProcesses(processToEnd, ProcessAction.Exit);

            return 0;
        }
    }
}
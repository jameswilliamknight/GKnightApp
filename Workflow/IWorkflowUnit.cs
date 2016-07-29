namespace AppKiller.Workflow
{
    internal interface IWorkflowUnit
    {
        int Run(AppArgs appArgs);
    }
}
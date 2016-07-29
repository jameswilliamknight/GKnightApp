namespace AppKill.Workflow
{
    internal interface IWorkflowUnit
    {
        int Run(AppArgs appArgs);
    }
}
using System.Linq;
using AppKiller.Workflow.Types;

namespace AppKiller
{
    internal static class Work
    {
        /// <summary>
        ///     Factory <see cref="AppMode"/> method.
        /// </summary>
        public static AppMode GetMode(this AppArgs args)
        {
            var mode = AppMode.None;

            if (args.KillList.Any())
            {
                mode |= AppMode.SilentKill;
            }

            if (args.InteractiveMode)
            {
                mode |= AppMode.Interactive;
            }

            if (args.ListProcesses)
            {
                mode |= AppMode.List;
            }

            return mode;
        }
    }
}
using System.Linq;
using AppKill.Workflow.Types;

namespace AppKill.Extensions
{
    internal static class AppArgsExtension
    {
        /// <summary>
        ///     Factory <see cref="AppMode"/> method.
        /// </summary>
        public static AppMode GetMode(this AppArgs args)
        {
            var mode = AppMode.None;

            if (args.HelpMode)
            {
                return AppMode.Help;
            }

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
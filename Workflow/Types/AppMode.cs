using System;

namespace AppKiller.Workflow.Types
{
    [Flags]
    internal enum AppMode
    {
        None = 0,

        /// <summary>
        ///     Requires a kill list, and no interactive flag.
        /// </summary>
        SilentKill = 1,

        /// <summary>
        ///     Default interactive mode with menu system.
        /// </summary>
        Interactive = 2,

        /// <summary>
        ///     Lists all running processes. Must be used with <see cref="Interactive"/> to view.
        /// </summary>
        List = 4
    }
}
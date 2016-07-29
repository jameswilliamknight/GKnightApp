using System;

namespace AppKill.Workflow.Types
{
    [Flags]
    internal enum AppMode
    {
        None = 0,

        Help = 1,

        /// <summary>
        ///     Requires a kill list, and no interactive flag.
        /// </summary>
        SilentKill = 2,

        /// <summary>
        ///     Default interactive mode with menu system.
        /// </summary>
        Interactive = 4,

        /// <summary>
        ///     Lists all running processes. Must be used with <see cref="Interactive"/> to view.
        /// </summary>
        List = 8
    }
}
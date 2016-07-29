using System;

namespace AppKill.Workflow.Types
{
    [Flags]
    internal enum AppMode
    {
        None = 0,

        /// <see cref="Workflow.Help"/>
        Help = 1,

        /// <summary>
        ///     Requires a kill list, and no interactive flag.
        /// </summary>
        /// <see cref="Workflow.SilentKill"/>
        SilentKill = 2,

        /// <summary>
        ///     Default interactive mode with menu system.
        /// </summary>
        /// <see cref="Workflow.Interactive"/>
        Interactive = 4,

        /// <summary>
        ///     Lists all running processes. Must be used with <see cref="Interactive"/> to view.
        /// </summary>
        /// <see cref="Workflow.Lister"/>
        List = 8
    }
}
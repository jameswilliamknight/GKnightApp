using System.Diagnostics;
using System.Linq;

namespace AppKiller.Windows
{
    public static class ProcessFilters
    {
        public static Process[] Filter(this IOrderedEnumerable<Process> currentProcesses, string[] killList)
        {
            return currentProcesses
                .Where(p => killList.Contains(p.ProcessName))
                .Where(p => !p.HasExited)
                .ToArray();
        }
    }
}
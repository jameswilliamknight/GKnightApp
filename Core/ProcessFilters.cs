using System.Diagnostics;
using System.Linq;

namespace AppKill.Core
{
    public static class ProcessFilters
    {
        public static Process[] Filter(this Process[] currentProcesses, string[] killList)
        {
            return currentProcesses
                .Where(p => killList.Contains(p.ProcessName))
                .Where(p => !p.HasExited)
                .ToArray();
        }
    }
}
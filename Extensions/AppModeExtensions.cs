using AppKill.Workflow.Types;

namespace AppKill.Extensions
{
    internal static class AppModeExtensions
    {
        public static bool HasFlag(this AppMode value, AppMode flag)
        {
            return (value & flag) != 0;
        }
    }
}
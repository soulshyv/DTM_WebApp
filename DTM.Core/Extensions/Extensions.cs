using System.Linq;
using System.Reflection;

namespace DTM.Core.Extensions
{
    public static class Extensions
    {
        public static bool IsAnyNullOrEmpty(this object o)
        {
            return o == null || o.GetType().GetProperties().Select(pi => pi.GetValue(o)).Any(value => value == null);
        }
    }
}
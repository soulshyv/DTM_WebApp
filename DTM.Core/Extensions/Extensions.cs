using System.Linq;
using System.Reflection;

namespace DTM.Core.Extensions
{
    public static class Extensions
    {
        public static bool IsAnyNullOrEmpty(this object o)
        {
            //Vérification objet null
            if (o == null)
                return true;

            //Vérification aucune propriété
            var props = o.GetType().GetProperties();
            if (!props.Any())
                return true;

            //Vérification Propriété(s) null
            foreach (var pi in props)
            {
                if (pi.GetValue(o) == null)
                    return true;
            }

            return false;
        }
    }
}
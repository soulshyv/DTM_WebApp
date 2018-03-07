using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

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

        public static string ToKebabCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return Regex.Replace(
                    text,
                    "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                    "-$1",
                    RegexOptions.Compiled)
                .Trim()
                .ToLower();
        }

        public static int ToUnixTimeStamp(this DateTime dateTime)
        {
            var baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);//from 1970/1/1 00:00:00 to now

            var result = dateTime.Subtract(baseDate);

            return Convert.ToInt32(result.TotalSeconds);
        }
    }
}
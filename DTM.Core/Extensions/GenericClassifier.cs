using System;
using System.Collections.Generic;

namespace DTM.Core.Extensions
{
    public static class GenericClassifier
    {
        public static bool IsICollection(Type type)
        {
            return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
        }

        public static bool IsIEnumerable(Type type)
        {
            return Array.Exists(type.GetInterfaces(), IsGenericEnumerableType);
        }

        public static bool IsISet(Type type)
        {
            return Array.Exists(type.GetInterfaces(), IsGenericSetType);
        }

        static bool IsGenericCollectionType(Type type)
        {
            return type.IsGenericType && (typeof(ICollection<>) == type.GetGenericTypeDefinition());
        }

        static bool IsGenericEnumerableType(Type type)
        {
            return type.IsGenericType && (typeof(IEnumerable<>) == type.GetGenericTypeDefinition());
        }

        static bool IsGenericSetType(Type type)
        {
            return type.IsGenericType && (typeof(ISet<>) == type.GetGenericTypeDefinition());
        }
    }
}

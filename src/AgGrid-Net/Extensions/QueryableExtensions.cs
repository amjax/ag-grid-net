using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AgGrid.Extensions
{
    internal static class QueryableExtensions
    {
        internal static IEnumerable Execute(this IQueryable source)
        {
            var type = source != null ? source.ElementType : throw new ArgumentNullException(nameof(source));
            var instance = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            foreach (object obj in source)
            {
                instance.Add(obj);
            }

            return instance;
        }
    }
}
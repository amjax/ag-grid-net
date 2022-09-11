using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgGrid.Extensions
{
    internal static class QueryableExtensions
    {
        internal static IEnumerable Execute(this IQueryable source, CancellationToken cancellationToken = default)
        {
            var type = source != null ? source.ElementType : throw new ArgumentNullException(nameof(source));
            var instance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            foreach (object obj in source)
            {
                instance.Add(obj);
            }
            return instance;
        }
    }
}
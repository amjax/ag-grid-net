using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace AgGrid.Extensions
{
    public static class QueryableExtensions
    {
        public static IEnumerable Execute<TModel, TResult>(this IQueryable source)
        {
            Type type = source is not null ? source.ElementType : throw new ArgumentNullException(nameof(source));

            var instance = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            foreach (object obj in source)
            {
                instance.Add(obj);
            }

            return instance;
        }


        public static IQueryable Sort<TModel>(this IQueryable queryable, IEnumerable<SortModel> sortModels)
        {
            bool firstOrder = true;
            foreach (var sortDescriptor in sortModels)
            {
                string methodName;
                if (firstOrder)
                {
                    methodName = sortDescriptor.SortDirection == ListSortDirection.Ascending
                        ? nameof(Enumerable.OrderBy)
                        : nameof(Enumerable.OrderByDescending);
                    firstOrder = false;
                }
                else
                {
                    methodName = sortDescriptor.SortDirection == ListSortDirection.Ascending
                        ? nameof(Enumerable.ThenBy)
                        : nameof(Enumerable.ThenByDescending);
                }


                var type = typeof(TModel);
                var property = type.GetProperty(sortDescriptor.ColId);
                var parameter = Expression.Parameter(type, "p");

                var propertyAccess = Expression.MakeMemberAccess(parameter, property!);
                var orderByLambdaExpression = Expression.Lambda(propertyAccess, parameter);

                var typeArguments = new[] {type, property.PropertyType};


                queryable = queryable.Provider.CreateQuery(Expression.Call(typeof(Queryable),
                                                                           methodName,
                                                                           typeArguments,
                                                                           queryable.Expression,
                                                                           Expression.Quote(orderByLambdaExpression)));
            }


            return queryable;
        }
    }
}
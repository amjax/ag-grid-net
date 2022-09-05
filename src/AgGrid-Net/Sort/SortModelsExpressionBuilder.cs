using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AgGrid.Extensions.ExpressionExtensions;

namespace AgGrid.Sort
{
    internal class SortModelsExpressionBuilder
    {
        private readonly IQueryable _queryable;
        private readonly IEnumerable<SortModel> _sortModels;


        public SortModelsExpressionBuilder(
        IQueryable queryable,
        IEnumerable<SortModel> sortModels)
        {
            _queryable = queryable;
            _sortModels = sortModels;
        }

        public IQueryable Sort()
        {
            var queryable = _queryable;
            var firstItem = true;
            foreach (var sortModel in _sortModels)
            {
                string methodName;
                if (firstItem)
                {
                    methodName = sortModel.SortDirection == ListSortDirection.Ascending
                        ? nameof(Enumerable.OrderBy)
                        : nameof(Enumerable.OrderByDescending);
                    firstItem = false;
                }
                else
                {
                    methodName = sortModel.SortDirection == ListSortDirection.Ascending
                        ? nameof(Enumerable.ThenBy)
                        : nameof(Enumerable.ThenByDescending);
                }


                LambdaExpression lambdaExpression =
                    new MemberAccessExpressionBuilder(_queryable.ElementType, sortModel.ColId)
                       .CreateLambdaExpression();

                var typeArguments = new Type[2]
                {
                    queryable.ElementType,
                    lambdaExpression.Body.Type
                };

                queryable = queryable.Provider.CreateQuery(Expression.Call(typeof(Queryable),
                                                                           methodName,
                                                                           typeArguments,
                                                                           queryable.Expression,
                                                                           Expression.Quote(lambdaExpression)));
            }

            return queryable;
        }
    }
}
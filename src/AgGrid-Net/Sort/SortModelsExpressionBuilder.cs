using AgGrid.Extensions.ExpressionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace AgGrid.Sort
{
    internal interface ISortModelsExpressionBuilder
    {
        IQueryable Sort();
    }
    internal interface ISortModelsExpressionBuilder<T> : ISortModelsExpressionBuilder
    {
        new IQueryable<T> Sort();
    }
    internal class SortModelsExpressionBuilder<T> : SortModelsExpressionBuilder, ISortModelsExpressionBuilder<T>, ISortModelsExpressionBuilder
    {
        public SortModelsExpressionBuilder(IQueryable<T> queryable, IEnumerable<SortModel> sortModels) : base(queryable, sortModels) { }
        IQueryable ISortModelsExpressionBuilder.Sort() => base.Sort();
        public new IQueryable<T> Sort() => (IQueryable<T>)((ISortModelsExpressionBuilder)this).Sort();

    }
    internal class SortModelsExpressionBuilder
    {
        protected readonly IQueryable _queryable;
        protected readonly IEnumerable<SortModel> _sortModels;
        public SortModelsExpressionBuilder(IQueryable queryable, IEnumerable<SortModel> sortModels)
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
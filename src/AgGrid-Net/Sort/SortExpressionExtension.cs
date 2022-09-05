using System.Collections.Generic;
using System.Linq;

namespace AgGrid.Sort
{
    public static class SortExpressionExtension
    {
        public static IQueryable Sort(
        this IQueryable source,
        IEnumerable<SortModel> sortModels)
        {
            return new SortModelsExpressionBuilder(source, sortModels).Sort();
        }
    }
}
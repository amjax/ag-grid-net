using System.Collections.Generic;
using System.Linq;
using AgGrid.Extensions;
using AgGrid.Sort;

namespace AgGrid.AgGridExtensions;

public static class AgGridExtensions
{
    public static AgGridResult ToAgGridResult(
    this IQueryable source,
    AgGridRequest request)
    {
        AgGridResult result = new AgGridResult();
        var query = source;

        query = query.AddSort(request.SortModel);

        result.Data = query.Execute();
        return result;
    }

    private static IQueryable AddSort(this IQueryable source, IList<SortModel> sortModels)
    {
        return sortModels.Any() ? source.Sort(sortModels) : source;
    }
}
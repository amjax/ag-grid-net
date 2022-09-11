using AgGrid.Extensions;
using AgGrid.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgGrid.AgGridExtensions;

public static class AgGridExtensions
{
    public static AgGridResult ToAgGridResult(this IQueryable source, AgGridRequest request)
    {
        AgGridResult result = new();
        var query = source;

        query = query.AddSort(request.SortModel);

        result.TotalCount = query!.Count();
        int count = request.EndRow == 0 && request.StartRow == 0
            ? 0
            : request.EndRow - request.StartRow + 1;
        query = query.SetOffsetAndCount(request.StartRow, request.EndRow - request.StartRow + 1);

        result.Data = query.Execute();
        return result;
    }
    private static int Count(this IQueryable source) => Queryable.Count((dynamic)source);
    private static IQueryable SetStratAndEndIndex(this IQueryable source, int start, int end)
    {
        if (start < 0)
            throw new ArgumentOutOfRangeException(nameof(start));
        if (end < start)
            throw new ArgumentOutOfRangeException(nameof(end));
        int count = end == 0 && start == 0
            ? 0
            : end - start + 1;
        return TakeSkip(source, start, count);
    }
    private static IQueryable SetOffsetAndCount(this IQueryable source, int offset, int count)
    {
        if (offset < 0)
            throw new ArgumentOutOfRangeException(nameof(offset));
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        return TakeSkip(source, offset, count);
    }
    private static IQueryable TakeSkip(IQueryable source, int offset, int count)
    {
        dynamic dynamicQuery = source;
        return Queryable.Take(Queryable.Skip(dynamicQuery, offset), count);
    }
    private static IQueryable AddSort(this IQueryable source, IList<SortModel> sortModels)
    {
        return sortModels.Any() ? source.Sort(sortModels) : source;
    }
    private static IQueryable<T> AddSort<T>(this IQueryable<T> source, IList<SortModel> sortModels)
    {
        return sortModels.Any() ? source.Sort(sortModels) : source;
    }
}
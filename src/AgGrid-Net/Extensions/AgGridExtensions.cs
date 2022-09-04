using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AtEase.Extensions;

namespace AgGrid.Extensions;

public static class AgGridExtensions
{
    public static AgGridRequest AddSort(this AgGridRequest request, string colId, ListSortDirection direction)
    {
        var sortModels = request.SortModel.IsNotNull() ? request.SortModel.ToList() : new List<SortModel>();

        sortModels.Add(new SortModel(colId, direction));
        request.SortModel = sortModels.ToArray();
        return request;
    }
}
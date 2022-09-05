using System;
using System.ComponentModel;
using System.Linq;
using AtEase.ValidationExtensions;

namespace AgGrid
{
    [Serializable]
    public class SortModel
    {
        private string _colId = null!;
        private string _sort = null!;

        private (ListSortDirection sortDirection, string sort)[] _sortRange =
            {(ListSortDirection.Ascending, "asc"), (ListSortDirection.Descending, "desc")};

        public SortModel()
        {
        }
        public SortModel(string colId)
        {
            ColId = colId;
            Sort = GetSort(ListSortDirection.Ascending);
        }

        public SortModel(string colId, string sort)
        {
            ColId = colId;
            Sort = sort;
        }

        public SortModel(string colId, ListSortDirection sort)
        {
            ColId = colId;
            Sort = GetSort(sort);
        }

        private string GetSort(ListSortDirection direction) =>
            _sortRange.Single(s => s.sortDirection == direction).sort;

        public ListSortDirection SortDirection => _sortRange.Single(s => s.sort == Sort).sortDirection;

        public string Sort
        {
            get => _sort;
            set
            {
                var sort = value?.ToLower();
                Assert.IsTrue(_sortRange.Select(a => a.sort).Contains(sort),
                              () => throw new ArgumentOutOfRangeException(nameof(Sort)));
                _sort = sort!;
            }
        }

        public string ColId
        {
            get => _colId;
            set => _colId = value;
        }
    }
}
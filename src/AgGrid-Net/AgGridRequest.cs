using System.Collections.Generic;

namespace AgGrid
{
    public class AgGridRequest
    {
        public IList<SortModel> SortModel { get; set; } = null!;
        public int StartRow { set; get; }
        public int EndRow { set; get; }
    }
}
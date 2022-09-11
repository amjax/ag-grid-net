using System.Collections;

namespace AgGrid
{
    public class AgGridResult
    {
        public IEnumerable Data { get; set; } = null!;
        public int TotalCount { set; get; }
    }
}
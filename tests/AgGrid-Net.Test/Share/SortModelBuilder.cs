namespace AgGrid.Test.Share
{
    public class SortModelBuilder
    {
        private readonly DefaultValues _defaultValues = new DefaultValues();

        public static SortModelBuilder CreateNew()
        {
            return new SortModelBuilder();
        }

        public SortModelBuilder SetColId(string colId)
        {
            _defaultValues.ColId = colId;
            return this;
        }

        public SortModelBuilder SetSort(string sort)
        {
            _defaultValues.Sort = sort;
            return this;
        }

        public SortModel Build()
        {
            return new SortModel(_defaultValues.ColId, _defaultValues.Sort);
        }

        private class DefaultValues : SortModel
        {
            public DefaultValues()
            {
                Sort = "asc";
                ColId = "col1";
            }
        }
    }
}
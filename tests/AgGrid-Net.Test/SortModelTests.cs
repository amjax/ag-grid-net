using AgGrid.Test.Share;

namespace AgGrid.Test
{
    public class SortModelTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("xyz")]
        public void SetSort_InvalidValues_ThrowException(string sort)
        {
            Action act = () => SortModelBuilder.CreateNew().SetSort(sort).Build();
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("asc", ListSortDirection.Ascending)]
        [InlineData("desc", ListSortDirection.Descending)]
        public void SetSort_SetSortDirection(string sort, ListSortDirection expectedSortDirection)
        {
            SortModel sortModel = SortModelBuilder.CreateNew().SetSort(sort).Build();
            sortModel.SortDirection.Should().Be(expectedSortDirection);
        }
        [Theory]
        [InlineData( ListSortDirection.Ascending, "asc")]
        [InlineData( ListSortDirection.Descending, "desc")]
        public void SetSort_SetSort( ListSortDirection sortDirection, string expectedSort)
        {
            SortModel sortModel = new SortModel("colId", sortDirection);
            sortModel.Sort.Should().Be(expectedSort);
        }

        [Fact]
        public void Create_ValidValues_CreateSortModel()
        {
            SortModelBuilder.CreateNew().Build();
        }
    }
}
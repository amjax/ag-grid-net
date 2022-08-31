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


        [Fact]
        public void Create_ValidValues_CreateSortModel()
        {
            SortModelBuilder.CreateNew().Build();
        }
    }
}
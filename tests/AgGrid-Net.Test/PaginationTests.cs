using AgGrid.Test.Share.TestModel;
using AgGrid.AgGridExtensions;
using FluentAssertions.Equivalency;
using FluentAssertions.Collections;

namespace AgGrid.Test;

public class PaginationTests
{
    [Fact]
    public void ToAgGridResult_should_paginate_result()
    {
        // arrange
        IQueryable<TestModel> models = new List<TestModel>
        {
            new(0, "A"),
            new(1, "B"),
            new(2, "C"),
            new(3, "D"),
            new(4, "E"),
            new(5, "F"),
            new(6, "G"),
            new(7, "H"),
            new(8, "I"),
            new(9, "J"),
        }.AsQueryable();
        int startRow = 0, endRow = 2;

        // act
        AgGridResult agGridResult = models.ToAgGridResult(new() { StartRow = startRow, EndRow = endRow, SortModel = new List<SortModel> { new("id", ListSortDirection.Ascending) } });

        // assert
        agGridResult.Data.Should().BeEquivalentTo(models.OrderBy(m => m.Id).Take(endRow - startRow + 1));
    }
}

using AgGrid.AgGridExtensions;
using AgGrid.Test.Share;
using AgGrid.Test.Share.TestModel;

namespace AgGrid.Test
{
    public class SortExtensionTests
    {
        [Fact]
        public void Sort_ValidData_Sort()
        {
            IQueryable<TestModel> models = new List<TestModel>
            {
                new(2, "2"),
                new(1, "1")
            }.AsQueryable();


            SortModel sortModel = SortModelBuilder.CreateNew()
                                                  .SetColId(nameof(TestModel.Id))
                                                  .SetSort("asc")
                                                  .Build();

            AgGridRequest request = new AgGridRequest
            {
                SortModel = new List<SortModel>
                    {sortModel}
            };


            AgGridResult result = models.ToAgGridResult(request);


            result.Data.Should()
                  .BeEquivalentTo(new List<TestModel>
                                  {
                                      new(1, "1"),
                                      new(2, "2")
                                  },
                                  options => options.WithStrictOrdering());
        }

        [Fact]
        public void Sort_ValidData_2_Sort()
        {
            IQueryable<TestModel> models = new List<TestModel>
            {
                new(2, "B"),
                new(2, "A"),
                new(1, "B"),
                new(1, "A")
            }.AsQueryable();


            SortModel sortModelId = SortModelBuilder.CreateNew()
                                                    .SetColId(nameof(TestModel.Id))
                                                    .SetSort("asc")
                                                    .Build();

            SortModel sortModelName = SortModelBuilder.CreateNew()
                                                      .SetColId(nameof(TestModel.Name))
                                                      .SetSort("asc")
                                                      .Build();


            AgGridRequest request = new AgGridRequest
            {
                SortModel = new List<SortModel>
                    {sortModelId, sortModelName}
            };


            AgGridResult result = models.ToAgGridResult(request);


            result.Data.Should()
                  .BeEquivalentTo(new List<TestModel>
                                  {
                                      new(1, "A"),
                                      new(1, "B"),
                                      new(2, "A"),
                                      new(2, "B")
                                  },
                                  options => options.WithStrictOrdering());
        }

        [Fact]
        public void Sort_ValidData_2_Sort_desc()
        {
            IQueryable<TestModel> models = new List<TestModel>
            {
                new(2, "B"),
                new(2, "A"),
                new(1, "B"),
                new(1, "A")
            }.AsQueryable();


            SortModel sortModelId = SortModelBuilder.CreateNew()
                                                    .SetColId(nameof(TestModel.Id))
                                                    .SetSort("asc")
                                                    .Build();

            SortModel sortModelName = SortModelBuilder.CreateNew()
                                                      .SetColId(nameof(TestModel.Name))
                                                      .SetSort("desc")
                                                      .Build();


            AgGridRequest request = new AgGridRequest
            {
                SortModel = new List<SortModel>
                    {sortModelId, sortModelName}
            };


            AgGridResult result = models.ToAgGridResult(request);


            result.Data.Should()
                  .BeEquivalentTo(new List<TestModel>
                                  {
                                      new(1, "B"),
                                      new(1, "A"),
                                      new(2, "B"),
                                      new(2, "A"),
                                  },
                                  options => options.WithStrictOrdering());
        }

    }
}
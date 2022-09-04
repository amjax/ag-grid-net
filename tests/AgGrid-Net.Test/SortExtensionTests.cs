using AgGrid.Extensions;
using AgGrid.Test.Share;

namespace AgGrid.Test
{
    public class SortExtensionTests
    {
        [Fact]
        public void Sort_ValidData_Sort()
        {
            IQueryable<TestModel.TestModel> models = new List<TestModel.TestModel>
                {new(2, "2"), new TestModel.TestModel(1, "1")}.AsQueryable();

            SortModel sortModel = SortModelBuilder.CreateNew()
                                                  .SetColId(nameof(TestModel.TestModel.Id))
                                                  .SetSort("asc")
                                                  .Build();


            IQueryable sortedResult = models.Sort<TestModel.TestModel>(new[] {sortModel});

            sortedResult.Execute<TestModel.TestModel, List<TestModel.TestModel>>()
                        .Should()
                        .BeEquivalentTo(new List<TestModel.TestModel> {new(2, "2"), new(1, "1")});
        }
    }
}
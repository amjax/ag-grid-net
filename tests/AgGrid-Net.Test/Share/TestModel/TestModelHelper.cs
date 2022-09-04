namespace AgGrid.Test.TestModel
{
    public static class TestModelHelper
    {
        public static IEnumerable<TestModel> GetTestModels(int count = 10)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new TestModel
                { Id = i, Name = $"a{i}" };
            }
        }
    }
}
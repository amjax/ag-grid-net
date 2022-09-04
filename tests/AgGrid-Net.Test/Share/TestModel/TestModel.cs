namespace AgGrid.Test.TestModel
{
    public class TestModel
    {
        public TestModel()
        {
        }

        public TestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
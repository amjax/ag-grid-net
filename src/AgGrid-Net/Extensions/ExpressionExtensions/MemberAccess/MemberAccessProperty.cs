namespace AgGrid.Extensions.ExpressionExtensions.MemberAccess
{
    internal class MemberAccessProperty : IMemberAccess
    {
        public MemberAccessProperty(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}
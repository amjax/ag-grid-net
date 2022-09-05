using System;
using System.Linq.Expressions;
using AgGrid.Extensions.ExpressionExtensions.MemberAccess;
using AtEase.Extensions;

namespace AgGrid.Extensions.ExpressionExtensions
{
    internal class MemberAccessExpressionBuilder
    {
        private ParameterExpression? _parameterExpression;

        public MemberAccessExpressionBuilder(Type expressionParaPeterType, string memberName)
        {
            ExpressionParaPeterType = expressionParaPeterType;
            MemberName = memberName;
        }

        public string MemberName { get; }

        protected internal Type ExpressionParaPeterType { get; }

        public ParameterExpression? ParameterExpression
        {
            get
            {
                if (_parameterExpression.IsNull())
                {
                    _parameterExpression = Expression.Parameter(ExpressionParaPeterType, "p");
                }

                return _parameterExpression;
            }
            set => _parameterExpression = value;
        }


        public LambdaExpression CreateLambdaExpression()
        {
            var memberAccessExpression = new MemberAccessProperty(MemberName).MakeMemberAccessExpression(ParameterExpression);

            return Expression.Lambda(memberAccessExpression!, ParameterExpression);
        }
    }
}
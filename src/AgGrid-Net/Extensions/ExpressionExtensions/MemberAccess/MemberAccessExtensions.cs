using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AgGrid.Extensions.ExpressionExtensions.MemberAccess
{
    internal static class MakeMemberAccessExpressionExtensions
    {
        public static Expression? MakeMemberAccessExpression(
        this IMemberAccess? memberAccess,
        Expression? instance)
        {
            Type targetType = instance!.Type;
            string memberName = ((MemberAccessProperty)memberAccess!).PropertyName;

            MemberInfo? memberInfoForType = targetType.GetMemberInfoByName(memberName);

            return Expression.MakeMemberAccess(instance, memberInfoForType!);
        }
    }
}
using System;
using System.Linq;
using System.Reflection;

namespace AgGrid.Extensions
{
    public static class TypeExtensions
    {
        internal static MemberInfo? GetMemberInfoByName(
        this Type type,
        string memberName)
        {
            MemberInfo? memberInfo = type.GetProperties().OfType<MemberInfo>()
                                         .SingleOrDefault((Func<MemberInfo, bool>) (m =>
                                                              m.Name.Equals(
                                                              memberName,
                                                              StringComparison.OrdinalIgnoreCase)));

            return memberInfo;
        }
    }
}
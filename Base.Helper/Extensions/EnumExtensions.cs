using System;
using System.ComponentModel;
using System.Linq;

namespace Base.Helpers.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum input)
        {
            var genericEnumType = input.GetType();
            var memberInfo = genericEnumType.GetMember(input.ToString());
            if (memberInfo.Length <= 0) return input.ToString();

            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Any() ? ((DescriptionAttribute)attributes.ElementAt(0)).Description : input.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Battleships.Core.Helpers
{
    public static class EnumHelper
    {
        public static string GetFieldDescription(FieldDesignation designation)
        {
            var enumType = typeof(FieldDesignation);
            var memberInfos = enumType.GetMember(designation.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)valueAttributes[0]).Description;
            return description;
        }
    }
}

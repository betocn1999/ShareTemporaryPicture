using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ShareTemporaryPicture.Models.Enums
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value) => value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
    }
}

using System;
using System.Reflection;

namespace MyZip
{
    public static class FieldInfoExtension
    {
        public static bool HasAttribute<T>(this FieldInfo field) where T : Attribute
        {
            return HasAttribute(field, typeof(T));
        }

        public static bool HasAttribute(this FieldInfo field, Type attributeType)
        {
            return field.GetCustomAttributes(attributeType, false).Length > 0;
        }
    }
}

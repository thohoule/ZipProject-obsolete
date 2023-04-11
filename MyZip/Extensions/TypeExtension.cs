using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyZip
{
    public static class TypeExtension
    {
        public static IEnumerable<FieldInfo> GetAllFields(this Type type, Type peak, BindingFlags flags)
        {
            if (type == null || type == peak)
                return Enumerable.Empty<FieldInfo>();

            //return type.GetMembers(flags).Concat(GetAllMembers(type.BaseType, peak, flags));
            return type.GetFields(flags).Concat(GetAllFields(type.BaseType, peak, flags));
        }

        public static IEnumerable<MemberInfo> GetAllMembers(this Type type, Type peak, BindingFlags flags)
        {
            if (type == null || type == peak)
                return Enumerable.Empty<MemberInfo>();

            return type.GetMembers(flags).Concat(GetAllMembers(type.BaseType, peak, flags));
            //return type.GetFields(flags).Concat(GetAllMembers(type.BaseType, peak, flags));
        }

        public static bool HasParameterlessConstructor(this Type type)
        {
            return type.GetConstructor(Type.EmptyTypes) != null;
        }

        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return HasAttribute(type, typeof(T));
        }

        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetCustomAttributes(attributeType, false).Length > 0;
        }
    }
}

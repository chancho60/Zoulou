using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Zoulou.Helpers {
    public static class EnumHelper<T> {
        public static IList<T> GetValues(Enum Value) {
            var EnumValues = new List<T>();

            foreach(var FieldInfo in Value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public)) {
                EnumValues.Add((T)Enum.Parse(Value.GetType(), FieldInfo.Name, false));
            }
            return EnumValues;
        }

        public static T Parse(string Value) {
            return (T)Enum.Parse(typeof(T), Value, true);
        }

        public static IList<string> GetNames(Enum Value) {
            return Value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum Value) {
            return GetNames(Value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string LookupResource(Type ResourceManagerProvider, string ResourceKey) {
            foreach(var Property in ResourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)) {
                if(Property.PropertyType == typeof(System.Resources.ResourceManager)) {
                    var ResourceManager = (System.Resources.ResourceManager)Property.GetValue(null, null);
                    return ResourceManager.GetString(ResourceKey);
                }
            }

            return ResourceKey;
        }

        public static string GetDisplayValue(T Value) {
            var FieldInfo = Value.GetType().GetField(Value.ToString());
            var DescriptionAttributes = FieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if(DescriptionAttributes == null) {
                return string.Empty;
            }

            if(DescriptionAttributes[0].ResourceType != null) {
                return LookupResource(DescriptionAttributes[0].ResourceType, DescriptionAttributes[0].Name);
            }

            return (DescriptionAttributes.Length > 0) ? DescriptionAttributes[0].Name : Value.ToString();
        }
    }
}
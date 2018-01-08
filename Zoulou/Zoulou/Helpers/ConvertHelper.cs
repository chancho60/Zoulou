using System;

namespace Zoulou.Helpers {
    public static class ConvertHelper {
        public static bool IsOfTypeCode(object Object, TypeCode TypeCode) {
            bool result;

            try {
                Convert.ChangeType(Object, TypeCode);
                result = true;
            } catch {
                result = false;
            }

            return result;
        }
    }
}
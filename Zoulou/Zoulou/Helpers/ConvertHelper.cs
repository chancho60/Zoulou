using System;

namespace Zoulou.Helpers {
    public static class ConvertHelper {
        public static bool IsOfTypeCode(object Object, TypeCode TypeCode) {
            try {
                Convert.ChangeType(Object, TypeCode);
                return true;
            } catch {
                return false;
            }

        }
    }
}
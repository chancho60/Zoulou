using System;
using System.Xml.Linq;

namespace Zoulou.GData.Impl {
    public static class Utils {
        public static string UrlEncode(string s) {
            return Uri.EscapeDataString(s).Replace("%20", "+");
        }
    }
}
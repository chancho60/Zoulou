using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading;

namespace Zoulou.Models {
    public class Base {
        public static IEnumerable<KeyValuePair<string, string>> GetItemsFromResource(string prefix, ResourceManager resourceManager) {
            var resourceSet = resourceManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, false, true);

            return from entry in resourceSet.Cast<DictionaryEntry>()
                   where entry.Key.ToString().StartsWith(prefix)
                   select new KeyValuePair<string, string>(
                       entry.Key.ToString().Substring(prefix.Length), entry.Value.ToString()
                   );
        }
    }
}
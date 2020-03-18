using System;
using System.Collections.Generic;
using System.Linq;

namespace LightspeedNET.Extentions
{
    public static class DictionaryExtentions
    {
        public static string ToJSON(this Dictionary<string, string> dictionary)
        {
                var entries = dictionary.Select(d =>
                    string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
                return "{" + string.Join(",", entries) + "}";
        }
    }
}

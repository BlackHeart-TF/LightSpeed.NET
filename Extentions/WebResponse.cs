using System;
using System.IO;
using System.Net;

namespace LightspeedNET.Extentions
{
    public static class WebResponseExtentions
    {
        public static string getResponseText(this WebResponse webResponse)
        {
            var stream = webResponse.GetResponseStream();
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            return content;
        }
    }
}

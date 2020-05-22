using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LightspeedNET
{
    class Requests
    {
        private static Bucket Bucket { get; set; }
        private static HttpClient http = new HttpClient();

        public static void setup(RequestContext context)
        {
            if (DateTime.Compare(context.ExpiresOn, DateTime.Now) < 0)
            {
                throw new ExpiredTokenException();
            }
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);
            http.DefaultRequestHeaders.Add("Accept", "application/xml");
        }
        public static string Get(RequestContext context, string url)
        { 
            try{
            setup(context);
        HttpResponseMessage response = Task.Run(async () => await http.GetAsync(url)).Result;
            return ParseResponse(response).Result;
            }
            catch (Exception e)
            {
                return "http error";
            }
        }

        public static string Post(RequestContext context, string url, string content)
        {
            setup(context);
            HttpContent cont = new StringContent(content, Encoding.UTF8, "application/xml");
            HttpResponseMessage response = Task.Run(async () => await http.PostAsync(url, cont)).Result;
            return ParseResponse(response).Result;
        }

        public static string Delete(RequestContext context, string url)
        {
            setup(context);
            HttpResponseMessage response = Task.Run(async () => await http.DeleteAsync(url)).Result;
            return ParseResponse(response).Result;
        }

        public static string Put(RequestContext context, string url,string content)
        {
            setup(context);
            HttpContent cont = new StringContent(content, Encoding.UTF8, "application/xml");
            HttpResponseMessage response = Task.Run(async () => await http.PutAsync(url,cont)).Result;
            return ParseResponse(response).Result;
        }
        private static async Task<string> ParseResponse(HttpResponseMessage response)
        {
            
            var content = await response.Content.ReadAsStringAsync();
            if (response.Headers.Contains("X-LS-API-Bucket-Level"))
            {
                var key = response.Headers.Where(x => x.Key == "x-ls-api-bucket-level" || x.Key == "X-LS-API-Bucket-Level").ToArray();
                var bucketlevel = key[0].Value.First();
                Bucket = new Bucket(bucketlevel);
            }
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    var doc = new XmlDocument();
                    doc.LoadXml(content);
                    var Message = doc.SelectNodes("/Error/message")[0].InnerText;
                    throw new AuthException(Message);
                //break;

                case HttpStatusCode.OK:
                default:

                    break;
            }
            return content;
        }

    }

    public class RequestContext
    {
        public string AccessToken;
        public string RefreshToken;
        public DateTime ExpiresOn;
    }
}

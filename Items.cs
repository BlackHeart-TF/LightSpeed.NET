using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LightspeedNET.Models.Common;
using Xamarin.Auth;

namespace LightspeedNET
{
    public static class Items
    {
        

        public static Item GetItem(string SKU)
        {
            var acc = Lightspeed.AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(Lightspeed.AuthenticationClient.Authenticator, "GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{Lightspeed.Session.SystemCustomerID}/Item?systemSku={SKU}&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]")
   , null, ref acc);
            Lightspeed.AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            var elem = doc.DocumentElement.FirstChild.OuterXml;
            TextReader TextReader = new StringReader(elem);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Item));
            var Item = (Item)Deserializer.Deserialize(TextReader);
            return Item;
        }

        public static void UpdateItem(Item item)
        {
            //var json = changes.ToJSON();
            byte[] data;
            using (var ms = new MemoryStream())
            using (var x = new XmlTextWriter(ms, Encoding.ASCII))
            {
                var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Item));
                Deserializer.Serialize(x, item);
                data = ms.ToArray();
            }

            using (var client = new System.Net.WebClient())
            {
                client.Headers.Add("Authorization", OAuth2Request.GetAuthorizationHeader(Lightspeed.AuthenticationClient.Account));
                client.UploadData($"https://api.lightspeedapp.com/API/Account/{Lightspeed.Session.SystemCustomerID}/Item/{item.ItemID}", "PUT", data);
            }
        }

        public static Item SearchItem(string Query)
        {
            var acc = Lightspeed.AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(Lightspeed.AuthenticationClient.Authenticator, "GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{Lightspeed.Session.SystemCustomerID}/Item/?description=~,%{Query}%&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]")
   , null, ref acc);
            Lightspeed.AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            var elem = doc.DocumentElement.FirstChild.OuterXml;
            TextReader TextReader = new StringReader(elem);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Item));
            var Item = (Item)Deserializer.Deserialize(TextReader);
            return Item;
        }
    }

   
}

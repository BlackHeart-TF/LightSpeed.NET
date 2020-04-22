using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;
using LightspeedNET.Models.Common;

namespace LightspeedNET
{
    public static class Items
    {
        public static Item GetItem(string SKU)
        {
            var response = Lightspeed.AuthenticationClient.Request(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Item?systemSku={SKU}&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            //check if an item was actually returned
            var node = doc.SelectSingleNode("Items");
            if (int.Parse(node.Attributes["count"].Value) <= 0)
                return null;
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
                client.Headers.Add("Authorization", Lightspeed.AuthenticationClient.getAuthorizationHeader());
                client.UploadData($"https://api.lightspeedapp.com/API/Account/{Lightspeed.Session.SystemCustomerID}/Item/{item.ItemID}", "PUT", data);
            }
        }

        public static Item SearchItem(string Query)
        {
            var response = Lightspeed.AuthenticationClient.Request(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Item/?description=~,%{Query}%&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            //check if an item was actually returned
            var node = doc.SelectSingleNode("Items");
            if (int.Parse(node.Attributes["count"].Value) <= 0)
                return null;

            var elem = doc.DocumentElement.FirstChild.OuterXml;
            TextReader TextReader = new StringReader(elem);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Item));
            var Item = (Item)Deserializer.Deserialize(TextReader);
            return Item;
        }
    }
}

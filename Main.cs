using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LightspeedNET.Models;
using LightspeedNET.Extentions;

namespace LightspeedNET
{
    public class Lightspeed
    {
        public static LSAuthenticator AuthenticationClient { get; set; }
        public static Session Session { get; private set; }

        internal const string host = "https://us.merchantos.com";
        //public Lightspeed(string clientID, string clientSecret)
        //{
        //    var auth = new LSAuthenticator(clientID, clientSecret);
        //    AuthenticationClient = auth;
        //    AuthenticationClient.OnAuthComplete += GetLightspeedSession;

        //}
        public Lightspeed(string clientID, string clientSecret)
        {

            AuthenticationClient = new LSAuthenticator(clientID, clientSecret);
            AuthenticationClient.OnAuthComplete += delegate { GetLightspeedSession(); };
        }

        public Session GetLightspeedSession()
        {
            var response = AuthenticationClient.GetRequest(host+"/API/Session");

            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Session));
            return Session = ((Session)Deserializer.Deserialize(TextReader));

        }
        public Employee GetEmployee(int id)
        {
            var response = AuthenticationClient.GetRequest(host + $"/API/Account/{Session.SystemCustomerID}/Employee/{id}");

            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Employee));
            return ((Employee)Deserializer.Deserialize(TextReader));

        }

        public Order[] GetOrders()
        {
            var response = AuthenticationClient.GetRequest(host + $"/API/Account/{Session.SystemCustomerID}/Order");
            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Orders));
            var Orders = (Orders)Deserializer.Deserialize(TextReader);
            return Orders.Order;
        }


        public int GetCFChoiceID(int customFieldID, string ChoiceName)
        {
            var response = AuthenticationClient.GetRequest(host + $"/API/Account/196557/Item/CustomField/{customFieldID}/CustomFieldChoice");
            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(CustomFieldChoices));
            var CFVs = (CustomFieldChoices)Deserializer.Deserialize(TextReader);
            var ss = CFVs.CustomFieldChoice.Where(x => x.Name == ChoiceName);
            var id = 0;
            if (ss.Count() > 0)
            {
                id = ss.First().CustomFieldChoiceID;
                return id;
            }

            return 0;
        }

        public CustomFieldValue[] GetCustomFields()
        {
            var response = AuthenticationClient.GetRequest(host + $"/API/Account/196557/Item/CustomField/");
            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(CustomFields));
            var CFVs = (CustomFields)Deserializer.Deserialize(TextReader);

            return CFVs.CustomField ;
        }
    }
}
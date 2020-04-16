using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LightspeedNET.Models.Common;
using Xamarin.Auth;
using LightspeedNET.Extentions;
using LightspeedNET.Models;

namespace LightspeedNET
{
    public class Lightspeed
    {
        public static LSAuthenticator AuthenticationClient { get; set; }
        public static Session Session { get; private set; }
        public static Account AuthToken { get; set; }
        public Lightspeed(string clientID, string clientSecret)
        {
            var auth = new LSAuthenticator(clientID, clientSecret);
            AuthenticationClient = auth;
            AuthenticationClient.OnAuthComplete += GetLightspeedSession;

        }
        public Lightspeed(string clientID, string clientSecret, Account account = null)
        {

            var auth = new LSAuthenticator(clientID, clientSecret, account);
            auth.OnAuthComplete += GetLightspeedSession;
            AuthenticationClient = auth;
            //AuthenticationClient.OnAuthComplete += GetLightspeedAccount;
            GetLightspeedSession();


        }
        public void GetLightspeedSession()
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
                                                new Uri("https://cloud.lightspeedapp.com/API/Session")
                                                , null, ref acc);
            AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new ExpiredTokenException();
            }
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Session));
            Session = ((Session)Deserializer.Deserialize(TextReader));

        }
        public Employee GetEmployee()
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
                                                new Uri($"https://cloud.lightspeedapp.com/API/Account/{Session.SystemCustomerID}/Employee?load_relations=[\"Contact\"]&Contact.email=craig@bgpowersports.com")
                                                , null, ref acc);
            AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new ExpiredTokenException();
            }
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Employee));
            return ((Employee)Deserializer.Deserialize(TextReader));

        }

        public void UpdateAccount(Account account)
        {
            AuthenticationClient.Account = account;
        }

        public Order[] GetOrders()
        {
            var request = new OAuth2Request("GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{Session.SystemCustomerID}/Order")
   , null, AuthenticationClient.Account);
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Orders));
            var Orders = (Orders)Deserializer.Deserialize(TextReader);
            return Orders.Order;
        }


        public int GetCFChoiceID(int customFieldID, string ChoiceName)
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
   new Uri($"https://api.lightspeedapp.com/API/Account/196557/Item/CustomField/{customFieldID}/CustomFieldChoice")
   , null, ref acc);
            AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
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
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
   new Uri($"https://api.lightspeedapp.com/API/Account/196557/Item/CustomField/")
   , null, ref acc);
            AuthenticationClient.Account = acc;
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(CustomFields));
            var CFVs = (CustomFields)Deserializer.Deserialize(TextReader);

            return CFVs.CustomField ;
        }
    }
}
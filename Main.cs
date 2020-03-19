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

namespace LightspeedNET
{
    public class Lightspeed
    {
        public LSAuthenticator AuthenticationClient { get; set; }
        public lsAccount lsAccount { get; private set; }

        public Lightspeed(string clientID, string clientSecret)
        {
            var auth = new LSAuthenticator(clientID, clientSecret);
            AuthenticationClient = auth;
            AuthenticationClient.OnAuthComplete += GetLightspeedAccount;

        }
        public Lightspeed(string clientID, string clientSecret, Account account = null)
        {

            var auth = new LSAuthenticator(clientID, clientSecret, account);
            auth.OnAuthComplete += GetLightspeedAccount;
            AuthenticationClient = auth;
            //AuthenticationClient.OnAuthComplete += GetLightspeedAccount;
            GetLightspeedAccount();


        }
        public void GetLightspeedAccount()
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
                                                new Uri("https://cloud.lightspeedapp.com/API/Account")
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
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(lsAccounts));
            this.lsAccount = ((lsAccounts)Deserializer.Deserialize(TextReader)).Account[0];

        }


        public void UpdateAccount(Account account)
        {
            AuthenticationClient.Account = account;
        }

        public Order[] GetOrders()
        {
            var request = new OAuth2Request("GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{lsAccount.AccountID}/Order")
   , null, AuthenticationClient.Account);
            var task = Task.Run(async () => await request.GetResponseAsync());
            var response = task.Result;
            var content = response.GetResponseText();
            TextReader TextReader = new StringReader(content);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Orders));
            var Orders = (Orders)Deserializer.Deserialize(TextReader);
            return Orders.Order;
        }

        public Item GetItem(string SKU)
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{lsAccount.AccountID}/Item?systemSku={SKU}&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]")
   , null, ref acc);
            AuthenticationClient.Account = acc;
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

        public Item SearchItem(string Query)
        {
            var acc = AuthenticationClient.Account;
            var request = new OAuth2RefreshRequest(AuthenticationClient.Authenticator, "GET",
   new Uri($"https://cloud.lightspeedapp.com/API/Account/{lsAccount.AccountID}/Item/?description=~,%{Query}%&load_relations=[\"CustomFieldValues\",\"CustomFieldValues.value\",\"Images\"]")
   , null, ref acc);
            AuthenticationClient.Account = acc;
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

        public void UpdateItem(Item item)
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
                client.Headers.Add("Authorization", OAuth2Request.GetAuthorizationHeader(AuthenticationClient.Account));
                client.UploadData($"https://api.lightspeedapp.com/API/Account/{lsAccount.AccountID}/Item/{item.ItemID}", "PUT", data);
            }
        }

        public KeyValuePair<string, int>? GetCFChoiceID(int customFieldID, string ChoiceName)
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
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(CustomFieldValues));
            var CFVs = (CustomFieldValues)Deserializer.Deserialize(TextReader);
            var ss = CFVs.CustomFieldChoices.Where(x => x.Name == ChoiceName);
            var id = 0;
            if (ss.Count() > 0)
            {
                id = ss.First().CustomFieldChoiceID;
                return new KeyValuePair<string, int>(ChoiceName, id);
            }

            return null;
        }
    }
}
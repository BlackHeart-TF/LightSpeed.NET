using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using LightspeedNET.Extentions;
using Newtonsoft.Json;

namespace LightspeedNET
{
    public class LSAuthenticator
    {
        private string _clientID;
        private string _clientSecret;
        public string _AccessToken;
        public string _RefreshToken;
        private DateTime _ExpiresOn;
        private RequestContext Context;

        public delegate void AuthComplete();
        public event AuthComplete OnAuthComplete;
        public delegate void AuthRefresh();
        public event AuthRefresh OnRefresh;
        public delegate void AuthFailed();
        public event AuthFailed OnAuthFailed;

        private static readonly HttpClient client = new HttpClient();

        public LSAuthenticator(string clientID, string clientSecret)
        {
            _clientID = clientID;
            _clientSecret = clientSecret;
        }

        public void Login(string email, string password, string refresh = "")
        {
            if (refresh != "")//the security holes are so real
                _RefreshToken = refresh;
            if (password == "pin")
            {
                Refresh();
                email = _AccessToken + ':' + email;
            }
            var Headers = new Dictionary<string, string>();
            Headers.Add("client_id", _clientID);
            Headers.Add("client_secret", _clientSecret);
            Headers.Add("grant_type", "password");
            Headers.Add("response_type", "code");
            Headers.Add("username", email);
            Headers.Add("password", password);
            Headers.Add("Accept", "application/json");
            var EncHeaders = new FormUrlEncodedContent(Headers);
            var response = Task.Run(async () => await client.PostAsync(Lightspeed.host + "/oauth/access_token_v2.php", EncHeaders)).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    if (OnAuthFailed != null)
                        OnAuthFailed();
                    else
                        throw new AuthException("unauthorized");
                    break;

                case HttpStatusCode.BadRequest:
                    if (OnAuthFailed != null)
                        OnAuthFailed();
                    else
                        throw new AuthException("bad request");
                    break;

                case HttpStatusCode.OK:
                    OnAuthFailed += delegate { Refresh(); };
                    var content = Task.Run(async () => await response.Content.ReadAsStringAsync()).Result;
                    var Authy = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    Context = new RequestContext();
                    Context.AccessToken = _AccessToken = Authy["access_token"];
                    Context.RefreshToken = _RefreshToken = Authy["refresh_token"];
                    Context.ExpiresOn = _ExpiresOn = DateTime.Now.AddSeconds(double.Parse(Authy["expires_in"]));
                    if (OnAuthComplete != null)
                        OnAuthComplete();
                    break;
                default:

                    break;
            }
            
        }

        public string GetRequest(string url)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var content = Requests.Get(Context, url);
                    return content;
                }
                catch (Exception)
                {
                    Refresh();
                }
            }
            return "Error";
        }
        public string DeleteRequest(string url)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var content = Requests.Delete(Context, url);
                    return content;
                }
                catch (Exception)
                {
                    Refresh();
                }
            }
            return "Error";
        }
        public string PutRequest(string url, string content)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var response = Requests.Put(Context, url, content);
                    return response;
                }
                catch (Exception)
                {
                    Refresh();
                }
            }
            return "Error";
        }
        public string PostRequest(string url, string content)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var response = Requests.Post(Context, url, content);
                    return response;
                }
                catch (Exception)
                {
                    Refresh();
                }
            }
            return "Error";
        }

        private void Refresh()
        {
            var Headers = new Dictionary<string, string>();
            Headers.Add("client_id", _clientID);
            Headers.Add("client_secret", _clientSecret);
            Headers.Add("grant_type", "refresh_token");
            Headers.Add("Accept", "application/json");
            Headers.Add("refresh_token", _RefreshToken);
            var EncHeaders = new FormUrlEncodedContent(Headers);
            var response = Task.Run(async () => await client.PostAsync(Lightspeed.host + "/oauth/access_token.php", EncHeaders)).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    if (OnAuthFailed != null)
                        OnAuthFailed();
                    break;

                case HttpStatusCode.OK:
                    var content = Task.Run(async () => await response.Content.ReadAsStringAsync()).Result;
                    var Authy = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    _AccessToken = Authy["access_token"];
                    _ExpiresOn = DateTime.Now.AddSeconds(double.Parse(Authy["expires_in"]));
                    if (OnRefresh != null)
                        OnRefresh();
                    break;
                default:

                    break;
            }
        }

        public string getAuthorizationHeader()
        {
            return "Bearer " + _AccessToken;
        }
    }

    public class AuthException : Exception {

        public AuthException(string message) : base(message)
        {
        }

    }
}

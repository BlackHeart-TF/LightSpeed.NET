using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        public delegate void AuthComplete();
        public event AuthComplete OnAuthComplete;
        public delegate void AuthFailed();
        public event AuthFailed OnAuthFailed;

        private static readonly HttpClient client = new HttpClient();

        public LSAuthenticator(string clientID, string clientSecret)
        {
            _clientID = clientID;
            _clientSecret = clientSecret;
            OnAuthFailed += delegate { Refresh(); };
        }

        public void Login(string email, string password, string refresh = "")
        {
            if (refresh != "")//the security holes are so real
                _RefreshToken = refresh;
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
                        throw new BadAuthenticationRequestException();
                    break;

                case HttpStatusCode.OK:
                    var content = Task.Run(async () => await response.Content.ReadAsStringAsync()).Result;
                    var Authy = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    _AccessToken = Authy["access_token"];
                    _RefreshToken = Authy["refresh_token"];
                    _ExpiresOn = DateTime.Now.AddSeconds(double.Parse(Authy["expires_in"]));
                    if (OnAuthComplete != null)
                        OnAuthComplete();
                    break;
                default:

                    break;
            }
            
        }

        public string Request(string url)
        {
            if (_ExpiresOn < DateTime.Now)
            {
                Refresh();
            }
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _AccessToken);
            client.DefaultRequestHeaders.Add("Accept", "application/xml");
            badPractise:
            var response = Task.Run(async () => await client.GetAsync(url)).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    if (OnAuthFailed != null)
                    {
                        OnAuthFailed();
                        goto badPractise;
                    }
                    else
                        throw new BadAuthenticationRequestException();
                    break;
                     
                case HttpStatusCode.OK:  
                default:

                    break;
            }
            var content = Task.Run(async () => await response.Content.ReadAsStringAsync()).Result;
            return content;
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
                    if (OnAuthComplete != null)
                        OnAuthComplete();
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

    public class BadAuthenticationRequestException : Exception {
        public BadAuthenticationRequestException()
        {
        }

    }
}

using System;

using Xamarin.Auth;

namespace LightspeedNET
{
    public class LSAuthenticator
    {
        public OAuth2Authenticator Authenticator { get; set; }
        private Account _account;
        public delegate void AuthComplete();
        public event AuthComplete OnAuthComplete;
        public delegate void AuthFailed();
        public event AuthFailed OnAuthFailed;

        public Account Account
        { get
            { return _account; }
          set
            { if (!value.Properties.ContainsKey("refresh_token"))
                    value.Properties.Add("refresh_token", _account.Properties["refresh_token"]);
              else _account = value; } }


        public LSAuthenticator(string clientID, string clientSecret, Account account)
        {
            Account = account;
            Authenticator = BuildAuthenticator(clientID, clientSecret);
        }

            public LSAuthenticator(string clientID, string clientSecret)
        {
            Authenticator = BuildAuthenticator(clientID, clientSecret);
            
        }
        private OAuth2Authenticator BuildAuthenticator(string clientID, string clientSecret)
        {
            var auth = new OAuth2Authenticator(
                clientId: clientID,
                clientSecret: clientSecret,
                scope: "employee:all",
                authorizeUrl: new Uri("https://cloud.lightspeedapp.com/oauth/authorize.php"),
                redirectUrl: new Uri("https://localhost/"),
                accessTokenUrl: new Uri("https://cloud.lightspeedapp.com/oauth/access_token.php")
            );
            auth.AccessTokenName = "code";
            auth.Completed += Auth_Completed;
            return auth;
        }

        //internal UIViewController Controller;
        //public void ShowLoginPrompt(UIViewController viewController)
        //{
        //    Controller = viewController;
        //    var ui =  Authenticator.GetUI();
        //    Controller.PresentViewController(ui, true, null);
        //}

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                Account = e.Account;
                //if (Controller != null)
                //{
                //    Controller.DismissViewController(true, null);
                //    Controller = null;
                //}
                if (OnAuthComplete != null)
                    OnAuthComplete();
                //Controller.PerformSegue("ToTheAPP", Controller);
            }

            else
            if (OnAuthFailed != null)
                OnAuthFailed();
            
        }
    }
}

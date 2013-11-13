#region

using System;
using System.Web.Security;
using FunnelWeb.Settings;

#endregion

namespace FunnelWeb.Authentication.Internal
{
    public class FormsAuthenticator : IAuthenticator
    {
        private readonly IConfigurationManager configMgr;
        private readonly Func<ISettingsProvider> settingsProvider;

        public FormsAuthenticator(Func<ISettingsProvider> provider, IConfigurationManager configManager)
        {
            settingsProvider = provider;
            configMgr = configManager;
        }

        public string GetName()
        {
            return settingsProvider().GetSettings<FunnelWebSettings>().Author;
        }

        public bool AuthenticateAndLogin(string username, string password)
        {
            //Test
            var requiredUsername = configMgr.AppSettings("username");
            var requiredPassword = configMgr.AppSettings("password");

            var authenticated = username == requiredUsername && password == requiredPassword;

            if (authenticated)
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }
            return authenticated;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
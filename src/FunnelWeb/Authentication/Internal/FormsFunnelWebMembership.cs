#region

using System;
using System.Collections.Generic;
using FunnelWeb.Model.Authentication;
using FunnelWeb.Settings;

#endregion

namespace FunnelWeb.Authentication.Internal
{
    public class FormsFunnelWebMembership : IFunnelWebMembership
    {
        private readonly IConfigurationManager configMgr;
        private readonly Func<ISettingsProvider> settingsProvider;

        public FormsFunnelWebMembership(Func<ISettingsProvider> provider, IConfigurationManager configurationManager)
        {
            settingsProvider = provider;
            configMgr = configurationManager;
        }

        public bool HasAdminAccount()
        {
            return true;
        }

        public User CreateAccount(string name, string email, string username, string password)
        {
            throw new NotSupportedException("You cannot create a new Forms Authentication Account");
        }

        public IEnumerable<User> GetUsers()
        {
            return new[]
                {
                    new User
                        {
                            Name = settingsProvider().GetSettings<FunnelWebSettings>().Author,
                            Username = configMgr.AppSettings("username")
                        }
                };
        }
    }
}
#region

using System.Configuration;
using System.Diagnostics.Contracts;

#endregion

namespace FunnelWeb.Settings
{
    public class CustomConfigurationManager : IConfigurationManager
    {
        public string ConnectionString
        {
            get
            {
                var connection = ConfigurationManager.ConnectionStrings["MyDb"];
                Contract.Assume(connection != null);
                return connection.ConnectionString;
            }
        }

        public void AppSettings(string key, string value)
        {
            ConfigurationManager.AppSettings[key] = value;
        }

        public string AppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
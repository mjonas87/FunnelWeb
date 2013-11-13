#region

using FunnelWeb.DatabaseDeployer;

#endregion

namespace FunnelWeb.Settings
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        private const string SchemaKey = "schema";
        private const string ReadOnlyReasonKey = "readOnlyReason";
        private const string ProviderKey = "provider";
        private readonly IAppHarborSettings appHarborSettings;
        private readonly IConfigurationManager configMgr;

        public ConnectionStringSettings(IConfigurationManager configManager, IAppHarborSettings appHarbor)
        {
            configMgr = configManager;
            appHarborSettings = appHarbor;
        }

        public string ConnectionString
        {
            get { return appHarborSettings.SqlServerConnectionString ?? configMgr.ConnectionString; }
        }

        public string Schema
        {
            get { return configMgr.AppSettings(SchemaKey); }
            set { configMgr.AppSettings(SchemaKey, value); }
        }

        public string ReadOnlyReason
        {
            get { return configMgr.AppSettings(ReadOnlyReasonKey); }
        }

        public string DatabaseProvider
        {
            get { return (configMgr.AppSettings(ProviderKey) ?? "sql").ToLower(); }
            set { configMgr.AppSettings(ProviderKey, value); }
        }
    }
}
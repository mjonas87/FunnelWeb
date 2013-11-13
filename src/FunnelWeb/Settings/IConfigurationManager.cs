#region

#endregion

namespace FunnelWeb.Settings
{
    public interface IConfigurationManager
    {
        string ConnectionString { get; }

        void AppSettings(string key, string value);
        string AppSettings(string key);
    }
}
using System;
using Autofac;
using FunnelWeb.DatabaseDeployer;
using FunnelWeb.Model.Repositories;

namespace FunnelWeb.Settings
{
    public class SettingsModule : Module
    {
        private readonly string bootstrapSettingsFilePath;

        public SettingsModule(string bootstrapSettingsFilePath)
        {
            this.bootstrapSettingsFilePath = bootstrapSettingsFilePath;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConnectionStringSettings>()
                .As<IConnectionStringSettings>()
                .SingleInstance();

            builder.Register(c => new CustomConfigurationManager())
                .As<IConfigurationManager>()
                .SingleInstance();

            builder.RegisterType<AppHarborSettings>()
                .As<IAppHarborSettings>()
                .SingleInstance();

            builder.Register(c => new SettingsProvider(c.Resolve<Func<IAdminRepository>>()))
                .As<ISettingsProvider>()
                .SingleInstance();
        }
    }
}

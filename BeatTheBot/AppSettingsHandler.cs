using System;
using Microsoft.Extensions.Configuration;

namespace BeatTheBot
{
    public class AppSettingsHandler
    {
        private string Filename;
        private AppSettings Config;

        public AppSettingsHandler()
        {
            Filename = "appsettings.json";
            Config = GetAppSettings();
        }

        public AppSettings GetAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(Filename, false, true)
                .Build();

            return config.GetSection("Player_Config") as AppSettings;
        }
        public AppSettings GetConfig()
        {
            return Config;
        }
    }
}
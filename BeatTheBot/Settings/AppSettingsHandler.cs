using System;
using Microsoft.Extensions.Configuration;

namespace Settings.BeatTheBot
{
    public class AppSettingsHandler
    {
        private readonly string Filename;
        private readonly AppSettings Config;

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

            var loadedConfig = config.GetSection("Player_Config");
            AppSettings settings = new();
            settings.HP = loadedConfig.GetSection("HP").Value;
            settings.Defense = loadedConfig.GetSection("Defense").Value;
            settings.Min_Damage = loadedConfig.GetSection("Min_Damage").Value;
            settings.Max_Damage = loadedConfig.GetSection("Max_Damage").Value;
            settings.Critical_Attack_Chance = loadedConfig.GetSection("Critical_Attack_Chance").Value;
            settings.Critical_Spell_Chance = loadedConfig.GetSection("Critical_Spell_Chance").Value;

            return settings;
        }
        public AppSettings GetConfig()
        {
            return Config;
        }
    }
}
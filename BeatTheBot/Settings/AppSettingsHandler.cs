using System;
using Microsoft.Extensions.Configuration;

namespace BeatTheBot.Settings
{
    public class AppSettingsHandler
    {
        private readonly string _filename;
        private readonly AppSettings _config;

        public AppSettingsHandler()
        {
            _filename = "appsettings.json";
            _config = GetAppSettings();
        }

        private AppSettings GetAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(_filename, false, true)
                .Build();

            var loadedConfig = config.GetSection("Player_Config");
            AppSettings settings = new()
            {
                Hp = loadedConfig.GetSection("HP").Value,
                Defense = loadedConfig.GetSection("Defense").Value,
                MinDamage = loadedConfig.GetSection("Min_Damage").Value,
                MaxDamage = loadedConfig.GetSection("Max_Damage").Value,
                CriticalAttackChance = loadedConfig.GetSection("Critical_Attack_Chance").Value,
                CriticalSpellChance = loadedConfig.GetSection("Critical_Spell_Chance").Value
            };

            return settings;
        }
        public AppSettings GetConfig()
        {
            return _config;
        }
    }
}
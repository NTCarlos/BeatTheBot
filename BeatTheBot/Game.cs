namespace BeatTheBot
{
    public class Game
    {
        private Player PlayerOne;
        private Bot Bot;
        readonly AppSettingsHandler settingsHandler;

        Difficulty difficulty;
        // This will cahnge depending on the Game Difficulty
        private double BotCoef;

        public Game(int difficulty)
        {
            // Set Game difficulty based on user selection.
            switch (difficulty)
            {
                case 1:
                    this.difficulty = Difficulty.Easy;
                    BotCoef = 1;
                    break;
                case 2:
                    this.difficulty = Difficulty.Medium;
                    BotCoef = 1.3;
                    break;
                case 3:
                    this.difficulty = Difficulty.Hard;
                    BotCoef = 1.5;
                    break;
                default:
                    this.difficulty = Difficulty.Easy;
                    break;
            }

            // Load settings
            settingsHandler = new AppSettingsHandler();
            int Hp = int.Parse(settingsHandler.GetConfig().HP);
            int Defense = int.Parse(settingsHandler.GetConfig().Defense);
            int Min_Damage = int.Parse(settingsHandler.GetConfig().Min_Damage);
            int Max_Damage = int.Parse(settingsHandler.GetConfig().Max_Damage);
            int Critical_Chance = int.Parse(settingsHandler.GetConfig().Critical_Attack_Chance);
            int Spell_Chance = int.Parse(settingsHandler.GetConfig().Critical_Spell_Chance);

            // Create a player
            PlayerOne = new Player(Hp, Defense, Min_Damage, Max_Damage, Critical_Chance, Spell_Chance);

            // Create the bot
            Bot = new Bot((int)(Hp * BotCoef), (int)(Defense * BotCoef), (int)(Min_Damage * BotCoef), (int)(Max_Damage * BotCoef), (int)(Critical_Chance * BotCoef), (int)(Spell_Chance * BotCoef));
        }
    }
}
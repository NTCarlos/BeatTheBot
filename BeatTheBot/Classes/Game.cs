using BeatTheBot.Enums;
using BeatTheBot.Settings;

namespace BeatTheBot.Classes
{
    public class RoundResult
    {
        public bool BotHitted;
        public bool PlayerHitted;
        public int BotHp;
        public int PlayerHp;
        public bool BotAlive = true;
        public bool PlayerAlive = true;
        public Attack PlayerAttack;
        public Attack BotAttack;
        public int DamageTakenByPlayer;
        public int DamageTakenByBot;
        public BodyPart BotDefenseChoice;
        public BodyPart BotAttackChoice;
    }
    public class Game
    {
        private readonly Player _playerOne;
        private readonly Bot _bot;
        private readonly Difficulty _difficulty;

        readonly AppSettingsHandler _settingsHandler;

        // This will cahnge depending on the Game Difficulty
        private readonly double _botCoef;

        public Game(Difficulty difficulty)
        {
            // Set Game difficulty based on user selection.
            _difficulty = difficulty;
            _botCoef = difficulty switch
            {
                Difficulty.Easy => 1,
                Difficulty.Medium => 1.3,
                Difficulty.Hard => 1.5,
                _ => 1
            };

            // Load settings
            _settingsHandler = new AppSettingsHandler();
            var hp = int.Parse(_settingsHandler.GetConfig().Hp);
            var defense = int.Parse(_settingsHandler.GetConfig().Defense);
            var minDamage = int.Parse(_settingsHandler.GetConfig().MinDamage);
            var maxDamage = int.Parse(_settingsHandler.GetConfig().MaxDamage);
            var criticalChance = int.Parse(_settingsHandler.GetConfig().CriticalAttackChance);
            var spellChance = int.Parse(_settingsHandler.GetConfig().CriticalSpellChance);

            // Create a player
            _playerOne = new Player(hp, defense, minDamage, maxDamage, criticalChance, spellChance);

            // Create the bot
            _bot = new Bot((int)(hp * _botCoef), (int)(defense * _botCoef), (int)(minDamage * _botCoef), (int)(maxDamage * _botCoef), (int)(criticalChance * _botCoef), (int)(spellChance * _botCoef));
        }

        public RoundResult Round(BodyPart playerAttackChoice, BodyPart playerDefenseChoice)
        {

            RoundResult round = new()
            {
                BotDefenseChoice = _bot.AutoRoll(),
                BotAttackChoice = _bot.AutoRoll()
            };

            if (playerAttackChoice == round.BotDefenseChoice)
            {
                round.BotHitted = false;
            }
            else
            {
                round.BotHitted = true;
                round.PlayerAttack = _playerOne.Attack();
                round.DamageTakenByBot = _bot.TakeDamage(round.PlayerAttack.GetDamage());
                // Check if the bot lost
                if (!_bot.IsAlive())
                {
                    round.BotAlive = false;
                }

                //Get Bot new HP
                round.BotHp = _bot.CurrentHp();
            }
            if (round.BotAttackChoice == playerDefenseChoice)
            {
                round.PlayerHitted = false;
            }
            else
            {
                round.PlayerHitted = true;
                round.BotAttack = _bot.Attack(_difficulty);
                round.DamageTakenByPlayer = _playerOne.TakeDamage(round.BotAttack.GetDamage());

                // Check if the Player lost
                if (!_playerOne.IsAlive())
                {
                    round.PlayerAlive = false;
                }

                //Get Player new HP
                round.PlayerHp = _playerOne.CurrentHp();
            }
            // Return the statistics of this Round.
            return round;
        }
    }
}
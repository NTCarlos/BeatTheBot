using BeatTheBot.Classes;
using Settings.BeatTheBot;

namespace Classes.BeatTheBot
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
        public BodyPart botDefenseChoice;
        public BodyPart botAttackChoice;
    }
    public class Game
    {
        private Player PlayerOne;
        private Bot Bot;

        readonly AppSettingsHandler settingsHandler;

        // This will cahnge depending on the Game Difficulty
        private double BotCoef;

        public Game(Difficulty difficulty)
        {
            // Set Game difficulty based on user selection.
            switch (difficulty)
            {
                case Difficulty.Easy:
                    BotCoef = 1;
                    break;
                case Difficulty.Medium:
                    BotCoef = 1.3;
                    break;
                case Difficulty.Hard:
                    BotCoef = 1.5;
                    break;
                default:
                    BotCoef = 1;
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

        public RoundResult Round(BodyPart playerAttackChoice, BodyPart playerDefenseChoice)
        {

            RoundResult round = new();
            round.botDefenseChoice = Bot.AutoRoll();
            round.botAttackChoice = Bot.AutoRoll();

            if (playerAttackChoice == round.botDefenseChoice)
            {
                round.BotHitted = false;
            }
            else
            {
                round.BotHitted = true;
                round.PlayerAttack = PlayerOne.Attack();
                Bot.TakeDamage(round.PlayerAttack.GetDamage());
                // Check if the bot lost
                if (!Bot.IsAlive())
                {
                    round.BotAlive = false;
                }

                //Get Bot new HP
                round.BotHp = Bot.CurrentHp();
            }
            if (round.botAttackChoice == playerDefenseChoice)
            {
                round.PlayerHitted = false;
            }
            else
            {
                round.PlayerHitted = true;
                round.BotAttack = Bot.Attack();
                PlayerOne.TakeDamage(round.BotAttack.GetDamage());

                // Check if the Player lost
                if (!PlayerOne.IsAlive())
                {
                    round.PlayerAlive = false;
                }

                //Get Player new HP
                round.PlayerHp = PlayerOne.CurrentHp();
            }
            // Return the statictics of this Round.
            return round;
        }
    }
}
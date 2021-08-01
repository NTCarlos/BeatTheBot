using System;

namespace BeatTheBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game1;
            Console.WriteLine("Choose difficulty:");
            Console.WriteLine("(E)asy, (M)edium or (H)ard");
            string s = Console.ReadLine().Trim();
            game1 = new Game(DifficultySelection(s));
            //
            Console.WriteLine("The battle begins...");
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Select wich part of the bot body you want to attack:");
                Console.WriteLine("(H)ead, (C)hest or (L)egs");
                string playerAtk = Console.ReadLine().Trim();
                Console.WriteLine("Select wich part of your body you want to Defend:");
                Console.WriteLine("(H)ead, (C)hest or (L)egs");
                string playerDef = Console.ReadLine().Trim();
                var results = game1.Round(BodyPartChoice(playerAtk), BodyPartChoice(playerDef));
                // Show statistics
                if (results.BotHitted)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("You hit the bot at the " + BodyPartChoice(playerAtk).ToString() + " causing "+ results.PlayerAttack.GetDamage() + " " + results.PlayerAttack.GetAttackType() + " damage.");
                    Console.WriteLine("Bot HP: " + results.BotHp);
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("You attack the bot at the " + BodyPartChoice(playerAtk).ToString() + " but he dodged.");
                    Console.WriteLine(" ");
                }
                if (results.PlayerHitted)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The Bot hit you at the " + results.botAttackChoice + " causing " + results.BotAttack.GetDamage() + " " + results.BotAttack.GetAttackType() + " damage.");
                    Console.WriteLine("Your HP: " + results.PlayerHp);
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The Bot attack you at the " + results.botAttackChoice + " but you dodged.");
                    Console.WriteLine(" ");
                }
                // Check for winners
                if (!results.PlayerAlive)
                {
                    Console.WriteLine("The Bot defeated you!");
                    break;
                }
                else if (!results.BotAlive)
                {
                    Console.WriteLine("You defeat the Bot. Congratulations!");
                    break;
                }
            }
        }

        public static Difficulty DifficultySelection(string s)
        {
            if (s.ToLower().Contains('e'))
            {
                return Difficulty.Easy;
            }
            else if (s.ToLower().Contains('m'))
            {
                return Difficulty.Medium;
            }
            return Difficulty.Hard;
        }

        public static BodyPart BodyPartChoice(string s)
        {
            if (s.ToLower().Contains('h'))
            {
                return BodyPart.Head;
            }
            else if (s.ToLower().Contains('c'))
            {
                return BodyPart.Chest;
            }
            return BodyPart.Legs;
        }
    }
}
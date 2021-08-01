using BeatTheBot.Classes;
using Enums.BeatTheBot;

namespace Classes.BeatTheBot
{
    public class Bot : Player
    {

        public Bot(int Hp, int Defense, int Min_Damage, int Max_Damage, int Critical_Chance, int Spell_Chance) 
            : base(Hp, Defense, Min_Damage, Max_Damage, Critical_Chance, Spell_Chance)
        {
            
        }

        public BodyPart AutoRoll()
        {
            var number = random.Next(1, 3);
            return (BodyPart)number;
        }
        public Attack Attack(Difficulty difficulty)
        {
            var damage = random.Next(Min_Damage, Max_Damage);

            // Easy bots can't land critical strikes
            if(difficulty != Difficulty.Easy)
            {
                var rollCritical = random.Next(1, 100);
                if (rollCritical <= Critical_Chance)
                {
                    return new Attack(damage * 2, AttackType.Critical);
                }
            }
            return new Attack(damage, AttackType.Normal);
        }
    }
}
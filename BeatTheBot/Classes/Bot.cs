using BeatTheBot.Enums;

namespace BeatTheBot.Classes
{
    public class Bot : Player
    {

        public Bot(int hp, int defense, int minDamage, int maxDamage, int criticalChance, int spellChance) 
            : base(hp, defense, minDamage, maxDamage, criticalChance, spellChance)
        {
            
        }

        public BodyPart AutoRoll()
        {
            var number = Random.Next(1, 3);
            return (BodyPart)number;
        }
        public Attack Attack(Difficulty difficulty)
        {
            var damage = Random.Next(MinDamage, MaxDamage);

            // Easy bots can't land critical strikes
            if (difficulty == Difficulty.Easy) return new Attack(damage, AttackType.Normal);
            
            var rollCritical = Random.Next(1, 100);
            if (rollCritical <= CriticalChance)
            {
                return new Attack(damage * 2, AttackType.Critical);
            }

            var rollSpell = Random.Next(1, 100);
            return rollSpell <= SpellChance ? new Attack(damage * 3, AttackType.Spell) : new Attack(damage, AttackType.Normal);
        }
    }
}
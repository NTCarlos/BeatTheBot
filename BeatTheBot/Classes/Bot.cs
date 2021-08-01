using System;

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
    }
}
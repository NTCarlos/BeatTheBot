using System;

namespace BeatTheBot
{
    public class Player
    {
        private int Hp;
        private int Defense;
        private int Min_Damage;
        private int Max_Damage;
        private int Critical_Chance;
        private int Spell_Chance;
        private int DefendedArea = 0;
        
        internal Random random = new Random();

        

        public Player(int Hp, int Defense, int Min_Damage, int Max_Damage, int Critical_Chance, int Spell_Chance)
        {
            this.Hp = Hp;
            this.Defense = Defense;
            this.Min_Damage = Min_Damage;
            this.Max_Damage = Max_Damage;
            this.Critical_Chance = Critical_Chance;
            this.Spell_Chance = Spell_Chance;
        }

        public int Attack()
        {
            return random.Next(Min_Damage, Max_Damage);
        }

        public void SetDefendedArea(int area)
        {
            DefendedArea = area;
        }

        public int GetDefendedArea()
        {
            return DefendedArea;
        }
    }
}
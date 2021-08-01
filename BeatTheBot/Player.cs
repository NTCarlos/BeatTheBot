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
        private bool Alive;
        internal Random random = new Random();

        public Player(int Hp, int Defense, int Min_Damage, int Max_Damage, int Critical_Chance, int Spell_Chance)
        {
            this.Hp = Hp;
            this.Defense = Defense;
            this.Min_Damage = Min_Damage;
            this.Max_Damage = Max_Damage;
            this.Critical_Chance = Critical_Chance;
            this.Spell_Chance = Spell_Chance;
            Alive = true;
        }

        public Attack Attack()
        {
            var damage = random.Next(Min_Damage, Max_Damage);

            var rollCritical = random.Next(1, 100);
            if(rollCritical<= Critical_Chance)
            {
                return new Attack(damage * 2, AttackType.Critical);
            }
            return new Attack(damage, AttackType.Normal);
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                Alive = false;
            }
        }

        public int CurrentHp()
        {
            return Hp;
        }

        public bool IsAlive()
        {
            return Alive;
        }
    }
    public class Attack
    {
        private int damage;
        private AttackType type;
        public Attack(int dmg, AttackType typ)
        {
            damage = dmg;
            type = typ;
        }
        public int GetDamage()
        {
            return damage;
        }
        public AttackType GetAttackType()
        {
            return type;
        }
    }
}
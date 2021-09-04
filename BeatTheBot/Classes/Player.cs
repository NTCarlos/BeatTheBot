using System;
using BeatTheBot.Enums;

namespace BeatTheBot.Classes
{
    public class Player
    {
        private int _hp;
        private readonly int _defense;
        internal readonly int MinDamage;
        internal readonly int MaxDamage;
        internal readonly int CriticalChance;
        internal readonly int SpellChance;
        private bool _alive;
        internal readonly Random Random = new();

        public Player(int hp, int defense, int minDamage, int maxDamage, int criticalChance, int spellChance)
        {
            _hp = hp;
            _defense = defense;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            CriticalChance = criticalChance;
            SpellChance = spellChance;
            _alive = true;
        }

        public Attack Attack()
        {
            var damage = Random.Next(MinDamage, MaxDamage);

            var rollCritical = Random.Next(1, 100);
            if(rollCritical<= CriticalChance)
            {
                return new Attack(damage * 2, AttackType.Critical);
            }

            var rollSpell = Random.Next(1, 100);
            if (rollSpell <= SpellChance)
            {
                return new Attack(damage * 3, AttackType.Spell);
            }

            return new Attack(damage, AttackType.Normal);
        }

        public int TakeDamage(int damage)
        {
            // Defense absorb a % of damage
            var absorbedDamage = damage * (double)_defense / 100;
            _hp -= damage - (int)Math.Round(absorbedDamage);
            if (_hp <= 0)
            {
                _alive = false;
            }
            return damage - (int)Math.Round(absorbedDamage);
        }

        public int CurrentHp()
        {
            return _hp;
        }

        public bool IsAlive()
        {
            return _alive;
        }
    }

}
﻿using BeatTheBot.Classes;
using Enums.BeatTheBot;
using System;

namespace Classes.BeatTheBot
{
    public class Player
    {
        private int Hp;
        private readonly int Defense;
        internal int Min_Damage;
        internal int Max_Damage;
        internal int Critical_Chance;
        internal int Spell_Chance;
        private bool Alive;
        internal Random random = new();

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

            var rollSpell = random.Next(1, 100);
            if (rollSpell <= Spell_Chance)
            {
                return new Attack(damage * 3, AttackType.Spell);
            }

            return new Attack(damage, AttackType.Normal);
        }

        public int TakeDamage(int damage)
        {
            // Defense absorb a % of damage
            double absorbedDamage = (double)damage * (double)Defense / (double)100;
            Hp -= damage - (int)Math.Round(absorbedDamage);
            if (Hp <= 0)
            {
                Alive = false;
            }
            return damage - (int)Math.Round(absorbedDamage);
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

}
using Enums.BeatTheBot;

namespace BeatTheBot.Classes
{
    public class Attack
    {
        private readonly int damage;
        private readonly AttackType type;
        public Attack(int damage, AttackType type)
        {
            this.damage = damage;
            this.type = type;
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

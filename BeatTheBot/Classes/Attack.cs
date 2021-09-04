using BeatTheBot.Enums;

namespace BeatTheBot.Classes
{
    public class Attack
    {
        private readonly int _damage;
        private readonly AttackType _type;
        public Attack(int damage, AttackType type)
        {
            _damage = damage;
            _type = type;
        }
        public int GetDamage()
        {
            return _damage;
        }
        public AttackType GetAttackType()
        {
            return _type;
        }
    }
}

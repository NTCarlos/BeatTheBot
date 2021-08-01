
using Classes.BeatTheBot;

namespace BeatTheBot.Classes
{
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

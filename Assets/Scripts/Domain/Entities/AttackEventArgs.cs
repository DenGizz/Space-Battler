using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Entities
{
    public class AttackEventArgs
    {
        public IAttackable Attacker { get; }
        public IDamagable Target { get; }
        public float Damage { get; }

        public AttackEventArgs(IAttackable attacker, IDamagable target, float damage)
        {
            Attacker = attacker;
            Target = target;
            Damage = damage;
        }
    }
}
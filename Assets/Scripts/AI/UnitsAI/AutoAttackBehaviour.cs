using Assets.Scripts.Entities;
using Assets.Scripts.Entities.SpaceShips;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.AI.UnitsAI
{
    [AddComponentMenu("AI/Combat Unit/AutoAttack Behaviour")]
    [RequireComponent(typeof(IAttackable))]
    public class AutoAttackBehaviour : MonoBehaviour, ICombatAi, ITickable
    {
        public ISpaceShip Target { get; set; }
        private IAttackable _attackable;

        private void Awake()
        {
            _attackable = GetComponent<IAttackable>();
        }

        public void Tick()
        {
            if(!_attackable.CanAttack)
                return;

            if (Target == null)
                return;

            if (!Target.Data.IsAlive)
                return;

            _attackable.Attack(Target);
        }
    }
}

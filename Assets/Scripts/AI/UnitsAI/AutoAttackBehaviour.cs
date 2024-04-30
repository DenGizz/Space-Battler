using System.Linq;
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
        private ISpaceShip _target;
        private bool _isInCombatState;

        private IAttackable _attackable;

        private void Awake()
        {
            _attackable = GetComponent<IAttackable>();
        }

        public void SetTarget(ISpaceShip target)
        {
            _target = target;
        }

        public void StartCombat()
        {
            _isInCombatState = true;
        }

        public void StopCombat()
        {
            _isInCombatState = false;
        }

        public void Tick()
        {
            if (!_isInCombatState)
                return;

            if (_target == null)
                return;

            if (!_target.Data.IsAlive)
                return;

            _attackable.Attack(_target);
        }
    }
}

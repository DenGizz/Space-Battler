using System.Linq;
using Assets.Scripts.SpaceShips;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.AI.UnitsAI
{
    [AddComponentMenu("AI/CombatUnit/AutoAttackBehaviour")]
    [RequireComponent(typeof(IAttackable))]
    public class AutoAttackBehaviour : MonoBehaviour, ICombatAi, ITickable
    {
        private ISpaceShip _target;
        private bool _isInCombatState;

        private IAttackable _controledAttackable;

        private void Awake()
        {
            _controledAttackable = GetComponent<IAttackable>();
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

            if (_target.IsDead)
                return;
            _controledAttackable.Attack(_target);
        }
    }
}

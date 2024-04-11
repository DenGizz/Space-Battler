using System.Linq;
using Assets.Scripts.SpaceShips;
using UnityEngine;

namespace Assets.Scripts.AI.UnitsAI
{
    [AddComponentMenu("AI/CombatUnit/AutoAttackBehaviour")]
    [RequireComponent(typeof(ISpaceShip))]
    public class AutoAttackBehaviour : MonoBehaviour, ICombatAi
    {
        public ISpaceShip Target { get; private set; }
        public bool IsInCombatState { get; private set; }

        [SerializeField] private ISpaceShip _target;
        private ISpaceShip _controlledSpaceShip;

        private void Awake()
        {
            _controlledSpaceShip = GetComponent<ISpaceShip>();
        }

        public void SetTarget(ISpaceShip target)
        {
            Target = target;
        }

        public void RemoveTarget()
        {
            Target = null;
        }

        public void StartCombat()
        {
            IsInCombatState = true;
        }

        public void StopCombat()
        {
            IsInCombatState = false;
        }

        private void Update()
        {
            if (!IsInCombatState)
                return;

            if (Target == null)
                return;

            if (Target is ISpaceShip combatUnit && combatUnit.HealthAttribute.HP <= 0)
                return;

            if (_controlledSpaceShip.Weapons == null || !_controlledSpaceShip.Weapons.Any())
            {
                Debug.Log($"{gameObject.name} does`nt have weapon to attack.");
                return;
            }

            foreach(var weapon in _controlledSpaceShip.Weapons)
                if (weapon.CanShoot)
                    weapon.Shoot(Target);     
        }
    }
}

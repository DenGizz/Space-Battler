using Assets.Scripts.SpaceShip;
using UnityEngine;

namespace Assets.Scripts.AI.UnitsAI
{
    [AddComponentMenu("AI/CombatUnit/AutoAttackAI")]
    [RequireComponent(typeof(ISpaceShip))]
    public class AutoAttackAI : MonoBehaviour, ICombatAI
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

            foreach(var weapon in _controlledSpaceShip.Weapons)
                if (weapon.CanShoot)
                    weapon.Shoot(Target);     
        }
    }
}

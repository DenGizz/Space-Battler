using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.AI
{
    [AddComponentMenu("AI/CombatUnit/AutoAttackAI")]
    [RequireComponent(typeof(ICombatUnit))]
    public class AutoAttackAI : MonoBehaviour, ICombatAI
    {
        public ICombatUnit Target { get; private set; }
        public bool IsInCombatState { get; private set; }

        [SerializeField] private ICombatUnit _target;
        private ICombatUnit _controlledCombatUnit;

        private void Awake()
        {
            _controlledCombatUnit = GetComponent<ICombatUnit>();
        }

        public void SetTarget(ICombatUnit target)
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

            if (Target is ICombatUnit combatUnit && combatUnit.HealthAttribute.HP <= 0)
                return;

            foreach(var weapon in _controlledCombatUnit.Weapons)
                if (weapon.CanShoot)
                    weapon.Shoot(Target);     
        }
    }
}

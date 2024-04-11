using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipAttributes;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.SpaceShips
{
    [AddComponentMenu("Units/SpaceShip")]
    public class SpaceShipBehaviour : MonoBehaviour, ISpaceShip
    {
        public IHealthAttribute HealthAttribute { get; private set; }

        public Vector3 Position => transform.position;

        public IEnumerable<IWeapon> Weapons => _weapons;

        public SpaceShipConfig Config { get; private set; }

        private List<IWeapon> _weapons;

        [SerializeField] private SpaceShipDescriptor _descriptor;

        private void Construct(SpaceShipConfig config)
        {
            Config = config;
            HealthAttribute = new HealthAttribute(config.MaxHP, config.MaxHP);
            _weapons = new List<IWeapon>();
        }

        private void Awake()
        {
            Construct(_descriptor.GetSpaceShipConfig());
        }

        public void TakeDamage(float damageAmount)
        {
            HealthAttribute.TakeDamage(damageAmount);
        }
    
        public void Attack(IWeapon weapon, IDamagable target)
        {
            weapon.Shoot(target);
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (_weapons.Count >= Config.WeaponSlots)
                throw new System.Exception("No more weapon slots available");

            _weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            _weapons.Remove(weapon);
        }
    }
}

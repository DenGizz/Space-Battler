using System;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.SpaceShips
{
    [AddComponentMenu("Units/SpaceShip")]
    public class SpaceShipBehaviour : MonoBehaviour, ISpaceShip
    {
        [SerializeField] private SpaceShipDescriptor _descriptor;

        public SpaceShipData Data { get; private set; }

        public SpaceShipConfig Config { get; private set; }

        public event Action<ISpaceShip> OnDeath;

        [Inject]
        public void Construct(SpaceShipData data)
        {
            Data = data;
            Config = _descriptor.GetSpaceShipConfig();
            Data.HealthPoints = Config.MaxHP;
            transform.position = Data.Position;
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (Data.Weapons.Count >= Config.WeaponSlots)
                throw new Exception("No more weapon slots available");

            Data.Weapons.Add(weapon);
        }

        public void Attack(ISpaceShip target)
        {
            foreach (var weapon in Data.Weapons)
                if (weapon.CanShoot)
                    weapon.Attack(target);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            Data.Weapons.Remove(weapon);
        }

        public void TakeDamage(float damageAmount)
        {
            Data.HealthPoints -= damageAmount;

            if (Data.HealthPoints <= 0)
                OnDeath?.Invoke(this);
        }
    }
}

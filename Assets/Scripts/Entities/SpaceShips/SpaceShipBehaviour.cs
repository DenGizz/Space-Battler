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

        public bool CanAttack => Data.IsAlive;

        public event Action<ISpaceShip> OnDeath;

        public void SetData(SpaceShipData data)
        {
            Data = data;
            Config = _descriptor.GetSpaceShipConfig();
            Data.HealthPoints = Config.MaxHP;
            transform.position = Data.Position;
        }

        public void SetPosition(Vector3 position)
        {
            Data.Position = position;
            transform.position = position;;
        }

        public void SetRotation(float zRotation)
        {
            Data.ZRotation = zRotation;
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (Data.Weapons.Count >= Config.WeaponSlots)
                throw new Exception("No more weapon slots available");

            Data.Weapons.Add(weapon);
        }

        public void Attack(ISpaceShip target)
        {
            if(!Data.IsAlive)
                throw new Exception("Dead ships can't attack");

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
            Data.HealthPoints = Mathf.Clamp(Data.HealthPoints, 0, Config.MaxHP);

            if (Data.HealthPoints <= 0)
            {
                Data.IsAlive = false;
                OnDeath?.Invoke(this);
            }
                
        }
    }
}

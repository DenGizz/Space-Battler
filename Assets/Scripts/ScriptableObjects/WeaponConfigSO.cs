using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "StaticData/WeaponConfig", order = 0)]
    public class WeaponConfigSO : ScriptableObject
    {
        public WeaponType WeaponType => _weaponType;
        public float Damage => _damage;
        public float ColdDownTime => _coldDownTime;

        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private float _damage;
        [SerializeField] private float _coldDownTime;


        public WeaponConfig GetWeaponConfig()
        {
            return new WeaponConfig(Damage, ColdDownTime);
        }
    }
}

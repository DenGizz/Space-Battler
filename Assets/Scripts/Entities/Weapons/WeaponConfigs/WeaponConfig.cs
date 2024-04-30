using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponConfigs
{
    public class WeaponConfig 
    {
        public float Damage { get; }    
        public float ColdDownTime { get; }

        public WeaponConfig(float damage, float coldDownTime)
        {
            Damage = damage;
            ColdDownTime = coldDownTime;
        }
    }
}
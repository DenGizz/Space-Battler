﻿using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "StaticData/WeaponConfig", order = 0)]
    public class WeaponDescriptor : ScriptableObject
    {
        public WeaponType WeaponType => _weaponType;
        public float Damage => _damage;
        public float ColdDownTime => _coldDownTime;
        public Sprite Sprite => _sprite;
        public GameObject Prefab => _prefab;

        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private float _damage;
        [SerializeField] private float _coldDownTime;
        [SerializeField] private Sprite _sprite;
        [SerializeField] GameObject _prefab;


        public WeaponConfig GetWeaponConfig()
        {
            return new WeaponConfig(Damage, ColdDownTime);
        }
    }
}

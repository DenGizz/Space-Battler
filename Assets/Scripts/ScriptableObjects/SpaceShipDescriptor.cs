using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpaceShipDescriptor", menuName = "StaticData/SpaceShipDescriptor", order = 0)]
    public class SpaceShipDescriptor : ScriptableObject
    {
        public SpaceShipType SpaceShipType  => _spaceShipType;
        public float MaxHealth  => _maxHealth;
        public int WeaponSlotsCount => _weaponSlotsCount;
        public Sprite Sprite => _sprite;
        public GameObject Prefab => _prefab;

        [SerializeField] private SpaceShipType _spaceShipType;
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _weaponSlotsCount;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private GameObject _prefab;


        public SpaceShipConfig GetSpaceShipConfig()
        {
            return new SpaceShipConfig(MaxHealth, WeaponSlotsCount);
        }
    }
}

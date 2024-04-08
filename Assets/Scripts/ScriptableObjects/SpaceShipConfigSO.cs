using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpaceShipConfig", menuName = "StaticData/SpaceShipConfig", order = 0)]
    public class SpaceShipConfigSO : ScriptableObject
    {
        public SpaceShipType CorpusType  => _corpusType;
        public float MaxHealth  => _maxHealth;
        public int WeaponSlotsCount => _weaponSlotsCount;
        public Sprite Sprite => _sprite;

        [SerializeField] private SpaceShipType _corpusType;
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _weaponSlotsCount;
        [SerializeField] private Sprite _sprite;


        public SpaceShipConfig GetSpaceShipConfig()
        {
            return new SpaceShipConfig(MaxHealth, WeaponSlotsCount);
        }
    }
}

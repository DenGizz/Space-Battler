using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpaceShipConfig", menuName = "StaticData/SpaceShipConfig", order = 0)]
    public class SpaceShipConfigSO : ScriptableObject
    {
        public SpaceShipCorpusType CorpusType  => _corpusType;
        public float MaxHealth  => _maxHealth;
        public int WeaponSlotsCount => _weaponSlotsCount;

        [SerializeField] private SpaceShipCorpusType _corpusType;
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _weaponSlotsCount;


        public SpaceShipConfig GetSpaceShipConfig()
        {
            return new SpaceShipConfig(MaxHealth, WeaponSlotsCount);
        }
    }
}

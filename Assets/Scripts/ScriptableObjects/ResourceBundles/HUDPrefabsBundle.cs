using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.ResourceBundles
{
    [CreateAssetMenu(fileName = "HUDPrefabsBundle", menuName = "ResourceBundles/HUDPrefabsBundle")]
    public class HUDPrefabsBundle : ScriptableObject
    {
        public GameObject PauseBattleHUDPrefab => _pauseBattleHUDPrefab;

        [SerializeField] private GameObject _pauseBattleHUDPrefab;
    }
}

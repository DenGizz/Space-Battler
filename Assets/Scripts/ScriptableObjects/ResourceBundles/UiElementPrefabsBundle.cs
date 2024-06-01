using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.ResourceBundles
{
    [CreateAssetMenu(fileName = "UiElementPrefabsBundle", menuName = "ScriptableObjects/ResourceBundles/UiElementPrefabsBundle")]
    public class UiElementPrefabsBundle : ScriptableObject
    {
        public GameObject SpaceShipHealthViewPrefab => _spaceShipHealthViewPrefab;
        public GameObject WindowPrefab => _windowPrefab;
        public GameObject WeaponTypeSlotPrefab => _weaponTypeSlotPrefab;
        public GameObject UiGridPrefab => _uiGridPrefab;
        public GameObject WeaponTypeRowPrefab => _weaponTypeRowPrefab;
        public GameObject SpaceShipTypeRowPrefab => _spaceShipTypeRowPrefab;

        [SerializeField] private GameObject _spaceShipHealthViewPrefab;
        [SerializeField] private GameObject _windowPrefab;
        [SerializeField] private GameObject _weaponTypeSlotPrefab;
        [SerializeField] private GameObject _uiGridPrefab;
        [SerializeField] private GameObject _weaponTypeRowPrefab;
        [SerializeField] private GameObject _spaceShipTypeRowPrefab;
    }
}

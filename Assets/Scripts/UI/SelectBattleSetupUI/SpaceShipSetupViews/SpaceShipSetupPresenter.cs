using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews
{
    public class SpaceShipSetupPresenter : MonoBehaviour
    {
        [SerializeField] private SpaceShipSelectionSlot _spaceShipSelectionSlot;
        [SerializeField] private List<WeaponSelectionSlot> _weaponSelectionSlots;
        [SerializeField] private Button _randomizeButton;

        private SpaceShipSetup _spaceShipSetup;
        private  IStaticDataService _staticDataService;
        private IRandomSetupService _randomSetupService;

        [Inject]
        public void Construct(IStaticDataService staticDataService, IRandomSetupService randomSetupService)
        {
            _staticDataService = staticDataService;
            _randomSetupService = randomSetupService;
        }

        private void Awake()
        {
            _spaceShipSelectionSlot.OnSpaceShipTypeSelected += OnSpaceShipTypeSelected;
            _weaponSelectionSlots.ForEach(slot => slot.OnWeaponTypeSelected += OnWeaponTypeSelected);
            _randomizeButton.onClick.AddListener(RandomizeSpaceShipSetup);
        }

        private void OnDestroy()
        {
            _spaceShipSelectionSlot.OnSpaceShipTypeSelected -= OnSpaceShipTypeSelected;
            _weaponSelectionSlots.ForEach(slot => slot.OnWeaponTypeSelected -= OnWeaponTypeSelected);
        }

        public void SetSpaceShipSetup(SpaceShipSetup spaceShipSetup)
        {
            _spaceShipSetup = spaceShipSetup;
            LoadDataInUI();
        }

        private void LoadDataInUI()
        {
            _spaceShipSelectionSlot.SelectedSpaceShipType = _spaceShipSetup.SpaceShipType;
            UpdateSlots();
        }

        private void UpdateSlots()
        {
            int visibleSlots = _staticDataService.GetSpaceShipDescriptor(_spaceShipSetup.SpaceShipType).WeaponSlotsCount;

            for (int i = 0; i < _weaponSelectionSlots.Count; i++)
            {
               _weaponSelectionSlots[i].SelectedWeaponType = i < _spaceShipSetup.WeaponTypes.Count ? _spaceShipSetup.WeaponTypes[i] : WeaponType.None;
               _weaponSelectionSlots[i].gameObject.SetActive(i < visibleSlots);
            }
        }

        private void OnWeaponTypeSelected()
        {
            _spaceShipSetup.WeaponTypes.Clear();
            _spaceShipSetup.WeaponTypes.AddRange(_weaponSelectionSlots.Select(slot => slot.SelectedWeaponType));
        }
        
        private void OnSpaceShipTypeSelected()
        {
            _spaceShipSetup.SpaceShipType = _spaceShipSelectionSlot.SelectedSpaceShipType;
            int maxWeaponSlots = _staticDataService.GetSpaceShipDescriptor(_spaceShipSetup.SpaceShipType).WeaponSlotsCount;

            IEnumerable<WeaponType> weapons = _spaceShipSetup.WeaponTypes.Where((t, i) => i < maxWeaponSlots).ToList();

            _spaceShipSetup.WeaponTypes.Clear();
            _spaceShipSetup.WeaponTypes.AddRange(weapons);
            UpdateSlots();
        }

        private void RandomizeSpaceShipSetup()
        {
            _randomSetupService.RandomizeSpaceShipSetup(_spaceShipSetup);
            LoadDataInUI();
        }
    }
}

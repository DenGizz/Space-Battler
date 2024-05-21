using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.UI.NewUi.SlotViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.NewUi.SpaceShipSetupEditPanel
{
    public class SpaceShipSetupEditViewModel : MonoBehaviour
    {
        [SerializeField] private SpaceShipTypeSlotViewModel _spaceShipTypeSlotViewModel;
        [SerializeField] private Transform _weaponSlotViewModelsContainer;

        [SerializeField] private GameObject _weaponTypeSlotViewModelPrefab; //TODO: Use factory instead of prefab

        private List<WeaponTypeSlotViewModel> _weaponTypeSlotViewModels = new List<WeaponTypeSlotViewModel>();

        private SpaceShipSetup _spaceShipSetup;

        private IUiFactory _uiFactory;
        private IStaticDataService _staticDataService;
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(IUiFactory uiFactory, IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public void Inialize(SpaceShipSetup spaceShipSetup)
        {
            if(SpaceShipSetupValidator.IsSpaceShipSetupValid(spaceShipSetup, out string reason))
                throw new ArgumentException($"Space ship setup is invalid.{reason}");

            _spaceShipSetup = spaceShipSetup;
            _spaceShipTypeSlotViewModel.SelectedWeaponType = _spaceShipSetup.SpaceShipType;
            _spaceShipTypeSlotViewModel.OnSpaceShipTypeSelected += OnSpaceShipSelected;

            if (_spaceShipSetup.SpaceShipType == SpaceShipType.None)
                return;

            int avaliableSlots = _staticDataService.GetSpaceShipDescriptor(_spaceShipSetup.SpaceShipType).WeaponSlotsCount;
            CreateWeaponSlots(avaliableSlots);

            for (int i = 0; i < avaliableSlots; i++)
                _weaponTypeSlotViewModels[i].SelectedWeaponType = _spaceShipSetup.WeaponTypes.ElementAt(i);
        }


        private void CreateWeaponSlots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var slot = CreateWeaponSlot();
                _weaponTypeSlotViewModels.Add(slot);
                slot.OnWeaponTypeSelected += OnWeaponTypeSelected;
            }
        }

        private WeaponTypeSlotViewModel CreateWeaponSlot()
        {
            GameObject gameObject = _instantiator.InstantiatePrefab(_weaponTypeSlotViewModelPrefab.gameObject, _weaponSlotViewModelsContainer);
            return gameObject.GetComponent<WeaponTypeSlotViewModel>();
        }

        private void DestroyAllWeaponSlots() 
        {
            _weaponTypeSlotViewModels.ForEach(slot => slot.OnWeaponTypeSelected -= OnWeaponTypeSelected);
            _weaponTypeSlotViewModels.Clear();
        }

        private void OnWeaponTypeSelected(WeaponType type)
        {
            _spaceShipSetup.WeaponTypes.Clear();
            _spaceShipSetup.WeaponTypes.AddRange(_weaponTypeSlotViewModels.Select(x => x.SelectedWeaponType));
        }

        private void OnSpaceShipSelected(SpaceShipType type)
        {
            _spaceShipSetup.SpaceShipType = type;
            _spaceShipSetup.WeaponTypes.Clear();
            DestroyAllWeaponSlots();

            if (type == SpaceShipType.None)
                return;

            int avaliableSlots = _staticDataService.GetSpaceShipDescriptor(_spaceShipSetup.SpaceShipType).WeaponSlotsCount;
            CreateWeaponSlots(avaliableSlots);
        }
    }
}

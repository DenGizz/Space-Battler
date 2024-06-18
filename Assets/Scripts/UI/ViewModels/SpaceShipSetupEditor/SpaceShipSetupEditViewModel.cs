using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.SpaceShipSetupEditor
{
    public class SpaceShipSetupEditViewModel : MonoBehaviour
    {
        [SerializeField] private SpaceShipTypeSlotViewModel _spaceShipTypeSlotViewModel;
        [SerializeField] private Transform _weaponSlotViewModelsContainer;

        private List<WeaponTypeSlotViewModel> _weaponTypeSlotViewModels = new List<WeaponTypeSlotViewModel>();

        private SpaceShipSetup _spaceShipSetup;

        private IUiElementsFactory _uiFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory, IStaticDataService staticDataService)
        {
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        public void SetSpaceShipSetupForEdit(SpaceShipSetup spaceShipSetup)
        {
            /*
            if(SpaceShipSetupValidator.IsSpaceShipSetupValid(spaceShipSetup, out string reason))
                throw new ArgumentException($"Space ship setup is invalid.{reason}")*/

            if(_spaceShipSetup != null)
            {
                _spaceShipTypeSlotViewModel.OnOptionSelected -= OnSpaceShipSelected;
            }

            _spaceShipSetup = spaceShipSetup;

            _spaceShipTypeSlotViewModel.SetOptions(CreateSpaceShipTypeSlotOptions(), SpaceShipType.None, _spaceShipSetup.SpaceShipType);
            _spaceShipTypeSlotViewModel.OnOptionSelected += OnSpaceShipSelected;

            DestroyAllWeaponSlots();

            if (_spaceShipSetup.SpaceShipType == SpaceShipType.None)
                return;

            int avaliableSlots = _staticDataService.GetSpaceShipDescriptor(_spaceShipSetup.SpaceShipType).WeaponSlotsCount;
            CreateWeaponSlots(avaliableSlots, _spaceShipSetup.WeaponTypes);
        }

        private void CreateWeaponSlots(int count, IEnumerable<WeaponType> selectedOptions = null)
        {
            var slotOptions = CreateWeaponTypeSlotOptions();
            var selectedOptionsArray = selectedOptions?.ToArray();

            for (int i = 0; i < count; i++)
            {
                var slot = _uiFactory.CreateWeaponTypeSlot(_weaponSlotViewModelsContainer, slotOptions, WeaponType.None, WeaponType.None);

                if(selectedOptionsArray != null &&  i < selectedOptionsArray.Length)
                    slot.SelectedOption = selectedOptionsArray[i];

                _weaponTypeSlotViewModels.Add(slot);
                slot.OnOptionSelected += OnWeaponTypeSelected;
            }
        }

        private IEnumerable<WeaponType> CreateWeaponTypeSlotOptions()
        {
            List<WeaponType> options = new List<WeaponType> { WeaponType.None };
            options.AddRange(_staticDataService.GetWeaponDescriptors().Select(x => x.WeaponType));
            return options;
        }

        private IEnumerable<SpaceShipType> CreateSpaceShipTypeSlotOptions()
        {
            List<SpaceShipType> options = new List<SpaceShipType> { SpaceShipType.None };
            options.AddRange(_staticDataService.GetSpaceShipDescriptors().Select(x => x.SpaceShipType));
            return options;
        }

        private void DestroyAllWeaponSlots() 
        {
            _weaponTypeSlotViewModels.ForEach(slot => slot.OnOptionSelected -= OnWeaponTypeSelected);
            _weaponTypeSlotViewModels.ForEach(slot => Destroy(slot.gameObject));
           _weaponTypeSlotViewModels.Clear();
        }

        private void OnWeaponTypeSelected(WeaponType type)
        {
            _spaceShipSetup.WeaponTypes.Clear();
            _spaceShipSetup.WeaponTypes.AddRange(_weaponTypeSlotViewModels.Select(x => x.SelectedOption));
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

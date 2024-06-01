using System;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;

namespace Assets.Scripts.UI.ViewModels.SlotViewModels
{
    public class WeaponTypeSlotViewModel : ItemSlotViewModel<WeaponType>
    {
        private IWeaponTypeViewModel _weaponTypeViewModel;

        override public WeaponType SelectedOption
        {
            get => base.SelectedOption;
            set
            {
                base.SelectedOption = value;
                _weaponTypeViewModel.WeaponType = value;
            }
        }

        private void Awake()
        {
            _weaponTypeViewModel = GetComponentInParent<IWeaponTypeViewModel>() ?? throw new NullReferenceException("WeaponTypeViewModel not found");
        }
    }
}

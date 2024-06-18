using System;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;

namespace Assets.Scripts.UI.ViewModels.SlotViewModels
{
    public class SpaceShipTypeSlotViewModel : SelectOptionViewModel<SpaceShipType>
    {
        private ISpaceShipViewModel _spaceShipViewModel;

        override public SpaceShipType SelectedOption
        {
            get => base.SelectedOption;
            set
            {
                base.SelectedOption = value;
                _spaceShipViewModel.SpaceShipType=value;
            }
        }

        private void Awake()
        {
            _spaceShipViewModel = GetComponentInParent<ISpaceShipViewModel>() ?? throw new NullReferenceException("SpaceShipViewModel not found");
        }
    }
}

using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.ItemSelectionViewModels;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.NewUi.SlotViewModels
{
    [RequireComponent(typeof(SpaceShipTypeViewModel), typeof(ClickableView))]
    public class SpaceShipTypeSlotViewModel : MonoBehaviour
    {
        private SpaceShipTypeViewModel _spaceShipTypeViewModel;
        private ClickableView _clickableView;

        private SelectSpaceShipPanelViewModel _selectionViewModel;

        public SpaceShipType SelectedWeaponType
        {
            get => _spaceShipTypeViewModel.SpaceShipType;
            set
            {
                _spaceShipTypeViewModel.SpaceShipType = value;
                OnSpaceShipTypeSelected?.Invoke(value);
            }
        }

        public event Action<SpaceShipType> OnSpaceShipTypeSelected;

        private void Awake()
        {
            _spaceShipTypeViewModel = GetComponent<SpaceShipTypeViewModel>();
            _clickableView = GetComponent<ClickableView>();

            _clickableView.OnClicked += OnClick;
            _selectionViewModel.OnCloseButtonClicked += OnSelectionCloseButtonClicked;
            _selectionViewModel.OnItemSelected += OnSelectionPaneSpaceShipTypeSelected;
        }

        private void OnClick(ClickableView clickSource)
        {
            _selectionViewModel = null; // create viea factory
        }

        private void OnSelectionCloseButtonClicked()
        {
            _selectionViewModel = null; // destrpy viea destroyer
        }

        private void OnSelectionPaneSpaceShipTypeSelected(SpaceShipTypeViewModel selectedWeaponView)
        {
            SelectedWeaponType = selectedWeaponView.SpaceShipType;
        }
    }
}

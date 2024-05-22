using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.SelectionPanels;
using Assets.Scripts.UI.WeaponViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;
using Assets.Scripts.UI.NewUi.WeaponViewModels;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Zenject;

namespace Assets.Scripts.UI.NewUi
{
    [RequireComponent(typeof(WeaponTypeViewModel), typeof(ClickableView))]
    public class WeaponTypeSlotViewModel : MonoBehaviour
    {
        private WeaponTypeViewModel _weaponTypeViewModel;
        private ClickableView _clickableView;

        private SelectionGrid _selectionGrid;
        private WindowPanel _weaponSelectionWindow;

        public WeaponType SelectedWeaponType
        {
            get => _weaponTypeViewModel.WeaponType;
            set
            {
                _weaponTypeViewModel.WeaponType = value;
                OnWeaponTypeSelected?.Invoke(value);
            }
        }

        public event Action<WeaponType> OnWeaponTypeSelected;

        private IUiElementsFactory _uiFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _weaponTypeViewModel = GetComponent<WeaponTypeViewModel>();
            _clickableView = GetComponent<ClickableView>();

            _clickableView.OnClicked += OnClick;
        }

        private void OnClick(ClickableView clickSource)
        {
            CreateWindow();
        }

        private void CreateWindow()
        {
            _weaponSelectionWindow = _uiFactory.CreateWeaponTypeSelectionWindowPanel(out _selectionGrid);
            _weaponSelectionWindow.OnCloseButtonClicked += OnCloseButtonClicked;
            _selectionGrid.OnSelected += OnSelected;
        }

        private void CloseWindow()
        {
            _selectionGrid.OnSelected -= OnSelected;
            _weaponSelectionWindow.OnCloseButtonClicked -= OnCloseButtonClicked;

            Destroy(_weaponSelectionWindow);
            _weaponSelectionWindow = null;
            _selectionGrid = null;
        }

        private void OnCloseButtonClicked()
        {
            CloseWindow();
        }

        private void OnSelected(MonoBehaviour view)
        {
            SelectedWeaponType = (view as IWeaponTypeViewModel).WeaponType;
            CloseWindow();
        }
    }
}

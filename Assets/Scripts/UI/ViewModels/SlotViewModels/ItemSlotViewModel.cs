using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.ViewModels.SlotViewModels
{
    [RequireComponent(typeof(ClickableView))]
    public abstract class ItemSlotViewModel<TItem, TView> : MonoBehaviour where TView : MonoBehaviour
    {
        private ClickableView _clickableView;

        public event Action<TItem> OnItemSelected;

        protected TView _view;

        private WindowPanel _windowPanel;
        private SelectionGrid _selectionGrid;

        public TItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                UpdateView();
                OnItemSelected?.Invoke(value);
            }
        }

        private TItem _selectedItem;

        private void Awake()
        {
            _clickableView = GetComponent<ClickableView>();
            _view = GetComponent<TView>();

            _clickableView.OnClicked += OnClick;
        }

        private void OnClick(ClickableView clickSource)
        {
            OpenPanelWindow();
        }

        private void OpenPanelWindow()
        {
            //Open window via UiWindowsManager
            _windowPanel.OnCloseButtonClicked += OnWindowCloseButtonClickedEventHandler;
            _selectionGrid.OnSelected += OnSelectionGridItemSelectedEventHandler;

        }

        private void ClosePanelWindow()
        {
            //Close Window via UiWindowsManager
        }

        private void OnWindowCloseButtonClickedEventHandler()
        {
            _windowPanel.OnCloseButtonClicked -= OnWindowCloseButtonClickedEventHandler;
            _selectionGrid.OnSelected -= OnSelectionGridItemSelectedEventHandler;
        }

        protected void OnSelectionGridItemSelectedEventHandler(MonoBehaviour selectedView)
        {
            ClosePanelWindow();
            SelectedItem = SetSelectedItem(selectedView);
        }

        protected  abstract TItem SetSelectedItem(MonoBehaviour selectedView);
        protected abstract void UpdateView();

    }
}

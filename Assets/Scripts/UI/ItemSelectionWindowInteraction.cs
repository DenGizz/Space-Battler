using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.ViewModels.ItemSelectionViewModels
{
    [RequireComponent(typeof(ClickableView))]
    public abstract class ItemSelectionWindowInteraction<TOption> : MonoBehaviour
    {
        private ItemSlotViewModel<TOption> _itemSlotViewModel;
        private ClickableView _clickableView;

        private WindowPanel _windowPanel;
        private SelectionGrid _selectionGrid;

        private IUiWondowsService _uiWindowsService;
        private ILeFabric _leFabric;


        private void Awake()
        {
            _itemSlotViewModel = GetComponent<ItemSlotViewModel<TOption>>() ?? throw new MissingComponentException();
            _clickableView = GetComponent<ClickableView>();
            _clickableView.OnClicked += OnSlotClick;
        }

        private void OnSlotClick(MonoBehaviour clickedView)
        {
            OpenWindow();
        }

        private void OnGridElementSelected(MonoBehaviour selectedView)
        {
            CloseWindow();
            _itemSlotViewModel.SelectedOption = GetOptionFromView(selectedView);
        }


        private void OpenWindow()
        {
            _windowPanel = _uiWindowsService.OpenWindow();
            CreateAndSetWindowContent();
            _selectionGrid.OnSelected += OnGridElementSelected;
            _windowPanel.OnCloseButtonClicked += OnWindowClosed;
        }

        private void CloseWindow()
        {
            _uiWindowsService.CloseWindow(_windowPanel);
        }

        private void OnWindowClosed()
        {
            _windowPanel = null;
            _selectionGrid.OnSelected -= OnGridElementSelected;
            _windowPanel.OnCloseButtonClicked -= OnWindowClosed;
        }

        private void CreateAndSetWindowContent()
        {
            _selectionGrid = _leFabric.CreateSelectionGrid();
            var gridContent = CreateViewsForSlotOptions(_itemSlotViewModel.Options);
            _selectionGrid.SetContentViews(gridContent);
            _windowPanel.AddContent(_selectionGrid.gameObject);
        }

        protected abstract IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<TOption> options);
        protected abstract TOption GetOptionFromView(MonoBehaviour view);
    }


    interface IUiWondowsService
    {
        WindowPanel OpenWindow();
        void CloseWindow(WindowPanel windowPanel);
    }

    interface ILeFabric
    {
        SelectionGrid CreateSelectionGrid();
    }
}

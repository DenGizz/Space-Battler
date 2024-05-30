using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.UiInfrastructure;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.ItemSelectionViewModels
{
    [RequireComponent(typeof(ClickableView))]
    public abstract class ItemSelectionWindowInteraction<TOption> : MonoBehaviour
    {
        private ItemSlotViewModel<TOption> _itemSlotViewModel;
        private ClickableView _clickableView;

        private WindowPanel _windowPanel;
        private UiGrid _optionViewsGrid;

        private List<ClickableView> _optionsClickableViews;

        private IUiWindowsService _uiWindowsService;
        private IUiElementsFactory _uiElementsFactory;


        [Inject]
        public void Construct(IUiWindowsService uiWindowsService, IUiElementsFactory uiElementsFactory)
        {
            _uiWindowsService = uiWindowsService;
            _uiElementsFactory = uiElementsFactory;
            _optionsClickableViews = new List<ClickableView>();
        }

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
            _itemSlotViewModel.SelectedOption = GetOptionFromView(selectedView.gameObject);
        }


        private void OpenWindow()
        {
            _windowPanel = _uiWindowsService.OpenWindow();
            CreateAndSetWindowContent();
            _windowPanel.OnCloseButtonClicked += OnWindowClosed;
        }

        private void CloseWindow()
        {
            _uiWindowsService.CloseWindow(_windowPanel);
        }

        private void OnWindowClosed()
        {
            _windowPanel.OnCloseButtonClicked -= OnWindowClosed;
            _optionsClickableViews.ForEach(clickableView => clickableView.OnClicked -= OnGridElementSelected);
            _windowPanel = null;
        }

        private void CreateAndSetWindowContent()
        {
            _optionViewsGrid = _uiElementsFactory.CreateUiGrid();
            var gridContent = CreateViewsForSlotOptions(_itemSlotViewModel.Options);

            foreach (var view in gridContent)
                GetOrAddClickableViewComponent(view);

            _optionViewsGrid.SetContent(gridContent);
            _optionViewsGrid.SetCellSize(gridContent.First().GetComponent<RectTransform>().sizeDelta);
            _windowPanel.AddContent(_optionViewsGrid.gameObject);
        }

        private void GetOrAddClickableViewComponent(MonoBehaviour view)
        {
            ClickableView clickableView = view.gameObject.GetComponent<ClickableView>() ??
                                          view.gameObject.AddComponent<ClickableView>();

            clickableView.OnClicked += OnGridElementSelected;
            _optionsClickableViews.Add(clickableView);
        }

        protected abstract IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<TOption> options);
        protected abstract TOption GetOptionFromView(GameObject viewGameObject);
    }
}

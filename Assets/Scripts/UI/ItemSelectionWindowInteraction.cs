using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.UiElements;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(ClickableView))]
    public abstract class ItemSelectionWindowInteraction<TOption> : MonoBehaviour
    {
        private ItemSlotViewModel<TOption> _itemSlotViewModel;
        private ClickableView _clickableView;

        private UiWindow _uiWindow;
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
            _uiWindow = _uiWindowsService.OpenWindow();
            CreateAndSetWindowContent();
            _uiWindow.OnCloseButtonClicked += OnUiWindowClosed;
        }

        private void CloseWindow()
        {
            _uiWindowsService.CloseWindow(_uiWindow);
        }

        private void OnUiWindowClosed()
        {
            _uiWindow.OnCloseButtonClicked -= OnUiWindowClosed;
            _optionsClickableViews.ForEach(clickableView => clickableView.OnClicked -= OnGridElementSelected);
            _uiWindow = null;
        }

        private void CreateAndSetWindowContent()
        {
            _optionViewsGrid = _uiElementsFactory.CreateUiGrid();
            var gridContent = CreateViewsForSlotOptions(_itemSlotViewModel.Options);

            foreach (var view in gridContent)
                GetOrAddClickableViewComponent(view);

            _optionViewsGrid.SetContent(gridContent);
            _optionViewsGrid.SetCellSize(gridContent.First().GetComponent<RectTransform>().sizeDelta);
            _uiWindow.AddContent(_optionViewsGrid.gameObject);
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

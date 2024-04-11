using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.BaseUI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.WeaponSelectionUI
{
    public class SpaceShipSelectionPanelViewModel : MonoBehaviour
    {
        [SerializeField] private ClickableViewsPanel _clickableViewsPanel;

        public event Action OnCloseButtonClicked;
        public event Action<SpaceShipType> OnSpaceShipSelected;

        private Dictionary<GameObject, SpaceShipType> _viewToType;
        private List<ClickableView> _clickableViews;

        private IUIFactory _uiFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IUIFactory uiFactory, IStaticDataService staticDataService)
        {
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        private void Start()
        {
            _clickableViewsPanel.OnCloseButtonClicked += OnCloseButtonClickedEventHandler;
            _clickableViews = new List<ClickableView>();
            _viewToType = new Dictionary<GameObject, SpaceShipType>();

            IEnumerable<SpaceShipDescriptor> configs = _staticDataService.GetSpaceShipDescriptors();

            foreach (var config in configs)
            {
                DescriptionRowView descriptionRow = _uiFactory.CreateSpaceShipDescriptionRowView();
                descriptionRow.TitleText = config.SpaceShipType.ToString();
                descriptionRow.DescriptionText = $"HP: {config.MaxHealth}\nWeapon slots: {config.WeaponSlotsCount}";
                descriptionRow.Sprite = config.Sprite;
                _clickableViewsPanel.AddContent(descriptionRow.gameObject);
                _viewToType.Add(descriptionRow.gameObject, config.SpaceShipType);

                if(descriptionRow.TryGetComponent(out ClickableView clickable))
                {
                    _clickableViews.Add(clickable);
                    clickable.OnClicked += OnRowClickedEventHandler;
                }
            }

        }

        private void OnCloseButtonClickedEventHandler()
        {
            OnCloseButtonClicked?.Invoke();
        }

        private void OnRowClickedEventHandler(ClickableView row)
        {
            OnSpaceShipSelected?.Invoke(_viewToType[row.gameObject]);
        }
    }
}

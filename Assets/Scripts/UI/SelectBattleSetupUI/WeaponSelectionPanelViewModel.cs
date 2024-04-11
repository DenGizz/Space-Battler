using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.WeaponSelectionUI
{
    public class WeaponSelectionPanelViewModel : MonoBehaviour
    {
        [SerializeField] private ClickableViewsPanel _clickableViewsPanel;

        public event Action OnCloseButtonClicked;
        public event Action<WeaponType> OnWeaponSelected;

        private Dictionary<GameObject, WeaponType> _viewToType;
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
            _viewToType = new Dictionary<GameObject, WeaponType>();

            IEnumerable<WeaponDescriptor> configs = _staticDataService.GetWeaponDescriptors();

            foreach (var config in configs)
            {
                DescriptionRowView descriptionRow = _uiFactory.CreateWeaponDescriptionRowView();
                descriptionRow.TitleText = config.WeaponType.ToString();
                descriptionRow.DescriptionText = $"Damage: {config.Damage}.\nCold down: {config.ColdDownTime} sec.";
                descriptionRow.Sprite = config.Sprite;
                _clickableViewsPanel.AddContent(descriptionRow.gameObject);
                _viewToType.Add(descriptionRow.gameObject, config.WeaponType);

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
            OnWeaponSelected?.Invoke(_viewToType[row.gameObject]);
        }
    }
}

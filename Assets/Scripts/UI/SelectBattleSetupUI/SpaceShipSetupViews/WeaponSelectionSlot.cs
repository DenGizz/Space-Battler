using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.UI.BaseUI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews
{
    public class WeaponSelectionSlot : MonoBehaviour
    {
        [SerializeField] private WeaponTypeView _weaponTypeView;
        [SerializeField] private ClickableView _weaponTypeClickableView;

        private WeaponSelectionPanelViewModel _selectionPanel;


        public WeaponType SelectedWeaponType
        {
            get => _weaponTypeView.WeaponType;
            set => _weaponTypeView.WeaponType = value;
        }

        private IUiFactory _uiFactory;

        [Inject]
        public void Construct(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _weaponTypeClickableView.OnClicked += OnWeaponTypeClick;
        }

        private void OnWeaponTypeClick(ClickableView view)
        {
            _selectionPanel = _uiFactory.CreateWeaponSelectionPanel();
            _selectionPanel.OnWeaponSelected += OnWeaponSelectedEventHandler;
            _selectionPanel.OnCloseButtonClicked += OnSelectionPanelCloseButtonClickedEventHandler;
        }

        private void OnWeaponSelectedEventHandler(WeaponType type)
        {
            SelectedWeaponType = type;
            CloseSelectionPanel();

        }

        private void OnSelectionPanelCloseButtonClickedEventHandler()
        {
            CloseSelectionPanel();
        }

        private void CloseSelectionPanel()
        {
            _selectionPanel.OnCloseButtonClicked -= OnSelectionPanelCloseButtonClickedEventHandler;
            Destroy(_selectionPanel.gameObject);
            _selectionPanel = null;
        }
    }
}


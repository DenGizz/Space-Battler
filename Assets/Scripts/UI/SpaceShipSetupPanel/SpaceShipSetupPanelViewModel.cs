using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class SpaceShipSetupPanelViewModel : MonoBehaviour
{
    [SerializeField] private RectTransform _contentContainer;
    [SerializeField] private SlotForSelectSpaceShipViewModel _slotForSelectSpaceShip;

    public IEnumerable<WeaponType> SelectedWeaponTypes => _slots.Select(slot => slot.SelectedWeaponType);
    public SpaceShipType? SpaceShipType => _slotForSelectSpaceShip.SelectedSpaceShipType;

    private List<SlotForSelectWeaponViewModel> _slots = new List<SlotForSelectWeaponViewModel>();

    private IUIFactory _uiFactory;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IUIFactory uiFactory, IStaticDataService staticDataService)
    {
        _uiFactory = uiFactory;
        _staticDataService = staticDataService;
    }

    private void Awake()
    {
        _slotForSelectSpaceShip.OnSpaceShipTypeSelected += OnSpaceShipTypeSelectedEventHandler;
    }

    private void SetWeaponSlotsCount(int slotsCount)
    {
        foreach (var slot in _slots)
        {
            Destroy(slot.gameObject);
        }

        _slots.Clear();

        for (int i = 0; i < slotsCount; i++)
        {
            SlotForSelectWeaponViewModel slot = _uiFactory.CreateSlotForSelectWeaponViewPanel();
            slot.gameObject.transform.SetParent(_contentContainer);
            _slots.Add(slot);
        }
    }


    private void OnSpaceShipTypeSelectedEventHandler(SpaceShipType spaceShipType)
    {
        int weaponSlots = _staticDataService.GetSpaceShipConfig(spaceShipType).WeaponSlots;
        SetWeaponSlotsCount(weaponSlots);
    }
}

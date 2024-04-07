using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
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

    [Inject]
    public void Construct(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }


    private void Start()
    {
        SetWeaponSlotsCount(6);
    }

    public void SetWeaponSlotsCount(int slotsCount)
    {
        foreach (var slot in _slots)
        {
            Destroy(slot.gameObject);
        }

        for (int i = 0; i < slotsCount; i++)
        {
            SlotForSelectWeaponViewModel slot = _uiFactory.CreateSlotForSelectWeaponViewPanel();
            slot.gameObject.transform.SetParent(_contentContainer);
            _slots.Add(slot);
        }
    }


}

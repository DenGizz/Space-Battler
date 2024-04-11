using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Services;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SpaceShipSetupPresenter : MonoBehaviour
{
    [SerializeField] private SpaceShipSelectionSlot _spaceShipSelectionSlot;
    [SerializeField] private List<WeaponSelectionSlot> _weaponSelectionSlots;
    [SerializeField] private Button _randomizeButton;

    private IRandomSetupService _randomSetupService;

    public SpaceShipType SpaceShipType
    {
        get => _spaceShipSelectionSlot.SelectedSpaceShipType;
        set
        {
            _spaceShipSelectionSlot.SelectedSpaceShipType = value;
        }
    }

    public IEnumerable<WeaponType> WeaponTypes
    {
        get => _weaponSelectionSlots.Select(slot => slot.SelectedWeaponType).Where(weaponType => weaponType != WeaponType.None);
        set
        {
            int i = 0;
            foreach (var weaponType in value)
            {
                _weaponSelectionSlots[i].SelectedWeaponType = weaponType;
                i++;
            }
        }
    }

    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService, IRandomSetupService randomSetupService)
    {
        _staticDataService = staticDataService;
        _randomSetupService = randomSetupService;
    }

    private void Awake()
    {
        ClearData();
        _spaceShipSelectionSlot.OnSelectedSpaceShipTypeChanged += OnSelectedSpaceShipTypeChangedEventHandler;

        _randomizeButton.onClick.AddListener(OnRandomizeButtonClicked);
    }

    public void ClearData()
    {
        foreach (var weaponSelectionSlot in _weaponSelectionSlots)
        {
            weaponSelectionSlot.SelectedWeaponType = WeaponType.None;
            weaponSelectionSlot.gameObject.SetActive(false);
        }

        _spaceShipSelectionSlot.SelectedSpaceShipType = SpaceShipType.None;
    }

    private void SetWeaponSelectionSlotVidibility(int visibleSlotsCount)
    {
        for (int i = 0; i < _weaponSelectionSlots.Count; i++)
        {
            _weaponSelectionSlots[i].gameObject.SetActive(i < visibleSlotsCount);
        }
    }

    private void OnSelectedSpaceShipTypeChangedEventHandler()
    {
        SetWeaponSelectionSlotVidibility(_staticDataService.GetSpaceShipDescriptor(_spaceShipSelectionSlot.SelectedSpaceShipType).WeaponSlotsCount);

        foreach (var weaponSelectionSlot in _weaponSelectionSlots)
            weaponSelectionSlot.SelectedWeaponType = WeaponType.None;
    }

    private void OnRandomizeButtonClicked()
    {
        SpaceShipSetup spaceShipSetup = _randomSetupService.GetRandomSpaceShipSetup();
        SpaceShipType = spaceShipSetup.SpaceShipType;
        WeaponTypes = spaceShipSetup.WeaponTypes;
    }

    private void OnDestroy()
    {
        _spaceShipSelectionSlot.OnSelectedSpaceShipTypeChanged -= OnSelectedSpaceShipTypeChangedEventHandler;
    }
}

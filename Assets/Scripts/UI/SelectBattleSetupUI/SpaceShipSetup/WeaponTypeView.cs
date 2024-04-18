using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class WeaponTypeView : MonoBehaviour
{
    public WeaponType WeaponType
    {
        get => _weaponType;
        set
        {
            _weaponType = value;
            UpdateView();
        }
    }

    [SerializeField] private SpriteView _spriteView;
    private WeaponType _weaponType = WeaponType.None;

    private  IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
        _weaponType = WeaponType.None;
        _staticDataService = staticDataService;
    }

    private void UpdateView()
    {
        if (_weaponType == WeaponType.None)
        {
            _spriteView.Sprite = null;
            return;
        }

        WeaponDescriptor descriptor = _staticDataService.GetWeaponDescriptor(_weaponType);
        _spriteView.Sprite = descriptor.Sprite;
    }
}

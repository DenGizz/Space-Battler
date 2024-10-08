using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.WeaponViewModels
{
    [RequireComponent(typeof(SpriteView))]
    public class WeaponTypeViewModel : MonoBehaviour, IWeaponTypeViewModel
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

        private SpriteView _spriteView;
        private WeaponType _weaponType = WeaponType.None;

        protected  IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _weaponType = WeaponType.None;
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            _spriteView = GetComponent<SpriteView>();
        }

        protected virtual void UpdateView()
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
}

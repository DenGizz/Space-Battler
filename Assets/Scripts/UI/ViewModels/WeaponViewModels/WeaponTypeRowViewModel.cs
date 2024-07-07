using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Localization;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using System.Text;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.WeaponViewModels
{
    [RequireComponent(typeof(DescriptionRowView))]
    public class WeaponTypeRowViewModel : MonoBehaviour, IWeaponTypeViewModel
    {
        [SerializeField] private WeaponTypeViewModel _weaponTypeViewModel;
        private DescriptionRowView _descriptionRowView;
        public WeaponType WeaponType
        {
            get => _weaponTypeViewModel.WeaponType;
            set
            {
                _weaponTypeViewModel.WeaponType = value;
                UpdateDescription();
            }
        }
        private IStaticDataService _staticDataService;
        private IStringLocalizer _stringLocalizer;

        [Inject]
        public void Construct(IStaticDataService staticDataService, IStringLocalizer stringLocalizer) 
        {
            _staticDataService = staticDataService;
            _stringLocalizer = stringLocalizer;
        }  

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
            _stringLocalizer.LanguageSelected += ChangeLanguageEventHandler;
        }

        private void OnDestroy()
        {
            _stringLocalizer.LanguageSelected -= ChangeLanguageEventHandler;
        }

        private void UpdateDescription()
        {
            if(WeaponType == WeaponType.None)
            {
                ClearView();
                return;
            }

            _descriptionRowView.TitleText = CreateTitle(WeaponType);
            _descriptionRowView.DescriptionText = CreateDescription(WeaponType);
        }

        private string CreateTitle(WeaponType type)
        {
            string spaceShipNameKey = _staticDataService.GetWeaponDescriptor(type).NameKey;
            return _stringLocalizer.GetLocalizedString(spaceShipNameKey);
        }

        private string CreateDescription(WeaponType type)
        {
            float damageValue = _staticDataService.GetWeaponDescriptor(type).Damage;
            float colddownValue = _staticDataService.GetWeaponDescriptor(type).ColdDownTime;

            string damageText = _stringLocalizer.GetLocalizedString("weapon_description_damage");
            string colddownText = _stringLocalizer.GetLocalizedString("weapon_description_colddown");
            string shortSecondsText = _stringLocalizer.GetLocalizedString("short_seconds");


            return $"{damageText}: {damageValue}.\n{colddownText}: {colddownValue} {shortSecondsText}.";
        }

        private void ClearView()
        {
            _descriptionRowView.TitleText = string.Empty;
            _descriptionRowView.DescriptionText = string.Empty;
        }

        private void ChangeLanguageEventHandler(LanguageKey key) 
        {
            UpdateDescription();
        }
    }
}

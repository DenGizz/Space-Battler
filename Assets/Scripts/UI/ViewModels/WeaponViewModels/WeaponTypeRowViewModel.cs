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
        private ILocalizationService _localizationService;

        [Inject]
        public void Construct(IStaticDataService staticDataService, ILocalizationService localizationService) 
        {
            _staticDataService = staticDataService;
            _localizationService = localizationService;
        }  

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
            _localizationService.LanguageSelected += ChangeLanguageEventHandler;
        }

        private void OnDestroy()
        {
            _localizationService.LanguageSelected -= ChangeLanguageEventHandler;
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
            return _localizationService.GetLocalizedString(spaceShipNameKey);
        }

        private string CreateDescription(WeaponType type)
        {
            float damageValue = _staticDataService.GetWeaponDescriptor(type).Damage;
            float colddownValue = _staticDataService.GetWeaponDescriptor(type).ColdDownTime;

            string damageText = _localizationService.GetLocalizedString("weapon_description_damage");
            string colddownText = _localizationService.GetLocalizedString("weapon_description_colddown");
            string shortSecondsText = _localizationService.GetLocalizedString("short_seconds");


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

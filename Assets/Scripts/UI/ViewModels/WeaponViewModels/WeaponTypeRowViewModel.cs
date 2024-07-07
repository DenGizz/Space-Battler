using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
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
        private ILocalizationService _localizationService;
        private IStringContentFactory _stringContentFactory;

        [Inject]
        public void Construct(ILocalizationService localizationService, IStringContentFactory stringContentFactory)
        {
            _localizationService = localizationService;
            _stringContentFactory = stringContentFactory;
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

            _descriptionRowView.TitleText = _stringContentFactory.CreateWeaponName(WeaponType);
            _descriptionRowView.DescriptionText = _stringContentFactory.CreateWeaponDescription(WeaponType);
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

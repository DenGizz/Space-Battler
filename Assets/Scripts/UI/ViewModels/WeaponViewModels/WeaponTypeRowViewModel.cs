using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
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

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }  

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
        }

        private void UpdateDescription()
        {
            _descriptionRowView.TitleText = GetTitle(WeaponType);
            _descriptionRowView.DescriptionText = GetDescription(WeaponType);
        }

        private string GetTitle(WeaponType type)
        {
            return type == WeaponType.None ? "" : _staticDataService.GetWeaponDescriptor(type).WeaponType.ToString();
        }

        private string GetDescription(WeaponType type)
        {
            return type == WeaponType.None ? "" : $"Damage: {_staticDataService.GetWeaponDescriptor(type).Damage}.\nCold down: {_staticDataService.GetWeaponDescriptor(type).ColdDownTime} sec.";
        }

    }
}

using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class LocalizedStringContentFactory : IStringContentFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ILocalizationService _localizationService;

        public LocalizedStringContentFactory(IStaticDataService staticDataService, ILocalizationService localizationService)
        {
            _staticDataService = staticDataService;
            _localizationService = localizationService;
        }

        public string CreateSpaceShipDescription(SpaceShipType type)
        {
            float maxHealth = _staticDataService.GetSpaceShipDescriptor(type).MaxHealth;
            int weaponSlots = _staticDataService.GetSpaceShipDescriptor(type).WeaponSlotsCount;

            string localizedHpText = _localizationService.GetLocalizedString("space_ship_description_health");
            string localizedSlotsText = _localizationService.GetLocalizedString("space_ship_description_weapon_slots");
           
            return $"{localizedHpText}: {maxHealth}.\n{localizedSlotsText}: {weaponSlots}";
        }

        public string CreateSpaceShipName(SpaceShipType type)
        {
            string nameKey = _staticDataService.GetSpaceShipDescriptor(type).NameKey;
            return _localizationService.GetLocalizedString(nameKey);
        }

        public string CreateStringByKey(string stringKey)
        {
            return _localizationService.GetLocalizedString(stringKey);
        }

        public string CreateWeaponDescription(WeaponType type)
        {
            float damageValue = _staticDataService.GetWeaponDescriptor(type).Damage;
            float colddownValue = _staticDataService.GetWeaponDescriptor(type).ColdDownTime;

            string damageText = _localizationService.GetLocalizedString("weapon_description_damage");
            string colddownText = _localizationService.GetLocalizedString("weapon_description_colddown");
            string shortSecondsText = _localizationService.GetLocalizedString("short_seconds");


            return $"{damageText}: {damageValue}.\n{colddownText}: {colddownValue} {shortSecondsText}.";
        }

        public string CreateWeaponName(WeaponType type)
        {
            string spaceShipNameKey = _staticDataService.GetWeaponDescriptor(type).NameKey;
            return _localizationService.GetLocalizedString(spaceShipNameKey);
        }
    }
}

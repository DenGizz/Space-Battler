using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using System.Linq;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class RandomSetupService : IRandomSetupService
    {
        private readonly IStaticDataService _staticDataService;

        [Inject]
        public RandomSetupService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void RandomizeSpaceShipSetup(SpaceShipSetup spaceShipSetup)
        {
            SpaceShipDescriptor[] spaceShipDescriptors = _staticDataService.GetSpaceShipDescriptors().ToArray();
            WeaponDescriptor[] weaponDescriptors = _staticDataService.GetWeaponDescriptors().ToArray();

            int randomSpaceShipDescriptorIndex = UnityEngine.Random.Range(0, spaceShipDescriptors.Length);
            SpaceShipDescriptor randomSpaceShipDescriptor = spaceShipDescriptors[randomSpaceShipDescriptorIndex];
            WeaponDescriptor[] randomWeaponDescriptors = weaponDescriptors
                .OrderBy(weaponDescriptor => UnityEngine.Random.value).Take(UnityEngine.Random.Range(1, 4)).ToArray();

            spaceShipSetup.SpaceShipType = randomSpaceShipDescriptor.SpaceShipType;
            spaceShipSetup.WeaponTypes.Clear();
            spaceShipSetup.WeaponTypes.AddRange(randomWeaponDescriptors.Select(weaponDescriptor => weaponDescriptor.WeaponType));

        }
    }
}

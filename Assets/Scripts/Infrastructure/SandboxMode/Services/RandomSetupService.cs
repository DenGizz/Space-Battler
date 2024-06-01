using System.Linq;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.ScriptableObjects;
using Zenject;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
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
            SpaceShipType randomSpaceShipType = PickRandomSpaceShipType();

            int awaliableWeaponSlots = _staticDataService.GetSpaceShipDescriptor(randomSpaceShipType).WeaponSlotsCount;


            var randomWeaponTypes = PickRandomWeaponTypes(awaliableWeaponSlots);

            spaceShipSetup.SpaceShipType = randomSpaceShipType;
            spaceShipSetup.WeaponTypes.Clear();
            spaceShipSetup.WeaponTypes.AddRange(randomWeaponTypes);
        }

        private  SpaceShipType PickRandomSpaceShipType()
        {
            SpaceShipDescriptor[] spaceShipDescriptors = _staticDataService.GetSpaceShipDescriptors().ToArray();
            int randomSpaceShipDescriptorIndex = UnityEngine.Random.Range(0, spaceShipDescriptors.Length);
            return spaceShipDescriptors[randomSpaceShipDescriptorIndex].SpaceShipType;
        }

        private WeaponType[] PickRandomWeaponTypes(int count)
        {
            WeaponDescriptor[] randomWeaponDescriptors = _staticDataService.GetWeaponDescriptors().ToArray();
            WeaponType[] randomWeaponTypes = new WeaponType[count];

            for (int i = 0; i < count; i++)
            {
                int randomWeaponDescriptorIndex = UnityEngine.Random.Range(0, randomWeaponDescriptors.Length);
                randomWeaponTypes[i] = randomWeaponDescriptors[randomWeaponDescriptorIndex].WeaponType;
            }

            return randomWeaponTypes;
        }
    }
}

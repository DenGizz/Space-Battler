using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SpaceShipSetup GetRandomSpaceShipSetup()
        {
            SpaceShipDescriptor[] spaceShipDescriptors = _staticDataService.GetSpaceShipDescriptors().ToArray();
            WeaponDescriptor[] weaponDescriptors = _staticDataService.GetWeaponDescriptors().ToArray();

            SpaceShipDescriptor randomSpaceShipDescriptor = spaceShipDescriptors[UnityEngine.Random.Range(0, spaceShipDescriptors.Length)];
            WeaponDescriptor[] randomWeaponDescriptors = weaponDescriptors.OrderBy(weaponDescriptor => UnityEngine.Random.value).Take(UnityEngine.Random.Range(1, 4)).ToArray();
            return new SpaceShipSetup(randomSpaceShipDescriptor.CorpusType, randomWeaponDescriptors.Select(weaponDescriptor => weaponDescriptor.WeaponType));
        }
    }
}

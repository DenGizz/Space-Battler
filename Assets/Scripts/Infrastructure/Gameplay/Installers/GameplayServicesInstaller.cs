using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
using Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using Assets.Scripts.Infrastructure.SandboxMode.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Installers
{
    [AddComponentMenu("Infrastructure/Gameplay Services Installer")]
    public class GameplayServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameLoopServices();
            BindBattleServices();
        }

        private void BindBattleServices()
        {
            Container.Bind<IBattleRunnerFactory>().To<BattleRunnerFactory>().AsSingle();
            Container.Bind<IFitSpaceShipsOnScreenService>().To<FitSpaceShipsOnScreenService>().AsSingle();
            Container.Bind<IRandomSetupService>().To<RandomSetupService>().AsSingle();
            Container.Bind<IBattleSetupProvider>().To<BattleSetupProvider>().AsSingle();
            Container.Bind<BattleTickService>().AsSingle();
            Container.Bind<IBattleTickService>().To<BattleTickService>().FromResolve();
            Container.Bind<ITickable>().To<BattleTickService>().FromResolve();
            Container.Bind<IBattleRunnerProvider>().To<BattleRunnerRunnerProvider>().AsSingle();
            Container.Bind<IBattleCleanUpService>().To<BattleCleanUpService>().AsSingle();
        }

        private void BindGameLoopServices()
        {
            Container.Bind<IProjectilesPoolService>().To<ProjectilesPoolService>().AsSingle();
            Container.Bind<IShrinkService>().To<ShrinkService>().AsSingle();
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
            Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
            Container.Bind<ICombatAiRegistry>().To<CombatAIRegistry>().AsSingle();
            Container.Bind<ISpaceShipDestroyer>().To<SpaceShipDestoyer>().AsSingle();
            Container.Bind<IWeaponDestroyer>().To<WeaponDestroyer>().AsSingle();
            Container.Bind<IProjectileDestroyer>().To<ProjectileDestroyer>().AsSingle();
            Container.Bind<IProjectilesRegister>().To<ProjectilesRegister>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
            Container.Bind<IWeaponAttachService>().To<WeaponAttachService>().AsSingle();
            Container.Bind<IGameObjectRegistry>().To<GameObjectsRegistry>().AsSingle();
        }
    }
}
 
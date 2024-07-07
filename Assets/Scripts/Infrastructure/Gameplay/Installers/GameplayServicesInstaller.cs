using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
using Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using Assets.Scripts.Infrastructure.SandboxMode.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
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

            Container.Bind<BattleSetupValidator>().ToSelf().AsSingle();
        }

        private void BindBattleServices()
        {
            Container.Bind<IBattleRunnerFactory>().To<BattleRunnerFactory>().AsSingle();
            Container.Bind<IFitSpaceShipsOnScreenService>().To<FitSpaceShipsOnScreenService>().AsSingle();
            Container.Bind<IRandomSetupService>().To<RandomSetupService>().AsSingle();
            Container.Bind<IBattleSetupProvider>().To<BattleSetupProvider>().AsSingle();
            Container.Bind<GameplayTickService>().AsSingle();
            Container.Bind<IGameplayTickService>().To<GameplayTickService>().FromResolve();
            Container.Bind<ITickable>().To<GameplayTickService>().FromResolve();
            Container.Bind<IBattleRunnerProvider>().To<BattleRunnerRunnerProvider>().AsSingle();
            Container.Bind<IBattleCleanUpService>().To<BattleCleanUpService>().AsSingle();
        }

        private void BindGameLoopServices()
        {
            Container.Bind<ISpaceShipRegistry>().To<SpaceShipRegistry>().AsSingle().NonLazy();
            Container.Bind<IProjectilesPoolService>().To<ProjectilesPoolService>().AsSingle();
            Container.Bind<IBattleSetupsShrinkService>().To<BattleSetupsShrinkService>().AsSingle();
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
            Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
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
 
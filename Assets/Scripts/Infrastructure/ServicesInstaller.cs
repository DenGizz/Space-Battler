using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.PersistentProgressServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/ServicesInstaller")]
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCoreServices();
            BindUnitsManagementServices();
            BindBattleServices();
            BindUiServices();

            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<IProjectilesPoolService>().To<ProjectilesPoolService>().AsSingle();
        }

        private void BindUnitsManagementServices()
        {
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
            Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
            Container.Bind<ICombatAiRegistry>().To<CombatAIRegistry>().AsSingle();
            Container.Bind<ISpaceShipDestroyer>().To<SpaceShipDestoyer>().AsSingle();
            Container.Bind<IWeaponDestroyer>().To<WeaponDestroyer>().AsSingle();
            Container.Bind<IProjectileDestroyer>().To<ProjectileDestroyer>().AsSingle();
            Container.Bind<IProjectilesRegister>().To<ProjectilesRegister>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
            Container.Bind<IWeaponAttachService>().To<WeaponAttachService>().AsSingle();
            Container.Bind<ISpaceShipFromSetupFactory>().To<SpaceShipFromSetupFactory>().AsSingle();
            Container.Bind<IRandomSetupService>().To<RandomSetupService>().AsSingle();
        }

        private void BindCoreServices()
        {
            Container.Bind<IPersistentDataService>().To<PersistentDataService>().AsSingle();
            Container.Bind<IRootTransformsProvider>().To<RootTransformsProvider>().AsSingle();
            Container.Bind<ISerializer>().To<NewtonJsonSerializer>().AsSingle();
            Container.Bind<IFileSystem>().To<FileSystem>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
            Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
            Container.Bind<IGameObjectRegistry>().To<GameObjectsRegistry>().AsSingle();
        }

        private void BindUiServices()
        {
            Container.Bind<IBattleUiService>().To<BattleUIService>().AsSingle();
            Container.Bind<IUiFactory>().To<UIFactory>().AsSingle();
        }

        private void BindBattleServices()
        {
            Container.Bind<IBattleProvider>().To<BattleProvider>().AsSingle();

            Container.Bind<IBattleSetupProvider>().To<BattleSetupProvider>().AsSingle();
            Container.Bind<IBattleFactory>().To<BattleFactory>().AsSingle();
            Container.Bind<IBattleCleanUpService>().To<BattleCleanUpService>().AsSingle();

            Container.Bind<IBattleObserver>().To<BattleObserver>().AsSingle();

            Container.Bind<BattleTickService>().AsSingle();
            Container.Bind<IBattleTickService>().To<BattleTickService>().FromResolve();
            Container.Bind<ITickable>().To<BattleTickService>().FromResolve();
        }
    }
}
 
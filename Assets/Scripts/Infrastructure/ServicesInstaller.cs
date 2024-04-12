using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
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
            BindBattleObserver();
            BindBattleServices();
            BindUI();

            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
            Container.Bind<IWeaponAttachService>().To<WeaponAttachService>().AsSingle();
            Container.Bind<ISpaceShipFromSetupFactory>().To<SpaceShipFromSetupFactory>().AsSingle();
            Container.Bind<IRandomSetupService>().To<RandomSetupService>().AsSingle();
            Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
        }

        private void BindUnitsManagementServices()
        {
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
            Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
            Container.Bind<IGameObjectRegistry>().To<GameObjectsRegistry>().AsSingle();
            Container.Bind<ICombatAiRegistry>().To<CombatAIRegistry>().AsSingle();
        }

        private void BindCoreServices()
        {
            Container.Bind<IRootTransformsProvider>().To<RootTransformsProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
        }

        private void BindUI()
        {
            Container.Bind<IBattleUiService>().To<BattleUIService>().AsSingle();
            Container.Bind<IUiFactory>().To<UIFactory>().AsSingle();
        }

        private void BindBattleServices()
        {
            Container.Bind<IBattleSetupProvider>().To<BattleSetupProvider>().AsSingle();
            Container.Bind<IBattleFactory>().To<BattleFactory>().AsSingle();
            Container.Bind<IBattleCleanUpService>().To<BattleCleanUpService>().AsSingle();
        }

        private void BindBattleObserver()
        {
            Container.Bind<BattleObserver>().AsSingle();
            Container.Bind<IBattleObserver>().To<BattleObserver>().FromResolve();
            Container.Bind<ITickable>().To<BattleObserver>().FromResolve();

            Container.Bind<BattleTickService>().AsSingle();
            Container.Bind<IBattleTickService>().To<BattleTickService>().FromResolve();
            Container.Bind<ITickable>().To<BattleTickService>().FromResolve();
        }
    }
}
 
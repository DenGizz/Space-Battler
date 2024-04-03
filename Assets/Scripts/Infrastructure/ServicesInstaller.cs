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
        }

        private void BindUnitsManagementServices()
        {
            Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
            Container.Bind<ISpaceShipsGameObjectRegistry>().To<SpaceShipsGameObjectsRegistry>().AsSingle();
            Container.Bind<ICombatAiRegistry>().To<CombatAIRegistry>().AsSingle();
            Container.Bind<ISpaceShipRegistry>().To<SpaceShipRegistry>().AsSingle();
        }

        private void BindCoreServices()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
        }

        private void BindUI()
        {
            Container.Bind<IBattleUIService>().To<BattleUIService>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindBattleServices()
        {
            Container.Bind<IBattleFactory>().To<BattleFactory>().AsSingle();
            Container.Bind<IBattleProvider>().To<BattleProvider>().AsSingle();
            Container.Bind<IBattleCleanUpServce>().To<BattleCleanUpService>().AsSingle();
        }

        private void BindBattleObserver()
        {
            Container.Bind<BattleObserver>().AsSingle();
            Container.Bind<IBattleObserver>().To<BattleObserver>().FromResolve();
            Container.Bind<ITickable>().To<BattleObserver>().FromResolve();
        }
    }
}
 
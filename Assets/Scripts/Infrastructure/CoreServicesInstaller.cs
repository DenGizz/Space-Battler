using System.Collections;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.PersistentDataServices;
using Assets.Scripts.Infrastructure.Services.PersistentProgressServices;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/Core Services Installer")]
    public class CoreServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<IPersistentDataService>().To<PersistentDataService>().AsSingle();
            Container.Bind<IRootTransformsProvider>().To<RootTransformsProvider>().AsSingle();
            Container.Bind<ISerializer>().To<NewtonJsonSerializer>().AsSingle();
            Container.Bind<IFileSystem>().To<FileSystem>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
            Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
        }
    }
}
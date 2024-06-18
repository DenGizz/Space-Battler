using Assets.Scripts.Infrastructure.Core.Factories;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Core.Services.AssetProviders;
using Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices;
using Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Core.Installers
{
    [AddComponentMenu("Infrastructure/Core Services Installer")]
    public class CoreInstaller : MonoInstaller
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
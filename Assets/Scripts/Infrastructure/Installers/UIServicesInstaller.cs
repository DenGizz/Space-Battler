using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders;
using Assets.Scripts.Infrastructure.UiInfrastructure;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/UI Services Installer")]
    public class UIServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUisProvider>().To<UisProvider>().AsSingle();
            Container.Bind<IUiWindowsService>().To<UiWindowsService>().AsSingle();
            Container.Bind<IUiAssetsProvider>().To<UiAssetsProvider>().AsSingle();
            Container.Bind<IUiFactory>().To<UiFactory>().AsSingle();
            Container.Bind<IUiElementsFactory>().To<UIElementsFactory>().AsSingle();
        }
    }
}
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.Infrastructure.Ui.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Installers
{
    [AddComponentMenu("Infrastructure/UI Services Installer")]
    public class UIServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPopoutMessagesService>().To<PopoutMessagesService>().AsSingle();
            Container.Bind<IHUDFactory>().To<HUDFactory>().AsSingle();
            Container.Bind<IHUDsProvider>().To<HUDsProvider>().AsSingle();
            Container.Bind<IUisProvider>().To<UisProvider>().AsSingle();
            Container.Bind<IUiWindowsService>().To<UiWindowsService>().AsSingle();
            Container.Bind<IUiAssetsProvider>().To<UiAssetsProvider>().AsSingle();
            Container.Bind<IUiFactory>().To<UiFactory>().AsSingle();
            Container.Bind<IUiElementsFactory>().To<UIElementsFactory>().AsSingle();
        }
    }
}
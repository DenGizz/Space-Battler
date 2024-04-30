using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/UI Services Installer")]
    public class UIServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBattleUiService>().To<BattleUIService>().AsSingle();
            Container.Bind<IUiFactory>().To<UIFactory>().AsSingle();
        }
    }
}
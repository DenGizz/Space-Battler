using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

[AddComponentMenu("Infrastructure/ServicesInstaller")]
public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBattleRunnerService>().To<BattleRunnerService>().AsSingle();
        Container.Bind<ISpaceShipFactory>().To<SpaceShipFactory>().AsSingle();
        Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
        Container.Bind<IBattleObserver>().To<BattleObserver>().AsSingle();
        Container.Bind<ICombatAIRegistry>().To<CombatAIRegistry>().AsSingle();
        Container.Bind<ISpaceShipRegistry>().To<SpaceShipRegistry>().AsSingle();
        Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
    }
}

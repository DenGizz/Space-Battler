using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Installers
{
    [AddComponentMenu("Infrastructure/GameInstaller")]
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Game.Game>().AsSingle();
        }
    }
}
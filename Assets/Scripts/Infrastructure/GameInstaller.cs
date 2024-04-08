using System.Collections;
using Assets.Scripts.Game.GameStateMachine;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
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
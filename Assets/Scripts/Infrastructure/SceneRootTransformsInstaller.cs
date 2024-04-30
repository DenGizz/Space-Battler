using Assets.Scripts.Infrastructure.Services.CoreServices;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/SceneRootTransformsInstaller")]
    public class SceneRootTransformsInstaller : MonoInstaller
    {
        [SerializeField] private Transform _uiRootTransform;
        [SerializeField] private Transform _spaceShipsRootTransform;
        [SerializeField] private Transform _projectilesRoot;

        public override void InstallBindings()
        {
            Container.Resolve<IRootTransformsProvider>().UIRoot = _uiRootTransform;
            Container.Resolve<IRootTransformsProvider>().SpaceShipsRoot = _spaceShipsRootTransform;
            Container.Resolve<IRootTransformsProvider>().ProjectilesRoot = _projectilesRoot;
        }

    }
}

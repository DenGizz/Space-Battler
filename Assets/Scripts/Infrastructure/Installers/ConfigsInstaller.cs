using Assets.Scripts.Infrastructure.Config;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    [AddComponentMenu("Infrastructure/ConfigsInstaller")]
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private ScenesConfig _scenesConfig;

        override public void InstallBindings()
        {
            Container.Bind<ScenesConfig>().FromScriptableObject(_scenesConfig).AsSingle();
        }
    }
}

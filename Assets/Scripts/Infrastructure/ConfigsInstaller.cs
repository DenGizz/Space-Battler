using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Container.Bind<ScenesConfig>().FromScriptableObject(_scenesConfig);
        }
    }
}

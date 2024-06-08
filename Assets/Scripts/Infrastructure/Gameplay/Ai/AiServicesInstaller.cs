using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Ai
{
    [AddComponentMenu("Infrastructure/Gameplay/AiServicesInstaller")]
    public class AiServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAiAssignService>().To<AiAssignService>().AsSingle();
            Container.Bind<IAiStrategyFactory>().To<AiStrategyFactory>().AsSingle();
        }
    }
}

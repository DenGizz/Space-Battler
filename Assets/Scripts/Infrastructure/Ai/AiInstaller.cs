using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ai
{
    [CreateAssetMenu(fileName = "AiInstaller", menuName = "Infrastructure/Ai/Installers/AiInstaller")]
    public class AiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAiAssignService>().To<AiAssignService>().AsSingle();
        }
    }
}

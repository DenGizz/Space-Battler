using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Localization
{
    public class LocalizationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILocalizationDb>().To<LocalizationDb>().AsSingle();
            Container.Bind<IStringLocalizer>().To<StringLocalizer>().AsSingle();
        }
    }
}

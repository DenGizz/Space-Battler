using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.UiInfrastructure
{
    public interface IUisProvider
    {
        Ui SandboxModeUi { get; set; }
    }
}

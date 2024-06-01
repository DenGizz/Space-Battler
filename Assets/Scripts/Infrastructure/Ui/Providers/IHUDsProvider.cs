using Assets.Scripts.UI.HUDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ui.Providers
{
    public interface IHUDsProvider
    {
        PauseBattleHUD PauseBattleHUD { get; set; }
    }
}

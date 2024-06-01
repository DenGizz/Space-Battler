using Assets.Scripts.UI.HUDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ui.Providers
{
    public class HUDsProvider : IHUDsProvider
    {
        public PauseBattleHUD PauseBattleHUD { get; set; }
    }
}

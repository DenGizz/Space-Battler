using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Battles;
using Assets.Scripts.UI;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleUiService
    {
        BattleUI BattleUi { get; }
        void CreateBattleUi();
        void SetBattle(Battle battle);
        void DestroyBattleUi();
    }
}

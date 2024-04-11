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
        BattleUI BattleUI { get; }
        void CreateBattleUI();
        void SetBattle(Battle battle);
        void DestroyBattleUI();
    }
}

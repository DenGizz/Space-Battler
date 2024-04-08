using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleUIService
    {
        void CreateBattleUI();
        void SetBattle(Battle battle);
        void DestroyBattleUI();
    }
}

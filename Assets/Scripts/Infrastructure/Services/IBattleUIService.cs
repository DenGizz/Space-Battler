using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleUIService
    {
        void CreateBattleUI();
        void SetBattle(BattleData battleData);
        void DestroyBattleUI();
    }
}

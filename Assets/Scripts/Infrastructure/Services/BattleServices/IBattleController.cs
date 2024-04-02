using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleController
    {
        void StartBattle(BattleData battleData);
        void StopBattle(BattleData battleData);
        void ResumeBattle(BattleData battleData);
    }
}

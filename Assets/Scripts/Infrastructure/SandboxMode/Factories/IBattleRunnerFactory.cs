using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IBattleRunnerFactory
    {
        BattleRunner CreateBattleRunner(BattleData battleData);
    }
}

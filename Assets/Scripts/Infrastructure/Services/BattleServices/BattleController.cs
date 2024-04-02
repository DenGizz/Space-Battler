using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleController : IBattleController
    {
        public void StartBattle(BattleData battleData)
        {
            //TODO: Place units on the battlefield ???
            battleData.PlayerAI.StartCombat();
            battleData.EnemyAI.StartCombat();
        }

        public void ResumeBattle(BattleData battleData)
        {
            battleData.PlayerAI.StartCombat();
            battleData.EnemyAI.StartCombat();
        }

        public void StopBattle(BattleData battleData)
        {
            battleData.PlayerAI.StopCombat();
            battleData.EnemyAI.StopCombat();
        }
    }
}

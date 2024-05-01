using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battles
{
    public class BattleEndEventArgs : EventArgs
    {
        public BattleResult BattleResult { get; }

        public BattleEndEventArgs(BattleResult battleResult)
        {
            BattleResult = battleResult;
        }
    }
}

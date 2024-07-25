using System;

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

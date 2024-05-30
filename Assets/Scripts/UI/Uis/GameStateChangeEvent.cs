using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.NewUi.Uis
{
    public enum GameStateChangeEvent
    {
        EnterSandboxMode = 0,
        EnterStoryMode = 1,
        StartSandboxBattle = 2, //TODO: Separate this into another anum
        CloseBattleEndScreen = 3,
    }
}

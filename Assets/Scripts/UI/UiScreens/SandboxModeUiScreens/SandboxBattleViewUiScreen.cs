using Assets.Scripts.Battles;
using Assets.Scripts.UI.ViewModels;
using UnityEngine;

namespace Assets.Scripts.UI.UiScreens.SandboxModeUiScreens
{
    public class SandboxBattleViewUiScreen : UiScreen
    {
        [SerializeField] private BattleView _battleView;

        public void SetBattleData(BattleData battleData)
        {
            _battleView.Clear();
            _battleView.SetBattleData(battleData);
        }
    }
}

using Assets.Scripts.Battles;
using Assets.Scripts.UI.BattleUI;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleUiService
    {
        BattleUI BattleUi { get; }
        void CreateBattleUi();
        void SetBattle(BattleData battleData);
        void DestroyBattleUi();
    }
}

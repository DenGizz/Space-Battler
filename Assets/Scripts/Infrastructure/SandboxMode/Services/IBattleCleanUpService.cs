using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleCleanUpService
    {
        void CleanUpBattle(BattleRunner battleRunner);
    }
}

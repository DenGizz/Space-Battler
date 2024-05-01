using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleRunnerProvider 
    {
        BattleRunner CurrentBattleRunner { get; set; }
    }
}
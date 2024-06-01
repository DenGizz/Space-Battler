using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleRunnerRunnerProvider : IBattleRunnerProvider
    {
        public BattleRunner CurrentBattleRunner { get; set; }
    }
}
using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public class BattleRunnerRunnerProvider : IBattleRunnerProvider
    {
        public BattleRunner CurrentBattleRunner { get; set; }
    }
}
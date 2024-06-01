using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public interface IBattleRunnerProvider 
    {
        BattleRunner CurrentBattleRunner { get; set; }
    }
}
using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public interface IBattleRunnerProvider 
    {
        BattleRunner CurrentBattleRunner { get; set; }
    }
}
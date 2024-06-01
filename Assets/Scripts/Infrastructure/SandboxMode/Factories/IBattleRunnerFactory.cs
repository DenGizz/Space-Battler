using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.SandboxMode.Factories
{
    public interface IBattleRunnerFactory
    {
        BattleRunner CreateBattleRunner(BattleData battleData);
    }
}

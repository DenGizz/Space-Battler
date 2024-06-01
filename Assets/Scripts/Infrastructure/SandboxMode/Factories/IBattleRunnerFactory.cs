using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.SandboxMode.Factories
{
    public interface IBattleRunnerFactory
    {
        BattleRunner CreateBattleRunner(BattleData battleData);
    }
}

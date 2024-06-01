using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public interface IBattleCleanUpService
    {
        void CleanUpBattle(BattleRunner battleRunner);
    }
}

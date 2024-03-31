namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleRunnerService
    {
        BattleData CurrentBattle { get; }
        void SetupBattle();
        void StartBattle();
        void StopBattle();
        void CleanUpBattle();
    }
}
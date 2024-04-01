namespace Assets.Scripts.Infrastructure.Services.BattleServices
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
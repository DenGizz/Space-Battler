using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public interface IBattleSetupProvider 
    {
        BattleSetup BattleSetup { get; set; }
    }
}
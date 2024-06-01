using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleSetupProvider 
    {
        BattleSetup BattleSetup { get; set; }
    }
}
using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleProvider 
    {
        Battle CurrentBattle { get; set; }
    }
}
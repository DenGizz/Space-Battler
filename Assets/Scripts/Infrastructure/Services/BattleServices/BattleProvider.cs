using Assets.Scripts.Battles;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleProvider : IBattleProvider
    {
        public Battle CurrentBattle { get; set; }
    }
}
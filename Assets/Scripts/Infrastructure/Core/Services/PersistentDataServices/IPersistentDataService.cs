using Assets.Scripts.Battles;
using Assets.Scripts.Progress;

namespace Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices
{
    public interface IPersistentDataService
    {
        void Initialize();

        bool IsBattleSetupStored();
        void SaveBattleSetup(BattleSetup battleSetup);
        BattleSetup LoadBattleSetup();

        bool IsPlayerProgressDataStored();
        void SavePlayerProgressData(PlayerProgressData playerProgressData);
        PlayerProgressData LoadPlayerProgressData();
    }
}

using Assets.Scripts.Battles;
using Assets.Scripts.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
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

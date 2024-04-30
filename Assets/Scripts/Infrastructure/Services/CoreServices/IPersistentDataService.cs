using Assets.Scripts.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IPersistentDataService
    {
        bool IsBattleSetupStored();
        void SaveBattleSetup(BattleSetup battleSetup);
        BattleSetup LoadBattleSetup();
    }
}

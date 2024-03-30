using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleObserver
    {
        BattleData CurrentBattle { get; }
        event Action<ISpaceShip> OnWinerDetermined;
        void StartObserve(BattleData battle);
        void StopObserve();
    }
}

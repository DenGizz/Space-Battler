using System;
using Assets.Scripts.Units;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleObserver
    {
        BattleData CurrentBattle { get; }
        event Action<ISpaceShip> OnWinnerDetermined;
        void StartObserve(BattleData battle);
        void StopObserve();
    }
}

using System;
using Assets.Scripts.SpaceShip;

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

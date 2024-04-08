using System;
using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShip;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleObserver
    {
        event Action<ISpaceShip> OnWinnerDetermined;
        void StartObserve(Battle battle);
        void StopObserve();
    }
}

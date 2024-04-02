using System;
using Assets.Scripts.SpaceShip;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleObserver : IBattleObserver, ITickable
    {
        public BattleData CurrentBattle { get; private set; }

        public event Action<ISpaceShip> OnWinnerDetermined;

        private bool _isObserving;

        public void StartObserve(BattleData battle)
        {
            CurrentBattle = battle;
            _isObserving = true;
        }

        public void StopObserve()
        {
            _isObserving = false;
        }

        public void Tick()
        {
            if (!_isObserving)
                return;

            if (CurrentBattle.PlayerSpaceShip.HealthAttribute.HP <= 0)
            {
                OnWinnerDetermined?.Invoke(CurrentBattle.EnemySpaceShip);
                return;
            }

            if (CurrentBattle.EnemySpaceShip.HealthAttribute.HP <= 0)
            {
                OnWinnerDetermined?.Invoke(CurrentBattle.PlayerSpaceShip);
                return;
            }
        }
    }
}

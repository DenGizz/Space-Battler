using System;
using Assets.Scripts.SpaceShip;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleObserver : IBattleObserver, ITickable
    {
        public Battle.Battle _currentBattle;

        public event Action<ISpaceShip> OnWinnerDetermined;

        private bool _isObserving;

        public void StartObserve(Battle.Battle battle)
        {
            _currentBattle = battle;
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

            if (_currentBattle.BattleData.PlayerSpaceShip.HealthAttribute.HP <= 0)
            {
                OnWinnerDetermined?.Invoke(_currentBattle.BattleData.EnemySpaceShip);
                return;
            }

            if (_currentBattle.BattleData.EnemySpaceShip.HealthAttribute.HP <= 0)
            {
                OnWinnerDetermined?.Invoke(_currentBattle.BattleData.PlayerSpaceShip);
                return;
            }
        }
    }
}

using System;
using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleObserver : IBattleObserver
    {
        public Battle _currentBattle;

        public event Action<ISpaceShip> OnWinnerDetermined;
        public ISpaceShip Winner { get; private set; }

        private bool _isObserving;

        public void StartObserve(Battle battle)
        {
            _currentBattle = battle;
            _isObserving = true;
            Winner = null;

            _currentBattle.BattleData.PlayerSpaceShip.OnDeath += OnSpaceShipDeathEventHandler;
            _currentBattle.BattleData.EnemySpaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void StopObserve()
        {
            _isObserving = false;
        }

        private void OnSpaceShipDeathEventHandler(ISpaceShip spaceShip)
        {
            if (!_isObserving)
                return;

            Winner = spaceShip == _currentBattle.BattleData.EnemySpaceShip ? 
                _currentBattle.BattleData.PlayerSpaceShip : 
                _currentBattle.BattleData.EnemySpaceShip;

            _currentBattle.BattleData.PlayerSpaceShip.OnDeath -= OnSpaceShipDeathEventHandler;
            _currentBattle.BattleData.EnemySpaceShip.OnDeath -= OnSpaceShipDeathEventHandler;

            OnWinnerDetermined?.Invoke(Winner);
        }
    }
}

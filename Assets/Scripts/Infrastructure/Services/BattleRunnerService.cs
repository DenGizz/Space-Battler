using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleRunnerService : IBattleRunnerService
    {
        ISpaceShipFactory _spaceShipFactory;
        ICombatAIRegistry _combatAIRegistry;
        IBattleObserver _battleObserver;
        IUIFactory _iUIFactory;

        public BattleData CurrentBattle { get; private set; }

        [Inject]
        public BattleRunnerService(ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleObserver battleObserver, IUIFactory uiFactory)
        {
            _spaceShipFactory = spaceShipFactory;
            _combatAIRegistry = combatAIRegistry;
            _battleObserver = battleObserver;
            _iUIFactory = uiFactory;

            _battleObserver.OnWinnerDetermined += OnWinerDeterminedEventHandler;
        }

        public void SetupBattle()
        {
            //Instantiate units
            ISpaceShip player = _spaceShipFactory.CreatePlayerSpaceShip(Vector3.zero - Vector3.right * 7);
            ISpaceShip enemy = _spaceShipFactory.CreateEnemySpaceShip(Vector3.zero + Vector3.right * 7);
            //Find target for each combat unit
            ICombatAI playerAI = _combatAIRegistry.GetAI(player);
            ICombatAI enemyAI = _combatAIRegistry.GetAI(enemy);
            //Setup targets in unit ai
            playerAI.SetTarget(enemy);
            enemyAI.SetTarget(player);

            CurrentBattle = new BattleData(player, enemy, playerAI, enemyAI, false, false);

            BattleUI battleUI = _iUIFactory.CreateBattleUI();
            battleUI.Setup(CurrentBattle);
        }

        public void StartBattle()
        {
            _battleObserver.StartObserve(CurrentBattle);
            //Enable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                   ai.StartCombat();
        }

        public void StopBattle()
        {
            _battleObserver.StopObserve();
            //Disable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                ai.StopCombat();
        }

        public void CleanUpBattle()
        {
            //Destroy units
            //Free memory
            //Destroy projectiles
        }

        private void OnWinerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            Debug.Log("Winner is " + winner);
        }
    }
}
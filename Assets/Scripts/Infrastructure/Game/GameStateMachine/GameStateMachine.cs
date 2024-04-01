using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Zenject;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class GameStateMachine : StateMachine.StateMachine
    {
        //TODO: Register GameStateMachine as service. Create state factory to auto resolve dependencies
        //TODO: Bind states in States installer
        [Inject]
        public GameStateMachine(ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleObserver battleObserver, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry, IBattleDataProvider battleDataProvider)
        {
            States[typeof(SetupBattleState)] = new SetupBattleState(this, spaceShipFactory, combatAIRegistry, battleUIService, battleDataProvider);
            States[typeof(BattleRunningState)] = new BattleRunningState(this, battleObserver, combatAIRegistry, battleDataProvider);
            States[typeof(CleanUpBattleState)] = new CleanUpBattleState(this, spaceShipsGameObjectRegistry, spaceShipRegistry, combatAIRegistry, battleUIService, battleDataProvider);
        }
    }
}

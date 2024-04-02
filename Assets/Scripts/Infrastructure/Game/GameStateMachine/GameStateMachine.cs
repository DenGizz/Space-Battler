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
        public GameStateMachine(ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleObserver battleObserver, IBattleCleanUpServce battleCleanUpServce, IBattleDataProvider battleDataProvider, IBattleController battleController)
        {
            States[typeof(CreateBattleState)] = new CreateBattleState(this, spaceShipFactory, combatAIRegistry, battleUIService, battleDataProvider);
            States[typeof(BattleState)] = new BattleState(this, battleObserver, battleDataProvider, battleController);
            States[typeof(CleanUpBattleState)] = new CleanUpBattleState(this,battleDataProvider, battleCleanUpServce);
        }
    }
}

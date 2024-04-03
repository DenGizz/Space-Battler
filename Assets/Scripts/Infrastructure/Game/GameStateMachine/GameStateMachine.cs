using Assets.Scripts.Infrastructure.Config;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Zenject;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class GameStateMachine : StateMachine.StateMachine
    {
        //TODO: Register GameStateMachine as service. Create state factory to auto resolve dependencies
        //TODO: Bind states in States installer
        [Inject]
        public GameStateMachine(ISpaceShipFactory spaceShipFactory, ICombatAiRegistry combatAIRegistry, 
            IBattleUIService battleUIService, IBattleObserver battleObserver, IBattleCleanUpServce battleCleanUpServce, 
            IBattleDataProvider battleDataProvider,
            ScenesConfig scenesConfig, ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            States[typeof(LoadMainMenuSceneState)] = new LoadMainMenuSceneState(this, sceneLoader, scenesConfig);
            States[typeof(MainMenuState)] = new MainMenuState(this, uiFactory);
            States[typeof(LoadBattleFieldSceneState)] = new LoadBattleFieldSceneState(this, scenesConfig, sceneLoader);
            States[typeof(CreateBattleState)] = new CreateBattleState(this, spaceShipFactory, combatAIRegistry, battleUIService, battleDataProvider);
            States[typeof(BattleState)] = new BattleState(this, battleObserver, battleDataProvider, combatAIRegistry);
            States[typeof(CleanUpBattleState)] = new CleanUpBattleState(this,battleDataProvider, battleCleanUpServce);
        }
    }
}

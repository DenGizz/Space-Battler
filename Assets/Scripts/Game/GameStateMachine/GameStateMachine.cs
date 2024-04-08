using Assets.Scripts.Game.GameStateMachine.GameStates;
using Assets.Scripts.Infrastructure.Config;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.StateMachines;
using Zenject;

namespace Assets.Scripts.Game.GameStateMachine
{
    public class GameStateMachine : StateMachine
    {
        //TODO: Register GameStateMachine as service. Create state factory to auto resolve dependencies
        //TODO: Bind states in States installer
        [Inject]
        public GameStateMachine(ISpaceShipFactory spaceShipFactory, 
            IBattleUIService battleUIService, IBattleObserver battleObserver, IBattleCleanUpService battleCleanUpService, 
            ScenesConfig scenesConfig, ISceneLoader sceneLoader, IUIFactory uiFactory, IBattleFactory battleFactory, IWeaponFactory weaponFactory, IBattleSetupProvider battleSetupProvider)
        {
            States[typeof(LoadMainMenuSceneState)] = new LoadMainMenuSceneState(this, sceneLoader, scenesConfig);
            States[typeof(MainMenuState)] = new MainMenuState(this, uiFactory, battleSetupProvider);
            States[typeof(LoadBattleFieldSceneState)] = new LoadBattleFieldSceneState(this, scenesConfig, sceneLoader);
            States[typeof(CreateBattleState)] = new CreateBattleState(this, spaceShipFactory,battleUIService,battleFactory, weaponFactory, battleSetupProvider);
            States[typeof(BattleState)] = new BattleState(this,  battleObserver);
            States[typeof(CleanUpBattleState)] = new CleanUpBattleState(this, battleCleanUpService);
        }
    }
}

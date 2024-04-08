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
        public GameStateMachine(IStatesFactory statesFactory)
        {
            States[typeof(LoadMainMenuSceneState)] = statesFactory.CreateState<LoadMainMenuSceneState>(this);
            States[typeof(MainMenuState)] = statesFactory.CreateState<MainMenuState>(this); 
            States[typeof(LoadBattleFieldSceneState)] = statesFactory.CreateState<LoadBattleFieldSceneState>(this); 
            States[typeof(CreateBattleState)] = statesFactory.CreateState<CreateBattleState>(this); 
            States[typeof(BattleState)] = statesFactory.CreateState<BattleState>(this);
            States[typeof(CleanUpBattleState)] = statesFactory.CreateState<CleanUpBattleState>(this);
        }
    }
}

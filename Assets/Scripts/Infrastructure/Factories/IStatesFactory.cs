using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IStatesFactory 
    {
        T CreateState<T>(IStateMachine stateMachine) where T : IState;
    }
}
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IStatesFactory 
    {
        T CreateState<T>(StateMachine stateMachine) where T : IState;
    }
}
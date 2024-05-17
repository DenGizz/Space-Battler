namespace Assets.Scripts.StateMachines
{
    public interface IStateMachine
    {
        void EnterState<TState>() where TState : IState;
        void AddState<TState>(IState state) where TState : IState;
    }
}
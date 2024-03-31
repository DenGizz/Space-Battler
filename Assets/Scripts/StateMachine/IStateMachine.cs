namespace Assets.Scripts.StateMachine
{
    public interface IStateMachine
    {
        void EnterState<TState>() where TState : IState;
        void EnterState<TState, TArgs>(TArgs args) where TState : IState;
    }
}
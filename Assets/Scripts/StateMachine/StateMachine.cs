using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine
{
    public class StateMachine : IStateMachine
    {
        protected readonly Dictionary<Type, IState> States;
        private IState _currentState;

        public StateMachine()
        {
            States = new Dictionary<Type, IState>();
        }

        public void EnterState<TState>() where TState : IState
        {
            _currentState?.Exit();
            IState state = States[typeof(TState)];
            state.Enter();
            _currentState = state;
            _currentState.Enter();
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IState
        {
            _currentState?.Exit();
            IState state = States[typeof(TState)];
            state.Enter();
            _currentState = state;
            (_currentState as IStateWithArtuments<TArgs>).Enter(args);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assets.Scripts.StateMachines
{
    public class StateMachine : IStateMachine
    {
        protected readonly Dictionary<Type, IState> States;
        private IState _currentState;

        public StateMachine()
        {
            States = new Dictionary<Type, IState>();
        }

        public void AddState<TState>(IState state) where TState : IState
        {
            States.Add(typeof(TState), state);
        }

        public void EnterState<TState>() where TState : IState
        {
            _currentState?.Exit();
            IState state = States[typeof(TState)];
            _currentState = state;
            _currentState.Enter();
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IState
        {
            _currentState?.Exit();
            IState state = States[typeof(TState)];
            _currentState = state;
            (_currentState as IStateWithArtuments<TArgs>).Enter(args);
        }
    }
}

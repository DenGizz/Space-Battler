using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _stateMap;
        private IState _currentState;

        public StateMachine()
        {
            _stateMap = new Dictionary<Type, IState>();
        }

        public void EnterState<TState>() where TState : IState
        {
            _currentState?.Exit();
            var state = _stateMap[typeof(TState)];
            (_stateMap as IState).Enter();
            _currentState = state;
            _currentState.Enter();
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IState
        {
            _currentState?.Exit();
            var state = _stateMap[typeof(TState)];
            (_stateMap as IState).Enter();
            _currentState = state;
            (_currentState as IStateWithArtuments<TArgs>).Enter(args);
        }
    }
}

using Assets.Scripts.StateMachines;
using Zenject;

namespace Assets.Scripts.Infrastructure.Core.Factories
{
    public class StatesFactory : IStatesFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T CreateState<T>(IStateMachine stateMachine) where T : IState
        {
            return _instantiator.Instantiate<T>(new object[] { stateMachine });
        }

        public T CreateSubState<T>(IStateMachine substateMachine, IStateMachine parentStateMachine) where T : SubState
        {
            return _instantiator.Instantiate<T>(new object[] {substateMachine, parentStateMachine });
        }
    }
}

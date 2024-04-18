using Assets.Scripts.StateMachines;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class StatesFactory : IStatesFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T CreateState<T>(StateMachine stateMachine) where T : IState
        {
            return _instantiator.Instantiate<T>(new object[] { stateMachine });
        }
    }
}

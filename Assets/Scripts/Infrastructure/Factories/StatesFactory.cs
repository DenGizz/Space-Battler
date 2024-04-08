using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class StatesFactory : IStatesFactory
    {
        private readonly DiContainer _diContainer;

        public StatesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T CreateState<T>(StateMachine stateMachine) where T : IState
        {
            return _diContainer.Instantiate<T>(new object[] { stateMachine });
        }
    }
}

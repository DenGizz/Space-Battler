using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachines
{
    public class SubState : IState
    {
        protected readonly IStateMachine _parentStateMachine;
        protected readonly IStateMachine _substateMachine;

        public SubState(IStateMachine parentStateMachine, IStateMachine substateMachine)
        {
            _parentStateMachine = parentStateMachine;
            _substateMachine = substateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}

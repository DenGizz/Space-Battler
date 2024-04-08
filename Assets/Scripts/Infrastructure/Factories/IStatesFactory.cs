using Assets.Scripts.StateMachines;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IStatesFactory 
    {
        T CreateState<T>(StateMachine stateMachine) where T : IState;
    }
}
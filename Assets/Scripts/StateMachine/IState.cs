using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Enter<TArgs>(TArgs args);
    void Execute();
    void Exit();
}

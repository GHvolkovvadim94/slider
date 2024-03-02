using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
    private readonly Dictionary<Type, IState> states;
    private IState activeState;
    public GameStateMachine()
    {
        states = new Dictionary<Type, IState>();
    }
    public void Enter<TState>() where TState : IState
    {
        activeState?.Exit();
        IState state = states[typeof(TState)];
        activeState = state;
        state.Enter();
    }
}

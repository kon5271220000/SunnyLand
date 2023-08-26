using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerStates currentState { get; private set; }

    public void Initialize(PlayerStates startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerStates newState) 
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private BaseState currentState;
    private Stack<BaseState> stateStack = new Stack<BaseState>();
    
    private void Awake()
    {
        // initialize the gameMap
        currentState = new InitializeState(this);
    }

    private void Update()
    {
        currentState.Update();
    }

    public void ChangeState(BaseState newState)
    {
        Debug.Log("Changing state from " + currentState + " to " + newState);
        currentState = newState;
        stateStack.Push(currentState);
    }

    public void ReturnToPreviousState()
    {
        if (stateStack.Count == 0) {
            throw new System.Exception("No previous state to return to");
        }
        stateStack.Pop();
        currentState = stateStack.Peek();
        currentState.Reset();
    }

    public void ClearStateStack()
    {
        stateStack.Clear();
    }

    public void PopStateStack()
    {
        if (stateStack.Count > 0)
        stateStack.Pop();
    }
    public void DisableInput()
    {
        currentState.DisableInput();
    }

    public void EnableInput()
    {
        currentState.EnableInput();
    }

    public InitializeState CreateInitializeState()
    {
        return new InitializeState(this);
    }
    public ReadyState CreateReadyState()
    {
        return new ReadyState(this);
    }

    public PlayingState CreatePlayingState()
    {
        return new PlayingState(this);
    }

    public PauseState CreatePauseState()
    {
        return new PauseState(this);
    }

    public WinState CreateWinState()
    {
        return new WinState(this);
    }

    public LoseState CreateLoseState()
    {
        return new LoseState(this);
    }
}

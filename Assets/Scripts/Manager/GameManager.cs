using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public InputController inputController;
    public StateManager stateManager;
    public UIManager uiManager;
    
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        stateManager = GetComponent<StateManager>();
        EventManager.Instance.init(this);
    }
    public void HandleGameStartEvent()
    {
        Time.timeScale = 1.0f;
    }

    public void HandleGameOverEvent()
    {
        stateManager.ChangeState(stateManager.CreateLoseState());
    }

    public void HandleGamePauseEvent()
    {
        stateManager.ChangeState(stateManager.CreatePauseState());
    }

    public void HandleGameResumeEvent()
    {
        Time.timeScale = 1.0f;
        stateManager.ReturnToPreviousState();
    }

    public void HandleGameRestartEvent()
    {
        stateManager.ClearStateStack();
        stateManager.ChangeState(stateManager.CreateInitializeState());
    }
}

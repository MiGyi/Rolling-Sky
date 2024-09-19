using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public InputController inputController;
    public StateManager stateManager;

    public GameData gameData = new GameData();
    public MapGenerator mapGenerator;
    public UIManager uiManager;
    
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        stateManager = GetComponent<StateManager>();
        EventManager.Instance.init(this);
    }

    private void Update() {
        
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
        uiManager.ReturnToPreviousScreen();
    }

    public void HandleGameRestartEvent()
    {
        stateManager.ClearStateStack();
        stateManager.ChangeState(stateManager.CreateInitializeState());
    }
}

using UnityEngine;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected GameManager gameManager;
    protected InputController inputController;
    protected UIManager uiManager;

    public BaseState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        gameManager = stateManager.GetComponent<GameManager>();
        inputController = stateManager.GetComponent<InputController>();
        uiManager = gameManager.uiManager;
    }


    public abstract void Update();
    public abstract void DisableInput();
    public abstract void EnableInput();
    public abstract void Reset();

}
using UnityEngine;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected GameManager gameManager;
    protected InputController inputController;

    public BaseState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        gameManager = stateManager.GetComponent<GameManager>();
        inputController = stateManager.GetComponent<InputController>();
    }


    public abstract void Update();
    public abstract void DisableInput();
    public abstract void EnableInput();

}
using UnityEngine;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected GameManager gameManager;
    protected InputController inputController;
    protected GameData gameData;
    protected MapGenerator mapGenerator;
    protected UIManager uiManager;

    public BaseState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        gameManager = stateManager.GetComponent<GameManager>();
        inputController = stateManager.GetComponent<InputController>();
        gameData = gameManager.gameData;
        mapGenerator = gameManager.mapGenerator;
        uiManager = gameManager.uiManager;
    }


    public abstract void Update();
    public abstract void DisableInput();
    public abstract void EnableInput();
    public abstract void Reset();

}
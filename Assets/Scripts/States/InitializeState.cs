using System.Collections;
using UnityEngine;

public class InitializeState : BaseState
{
    public InitializeState(StateManager stateManager) : base(stateManager)
    {
        // Initialize the game
        InitializeMap();
        InitializePlayer();
        InitializeObstacles();
        gameData.Reset();
        // delay 2 seconds before starting the game
        stateManager.StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);
        stateManager.ChangeState(stateManager.CreateReadyState());
    }
    private void InitializeMap()
    {
        // Initialize the map
    }
    private void InitializePlayer()
    {
        // Initialize the player
    }
    private void InitializeObstacles()
    {
        // Initialize the obstacles
    }
    public override void Update()
    {

    }

    public override void DisableInput()
    {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput()
    {
        inputController.SetEnableInput(true);
    }
}
using UnityEngine;

public class PlayingState : BaseState
{

    private Ball ball;
    public PlayingState(StateManager stateManager) : base(stateManager)
    {
        Time.timeScale = 1;
        ball = GameObject.FindWithTag("Player").GetComponent<Ball>();
        ball.StartGravity();
        ball.StartJumping();
        uiManager.SwitchToScreen(uiManager.ingameScreen);
    }

    public override void Update()
    {
        mapGenerator.UpdateMap();
        if (inputController.GetPauseButtonDown())
        {
            stateManager.ChangeState(stateManager.CreatePauseState());
            return;
        }

        ball.FollowMousePosition(inputController.GetMousePosition());
        ball.AutoMoveForward();
        gameData.score = (int)ball.transform.position.z;
        
        if (ball.IsFalling())
        {
            Debug.Log("Ball is falling");
            stateManager.ChangeState(stateManager.CreateLoseState());
        }
    }

    public override void DisableInput()
    {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput()
    {
        inputController.SetEnableInput(true);
    }

    public override void Reset()
    {
        
    }

}
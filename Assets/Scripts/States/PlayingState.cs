using UnityEngine;

public class PlayingState : BaseState
{

    private Ball ball;
    public PlayingState(StateManager stateManager) : base(stateManager)
    {
        ball = GameObject.FindWithTag("Player").GetComponent<Ball>();
        uiManager.OpenIngameScreen();
    }

    public override void Update()
    {
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
        uiManager.OpenIngameScreen();
    }

}
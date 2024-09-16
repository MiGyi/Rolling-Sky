using UnityEngine;

public class PlayingState : BaseState
{

    private Ball ball;
    public PlayingState(StateManager stateManager) : base(stateManager)
    {
        ball = GameObject.FindWithTag("Player").GetComponent<Ball>();
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
}
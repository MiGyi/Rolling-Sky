using UnityEngine;

public class LoseState : BaseState
{
    Ball ball;
    public LoseState(StateManager stateManager) : base(stateManager)
    {
        ball = GameObject.FindWithTag("Player").GetComponent<Ball>();
        ball.Explode();
        Camera.main.GetComponent<BallCamera>().HandleLose();
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

    public override void Reset()
    {
        
    }
}
using UnityEngine;

public class PlayingState: BaseState {
    
    private Ball ball;
    public PlayingState(StateManager stateManager): base(stateManager) {
        ball = GameObject.FindWithTag("Player").GetComponent<Ball>();
    }

    public override void Update() {
        ball.FollowMousePosition(inputController.GetMousePosition());
        ball.AutoMoveForward();
        if (ball.IsFalling()) {
            stateManager.ChangeState(stateManager.CreateLoseState());
        }
        if (inputController.GetPauseButtonDown()) {
            stateManager.ChangeState(stateManager.CreatePauseState());
        }
    }

    public override void DisableInput() {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput() {
        inputController.SetEnableInput(true);
    }
}
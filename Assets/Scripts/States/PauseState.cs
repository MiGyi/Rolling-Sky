using UnityEngine;

public class PauseState: BaseState {
    public PauseState(StateManager stateManager): base(stateManager) {
        Time.timeScale = 0;
    }

    public override void Update() {
        if (inputController.GetSpaceBarDown()) {
            stateManager.ChangeState(stateManager.CreatePlayingState());
        }
    }

    public override void DisableInput() {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput() {
        inputController.SetEnableInput(true);
    }
}
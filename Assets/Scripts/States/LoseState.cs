using UnityEngine;

public class LoseState: BaseState {
    public LoseState(StateManager stateManager): base(stateManager) {
        Time.timeScale = 0;
    }

    public override void Update() {

    }

    public override void DisableInput() {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput() {
        inputController.SetEnableInput(true);
    }
}
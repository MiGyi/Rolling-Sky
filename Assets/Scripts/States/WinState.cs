public class WinState: BaseState {
    public WinState(StateManager stateManager): base(stateManager) {
        
    }

    public override void Update() {
        // if (inputController.GetSpaceBarDown()) {
        //     stateManager.ChangeState(stateManager.CreateReadyState());
        // }
    }

    public override void DisableInput() {
        inputController.SetEnableInput(false);
    }

    public override void EnableInput() {
        inputController.SetEnableInput(true);
    }
}
public class WinState: BaseState {
    public WinState(StateManager stateManager): base(stateManager) {
        uiManager.OpenWinScreen();
        uiManager.winScreen.GetComponent<WinScreen>().UpdateScore();
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

    public override void Reset()
    {
        
    }
}
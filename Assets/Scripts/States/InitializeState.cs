public class InitializeState : BaseState
{
    public InitializeState(StateManager stateManager) : base(stateManager)
    {
        // Initialize the game
        InitializeMap();
        InitializePlayer();
        InitializeObstacles();
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
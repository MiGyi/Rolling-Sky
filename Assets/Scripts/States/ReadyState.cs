using Unity.VisualScripting;
using UnityEngine;

public class ReadyState : BaseState
{
    public ReadyState(StateManager stateManager) : base(stateManager)
    {
        
    }

    public override void Update()
    {
        if (inputController.GetSpaceBarDown())
        {
            PlayingState playingState = stateManager.CreatePlayingState();
            stateManager.ChangeState(playingState);
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
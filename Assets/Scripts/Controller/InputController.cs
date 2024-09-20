using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    bool isEnableInput = true;
    public Vector3 GetMousePosition() {
        if (!isEnableInput) return Vector3.zero;
        return Input.mousePosition;
    }
    
    public bool GetSpaceBarDown() {
        if (!isEnableInput) return false;
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetPauseButtonDown() {
        if (!isEnableInput) return false;
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public bool IsEnableInput() {
        return isEnableInput;
    }

    public void SetEnableInput(bool enable) {
        isEnableInput = enable;
    }
}

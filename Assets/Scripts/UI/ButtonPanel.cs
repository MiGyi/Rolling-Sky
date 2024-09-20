using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPanel : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelectionButton()
    {
        // Unimplemented
    }

    public void NextLevelButton()
    {
        // Unimplemented
    }

    public void RestartLevelButton()
    {
        // Unimplemented
    }
}

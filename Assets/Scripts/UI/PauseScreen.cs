using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void Resume()
    {
        EventManager.Instance.TriggerGameResumeEvent();

    }

    public void Restart()
    {
        EventManager.Instance.TriggerGameRestartEvent();
    }

    public void Settings()
    {
        
    }

    public void Exit() //bug
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Sound()
    {
        //unimplemented
    }
}

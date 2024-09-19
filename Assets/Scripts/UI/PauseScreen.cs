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

    }

    public void Settings()
    {

    }

    public void Exit() //bug
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Sound()
    {
        //unimplemented
    }
}

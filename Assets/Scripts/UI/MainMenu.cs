using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene"); //temp
    }

    public void Settings()
    {
        //unimplemented
    }

    public void Customize()
    {
        //unimplemented
    }

    public void Exit()
    {
        Application.Quit();
    }
}

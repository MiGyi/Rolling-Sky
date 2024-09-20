using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject choosingGameModeScreen;
    public GameObject settingScreen;

    public void Play()
    {
        choosingGameModeScreen.SetActive(true);
    }

    public void Settings()
    {
        settingScreen.SetActive(true);
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

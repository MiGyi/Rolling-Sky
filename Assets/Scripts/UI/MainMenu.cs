using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject choosingGameModeScreen;

    public void Play()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("GameScene"); //temp
=======
        choosingGameModeScreen.SetActive(true);
>>>>>>> develop
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

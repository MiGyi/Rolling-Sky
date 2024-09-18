using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject hintScreen;
    public GameObject pauseScreen;
    public GameObject ingameScreen;

    public void OpenPauseScreen()
    {
        DisableAllScreens();
        pauseScreen.SetActive(true);
    }

    public void OpenHintScreen()
    {
        DisableAllScreens();
        hintScreen.SetActive(true);
    }

    public void OpenIngameScreen()
    {
        DisableAllScreens();
        ingameScreen.SetActive(true);
    }

    void DisableAllScreens()
    {
        hintScreen.SetActive(false);
        pauseScreen.SetActive(false);
        ingameScreen.SetActive(false);
    }

    public void OpenLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}

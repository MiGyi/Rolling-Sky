using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Stack<GameObject> screenStack = new Stack<GameObject>();
    public GameObject hintScreen;
    public GameObject pauseScreen;
    public GameObject ingameScreen;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject settingsScreen;

    public void OpenPauseScreen()
    {
        pauseScreen.SetActive(true);
    }

    public void AddScreenToStack(GameObject screen)
    {
        screenStack.Push(screen);
        screen.SetActive(true);
    }

    public void SwitchToScreen(GameObject destinationScreen)
    {
        GameObject screen = screenStack.Pop();
        screen.SetActive(false);
        screenStack.Push(destinationScreen);
        destinationScreen.SetActive(true);
    }
    public void ReturnToPreviousScreen()
    {
        if (screenStack.Count == 0)
        {
            throw new System.Exception("No previous screen to return to");
        }
        screenStack.Pop();
        if (screenStack.Count == 0)
        {
            OpenIngameScreen();
        }
        else
        {
            screenStack.Peek().SetActive(true);
        }
    }
    public void OpenHintScreen()
    {
        hintScreen.SetActive(true);
        AddScreenToStack(hintScreen);
    }

    public void OpenIngameScreen()
    {
        ingameScreen.SetActive(true);
        AddScreenToStack(ingameScreen);
    }
    

    public void OpenLoseScreen()
    {
        loseScreen.SetActive(true);
        AddScreenToStack(loseScreen);
    }

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
        AddScreenToStack(winScreen);
    }

    public void OpenSettingsScreen()
    {
        settingsScreen.SetActive(true);
        AddScreenToStack(settingsScreen);
    }
}

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
        AddScreenToStack(pauseScreen);
    }

    public void AddScreenToStack(GameObject screen)
    {
        screenStack.Push(screen);
        screen.SetActive(true);
        Debug.Log("Opening screen: " + screenStack.Peek().name);
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
        if (screenStack.Count <= 1)
        {
            throw new System.Exception("No previous screen to return to");
        }
        GameObject screen = screenStack.Pop();
        Debug.Log("Returning to previous screen: " + screen.name);
        screen.SetActive(false);
        screenStack.Peek().SetActive(true);
    }
    public void OpenHintScreen()
    {
        AddScreenToStack(hintScreen);
    }

    public void OpenIngameScreen()
    {
        AddScreenToStack(ingameScreen);
    }
    

    public void OpenLoseScreen()
    {
        AddScreenToStack(loseScreen);
    }

    public void OpenWinScreen()
    {
        AddScreenToStack(winScreen);
    }

    public void OpenSettingsScreen()
    {
        AddScreenToStack(settingsScreen);
    }
}

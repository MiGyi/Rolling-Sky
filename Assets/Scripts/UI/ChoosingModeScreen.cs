using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosingModeScreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject choosingMapScreen;
    private GameData gameData = new GameData();

    private void Start()
    {
        choosingMapScreen.SetActive(false);
        score.SetText(gameData.highScore.ToString());
    }

    public void EndlessMode()
    {
        gameData.gameMode = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void CasualMode()
    {
        choosingMapScreen.SetActive(true);
    }

    public void BackButton()
    {
        gameObject.SetActive(false);
    }
}

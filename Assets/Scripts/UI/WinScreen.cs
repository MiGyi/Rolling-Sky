using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score = null;
    private GameData gameData = new GameData();

    public void UpdateScore()
    {
        float scoreValue = gameData.score;
        score.text = "Score: " + scoreValue;
    }
}

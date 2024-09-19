using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public TextMeshProUGUI MapIndexTMP;
    public int mapIndex;
    public GameData gameData;

    public void Start()
    {
        MapIndexTMP.SetText(mapIndex.ToString());
    }

    public void MapButtonOnClick()
    {
        gameData.choosingMapIndex = mapIndex;
        SceneManager.LoadScene("CasualScene");
    }
}

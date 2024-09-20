using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapList : MonoBehaviour
{
    public GridLayoutGroup Grid;
    public GameObject MapButtonPref;
    public GameObject DisableMapButtonPref;
    private GameData gameData = new GameData();

    private void OnEnable()
    {
        int LastClearedMapIndex = gameData.lastClearedMapIndex;
        for (int i = 1; i <= LastClearedMapIndex + 1; i++)
        {
            GameObject mapButton = Instantiate(MapButtonPref);
            mapButton.GetComponent<MapButton>().mapIndex = i;
            mapButton.GetComponent<MapButton>().gameData = gameData;
            AddItem(mapButton);
        }

        for (int i = LastClearedMapIndex + 2; i <= 5; i++)
        {
            GameObject disableMapButton = Instantiate(DisableMapButtonPref);
            AddItem(disableMapButton);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < Grid.transform.childCount; i++)
            Destroy(Grid.transform.GetChild(i).gameObject);
    }

    private void AddItem(GameObject item)
    {
        if (item == null)
            return;

        item.transform.SetParent(Grid.transform, false);
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = Vector3.zero;
    }
}

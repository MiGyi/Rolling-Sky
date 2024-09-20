using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameData {
    
    // 1: casual, 0: endless
    public int gameMode
    {
        get
        {
            return PlayerPrefs.GetInt("gameMode", 0);
        }
        set
        {
            PlayerPrefs.SetInt("gameMode", value);
        }
    }
    public int score {
        get {
            // return value without PlayerPrefs
            return PlayerPrefs.GetInt("score", 0);
        }
        set {
            PlayerPrefs.SetInt("score", value);
            if( gameMode == 0 ) {
                highScore = (int)(Mathf.Max(value, highScore));
            }
        }
    }
    public int highScore {
        get {
            return PlayerPrefs.GetInt("highScore", 0);
        }
        set {
            PlayerPrefs.SetInt("highScore", value);
        }
    }

    public int choosingMapIndex
    {
        get
        {
            return PlayerPrefs.GetInt("choosingMapIndex", 1);
        }
        set
        {
            PlayerPrefs.SetInt("choosingMapIndex", value);
        }
    }

    public int lastClearedMapIndex
    {
        get
        {
            return PlayerPrefs.GetInt("lastClearedMapIndex", 4);
        }
        set
        {
            PlayerPrefs.SetInt("lastClearedMapIndex", value);
        }
    }

    public void Reset() {
        score = 0;
    }
}
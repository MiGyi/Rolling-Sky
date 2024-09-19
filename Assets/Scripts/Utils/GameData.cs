using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameData {
    public int _score = 0;
    
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
            return _score;
        }
        set {
            _score = value;
            highScore = Mathf.Max(value, highScore);
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
            return PlayerPrefs.GetInt("choosingMapIndex", 0);
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
            return PlayerPrefs.GetInt("lastClearedMapIndex", 0);
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
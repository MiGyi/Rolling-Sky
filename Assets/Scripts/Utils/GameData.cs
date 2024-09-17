using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameData {
    public int _score = 0;
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

    public void Reset() {
        score = 0;
    }
}
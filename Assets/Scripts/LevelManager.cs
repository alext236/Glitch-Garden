﻿using UnityEngine;

public class LevelManager : MonoBehaviour {

    public bool autoLoadNextLevel;
    public float loadNextLevelAfter;

    void Start() {
        if (autoLoadNextLevel) {
            if (loadNextLevelAfter >= 0) {
                Invoke("LoadNextLevel", loadNextLevelAfter);
            } else {
                Debug.LogError("Load time must be positive");
            }
            
        }
    }

    public void LoadLevel(string name) {
        Debug.Log("Level load requested for " + name);        
        Application.LoadLevel(name);
    }

    public void QuitRequest() {
        Debug.Log("Quit the game");
        Application.Quit();
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LoadLoseScreen() {
        LoadLevel("03b Lose");
    }

    public void LoadWinScreen() {
        LoadLevel("03a Win");
    }
}

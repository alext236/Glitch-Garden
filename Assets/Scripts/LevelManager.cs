﻿using UnityEngine;

public class LevelManager : MonoBehaviour {

    public bool autoLoadNextLevel;
    public float loadNextLevelAfter;

    void Start() {
        if (autoLoadNextLevel) {
            Invoke("LoadNextLevel", loadNextLevelAfter);
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
}

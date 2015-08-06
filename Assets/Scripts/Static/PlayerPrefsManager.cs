using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";     //level_unlocked_1 for level 1

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level) {
        if (level <= Application.levelCount - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level, 1);   //Use 1 for TRUE
        }
        else {
            Debug.LogError("Level index out of range");
        }
    }

    public static bool IsLevelUnlocked(int level) {
        if (level > Application.levelCount - 1) {
            Debug.LogError("Level index out of range");
        }
        else {
            int status = PlayerPrefs.GetInt(LEVEL_KEY + level);
            if (status == 1) {
                return true;
            }
        }

        return false;
    }

    public static void SetDifficulty(float difficulty) {
        //1 is Easy, 2 is Normal, 3 is Hard
        if (difficulty < 1f && difficulty > 3f) {
            Debug.LogError("Difficulty level needs to be between 1 and 3");
        }
        else {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}

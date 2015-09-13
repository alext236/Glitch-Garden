using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseGame : MonoBehaviour {

    private bool pause = false;

    private void Pause() {
        Time.timeScale = 0;
        pause = true;
        GameObject.Find("Pause").GetComponent<Text>().text = "continue";
    }

    private void Continue() {
        Time.timeScale = 1;
        pause = false;
        GameObject.Find("Pause").GetComponent<Text>().text = "pause";
    }

    public void OnClick() {
        if (pause == false) {
            Pause();
        } else {
            Continue();
        }

        
    }
}

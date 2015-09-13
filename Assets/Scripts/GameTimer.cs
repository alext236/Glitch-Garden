using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

    private Slider timeSlider;
    private float timeRemainingInSeconds;
    private Text winningText;
    private LevelManager levelManager;
    private bool win = false;

    public float timeAvailableInSeconds;
    public AudioClip winningSound;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        winningText = GameObject.Find("Winning Text").GetComponent<Text>();
        timeSlider = FindObjectOfType<Slider>();

        timeRemainingInSeconds = timeAvailableInSeconds;
        timeSlider.value = 0;
        winningText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        DecreaseTime();

        if (timeRemainingInSeconds == 0 && win == false) {
            DisplayWinningMessage();
            win = true;
            Invoke("LoadNextLevel", winningSound.length);
        }
    }

    private void DecreaseTime() {
        timeRemainingInSeconds -= 1 * Time.deltaTime;
        if (timeRemainingInSeconds < 0) {
            timeRemainingInSeconds = 0;
        }
        timeSlider.value += 1 / timeAvailableInSeconds * Time.deltaTime;
    }

    private void DisplayWinningMessage() {
        winningText.enabled = true;
        //Play sound
        AudioSource.PlayClipAtPoint(winningSound, transform.position, PlayerPrefsManager.GetMasterVolume());
    }

    private void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
    
}

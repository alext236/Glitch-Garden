using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;

    public float defaultVolume;
    public int defaultDifficulty;

    private MusicPlayer musicPlayer;

    public void Awake() {        
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Use this for initialization
    void Start() {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        defaultVolume = Mathf.Clamp(defaultVolume, 0f, 1f);
        defaultDifficulty = Mathf.Clamp(defaultDifficulty, 1, 3);
    }

    // Update is called once per frame
    void Update() {
        musicPlayer.SetVolume(volumeSlider.value);

    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);        
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}

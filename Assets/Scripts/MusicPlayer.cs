using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    
    private AudioSource soundTrack;

    public AudioClip startMenu;
    public AudioClip mainGame;
    public AudioClip gameOver;

    void Awake() {
        soundTrack = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start() {        
    }


    public void OnLevelWasLoaded(int level) {
        Debug.Log("Set music");

        if (level == 1) {      //Main Game

            soundTrack.clip = startMenu;
            soundTrack.Play();
        }
        else if (level == 2) {      //Game over

            soundTrack.clip = gameOver;
            soundTrack.Play();
        }
        else if (level == 3) {
            return;
        }
    }
}

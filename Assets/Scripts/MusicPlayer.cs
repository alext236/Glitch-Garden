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

    public void OnLevelWasLoaded(int level) {
        Debug.Log("Set music");

        if (level == 1) {       //Start Menu
            if (soundTrack.clip != startMenu) {
                soundTrack.clip = startMenu;
                soundTrack.Play();
            }            
        }
        else if (level == 2) {  //Options
            return;
        }
        else if (level == 3) {  //Main game
            soundTrack.clip = mainGame;
            soundTrack.Play();
        }
        else if (level == 4 || level == 5) {
            soundTrack.clip = gameOver;
            soundTrack.Play();
        }
    }
}

using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    public void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Attacker>()) {
            Debug.Log("You Lose!");
            levelManager.LoadLoseScreen();
        }
    }
}

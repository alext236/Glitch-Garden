using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;

    // Use this for initialization
    void Start() {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {

    }
}

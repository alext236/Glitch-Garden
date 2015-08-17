using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " trigger enter");
        if (collision.GetComponent<Collider2D>().GetComponent<Attacker>()) {
            Debug.Log(name + " enter trigger with an attacker");
            animator.SetBool("isAttacked", true);
        }
    }
}

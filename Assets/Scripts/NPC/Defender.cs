using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collision) {        
        GameObject atk = collision.gameObject;
        //only recognize entering trigger with attackers
        if (!atk.GetComponent<Attacker>()) {
            return;            
        }

        Debug.Log(name + " enter trigger with an attacker");
        anim.SetBool("isAttacked", true);
    }
}

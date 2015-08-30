using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator anim;   

    private GameObject currentAttacker;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();       

    }

    // Update is called once per frame
    void Update() {
        if (!currentAttacker && anim.GetBool("isAttacked") == true) {
            NoLongerAttacked();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        //only recognize entering trigger with attackers
        if (!collision.GetComponent<Attacker>()) {
            return;
        }
        currentAttacker = collision.gameObject;

        //If attacker already passes the defender position, defender can't stop attacker
        //even if they are still in trigger region
        if (currentAttacker.transform.position.x > transform.position.x) {
            anim.SetBool("isAttacked", true);
        }
    }

    public void NoLongerAttacked() {
        anim.SetBool("isAttacked", false);
    }

}

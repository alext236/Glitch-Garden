using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator anim;
    private Health healthComp;

    private GameObject currentAttacker;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        healthComp = GetComponent<Health>();

        if (IsThereAttackerOnSameLane() == true) {
            AttackMode(true);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!IsThereAttackerOnSameLane()) {
            AttackMode(false);
        }

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

    public void AttackMode(bool turnOn) {
        foreach (AnimatorControllerParameter para in anim.parameters) {
            if (para.name == "isAttacking") {
                if (turnOn) {
                    anim.SetBool("isAttacking", true);
                }
                else {
                    anim.SetBool("isAttacking", false);
                }
            }
        }
    }

    bool IsThereAttackerOnSameLane() {
        //Change so that it only return true when attacker is visible
        foreach (Attacker attacker in FindObjectsOfType<Attacker>()) {
            if (transform.position.y == attacker.transform.position.y) {
                return true;
            }
        }

        return false;
    }
}

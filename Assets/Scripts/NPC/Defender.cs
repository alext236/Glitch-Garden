using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private Animator anim;
    private Health healthComp;

    private Attacker currentAttacker;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        healthComp = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {
        if (!currentAttacker) {
            anim.SetBool("isAttacked", false);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject atk = collision.gameObject;        
        currentAttacker = atk.GetComponent<Attacker>();

        //only recognize entering trigger with attackers
        if (!currentAttacker) {
            return;
        }
        //If attacker already passes the defender position, defender can't stop attacker
        //even if they are still in trigger region
        if (currentAttacker.transform.position.x > transform.position.x) {
            anim.SetBool("isAttacked", true);
        }       

        
    }
}

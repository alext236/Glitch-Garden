using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Attacker attacker;
    private Animator anim;

    // Use this for initialization
    void Start() {
        attacker = GetComponent<Attacker>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject target = collision.gameObject;

        if (!target.GetComponent<Defender>()) {
            return;
        }

        //Fox jumps if it meets a gravestone, else attacks
        if (target.GetComponent<Gravestone>()) {
            Debug.Log(name + " enter trigger with a gravestone");            
            anim.SetTrigger("jumpTrigger");
        } else {
            Debug.Log(name + " enter trigger with a defender");
            attacker.Attack(target);
        }        
    }
}

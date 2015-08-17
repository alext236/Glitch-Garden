using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {

    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject atk = collision.gameObject;
        //jumped over by the Fox
        if (atk.GetComponent<Fox>()) {
            anim.SetBool("isAttacked", false);
        }
    }
}

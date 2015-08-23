using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

    private Attacker attacker;
    

    // Use this for initialization
    void Start() {
        attacker = GetComponent<Attacker>();        
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject target = collision.gameObject;

        if (!target.GetComponent<Defender>()) {
            return;
        }        
        attacker.Attack(target);

    }
}

using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.GetComponent<Projectile>()) {
            return;
        }
        Destroy(collision.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health;

    public void TakeDamage(float damage) {
        if (health >= damage) {
            health -= damage;
        }
        else {
            health = 0;
        }

        if (health <= 0) {
            //Optionally trigger death animation or particles
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}

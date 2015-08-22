using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [Range (-1f, 3f)]
    public float speed;
    public float damage;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.GetComponent<Attacker>()) {
            return;
        }
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        attacker.BeingStriked(damage);
        Debug.Log(name + " hit an attacker with " + damage + " damage");
    }
}

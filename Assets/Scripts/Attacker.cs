using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(-1f, 2f)]
    public float walkSpeed;

    private float currentSpeed;

    private Animator animator;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();

        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update() {
        //Movement is controlled with animation events (by setting speed = 0 when not moving)
        transform.Translate(Vector3.left * Time.deltaTime * currentSpeed, Space.Self);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " trigger enter");
    }

    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }
    
    public void ResetOriginalSpeed() {
        currentSpeed = walkSpeed;
    }

    public void StrikeCurrentTarget(float damage) {
        Debug.Log("This attacker is attacking with " + damage + " damage");
    }
}

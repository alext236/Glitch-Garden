using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Range(-1f, 2f)]
    public float walkSpeed;

    private float currentSpeed;
    private GameObject currentTarget;

    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //Movement is controlled with animation events (by setting speed = 0 when not moving)
        transform.Translate(Vector3.left * Time.deltaTime * currentSpeed, Space.Self);
    }

    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }
    
    public void ResetOriginalSpeed() {
        currentSpeed = walkSpeed;
    }

    //Called from the animator at time of actual blow, using animator events
    public void StrikeCurrentTarget(float damage) {
        Debug.Log("This attacker is attacking with " + damage + " damage");        
    }

    public void Attack(GameObject target) {
        currentTarget = target;
        anim.SetBool("isAttacking", true);        
    }
}

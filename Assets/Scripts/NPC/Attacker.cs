using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Health))]
public class Attacker : MonoBehaviour {

    [Range(-1f, 2f)]
    public float walkSpeed;

    private float currentSpeed;
    private GameObject currentTarget;

    private Animator anim;
    private Health healthComp;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        healthComp = GetComponent<Health>();
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
        Debug.Log("Before: " + currentTarget.GetComponent<Health>().health);
        currentTarget.GetComponent<Health>().TakeDamage(damage);
        Debug.Log("After: " + currentTarget.GetComponent<Health>().health);
        
    }

    public void Attack(GameObject target) {
        currentTarget = target;
        anim.SetBool("isAttacking", true);        
    }

    public void StopAttack() {
        anim.SetBool("isAttacking", false);
    }
}

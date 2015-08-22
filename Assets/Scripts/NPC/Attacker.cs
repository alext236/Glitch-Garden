using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
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

        //If there is no current target, stop attacking and resume moving
        if (!currentTarget && anim.GetBool("isAttacking")) {
            StopAttack();
        }
    }

    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }

    public void ResetOriginalSpeed() {
        currentSpeed = walkSpeed;
    }

    //Called from the animator at time of actual blow, using animator events
    //Currently can only set damage at animator events
    public void StrikeCurrentTarget(float damage) {
        //Current target should exist to be striked
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.TakeDamage(damage);
            }
        }
    }

    public void Attack(GameObject target) {
        currentTarget = target;
        anim.SetBool("isAttacking", true);
    }

    public void StopAttack() {
        anim.SetBool("isAttacking", false);
    }

    public void BeingStriked(float damage) {
        healthComp.TakeDamage(damage);
    }
}

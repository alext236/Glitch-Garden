using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(-1f, 2f)]
    public float walkSpeed;

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Move left when animation state is "Walk"
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed, Space.Self);
        }
        
	}
}

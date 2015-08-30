using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;

    private GameObject projectileParent;
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find("Projectile Parent");
        if (projectileParent == null) {
            projectileParent = new GameObject("Projectile Parent");
        }
    }

    // Update is called once per frame
    void Update() {
        if (!IsThereAttackerOnSameLane()) {
            AttackMode(false);
        }
        else {
            AttackMode(true);
        }
    }

    //For now, Edit how frequent the attacker fires in the animator transition exit time
    //Find a way to make fire rate adjustable using script instead of animator
    void Fire() {
        Vector3 gunPosition = transform.FindChild("Gun").transform.position;
        GameObject newProjectile = Instantiate(projectile, gunPosition, Quaternion.identity) as GameObject;
        newProjectile.transform.SetParent(projectileParent.transform);
    }

    bool IsThereAttackerOnSameLane() {
        //Check if there is attackers on same lane and are ahead the defenders
        //Change so that it only return true when attacker is visible, spawn the attackers one unit off screen width?
        foreach (Spawner spawner in FindObjectsOfType<Spawner>()) {
            bool isOnSameLane = false;
            bool isAhead = false;
            if (spawner.transform.position.y == transform.position.y) {
                //there is an attacker if spawner on same lane has a child
                isOnSameLane = (spawner.transform.childCount > 0);
            }
            //check if attacker is ahead of defender
            foreach (Transform child in spawner.transform) {
                isAhead = (transform.position.x <= child.transform.position.x);
            }

            if (!isOnSameLane) {
                Debug.LogWarning("No spawner found in a lane");
            }            

            if (isOnSameLane && isAhead) {
                return true;
            }
        }

        return false;
    }

    public void AttackMode(bool turnOn) {
        if (turnOn) {
            anim.SetBool("isAttacking", true);
        }
        else {
            anim.SetBool("isAttacking", false);
        }
    }
}

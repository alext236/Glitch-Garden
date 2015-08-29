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
        } else {
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
        foreach (Attacker attacker in FindObjectsOfType<Attacker>()) {
            bool isOnSameLane = (transform.position.y == attacker.transform.position.y);
            bool isAhead = (transform.position.x <= attacker.transform.position.x);

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

using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;    

    private GameObject projectileParent;

	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectile Parent");
        if (projectileParent == null) {
            projectileParent = new GameObject("Projectile Parent");
        }   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //For now, Edit how frequent the attacker fires in the animator transition exit time
    //Find a way to make fire rate adjustable using script instead of animator
    void Fire() {        
        Vector3 gunPosition = transform.FindChild("Gun").transform.position;
        GameObject newProjectile = Instantiate(projectile, gunPosition, Quaternion.identity) as GameObject;
        newProjectile.transform.SetParent(projectileParent.transform);
    }
}

using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;    

    private GameObject projectileParent;

	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectile Parent");        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //For now, Edit how frequent the attacker fires in the animator transition exit time
    void Fire() {
        GameObject proj = Instantiate(projectile, transform.GetChild(1).transform.position, Quaternion.identity) as GameObject;
        proj.transform.SetParent(projectileParent.transform);
    }
}

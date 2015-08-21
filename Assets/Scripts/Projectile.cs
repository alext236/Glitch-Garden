using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [Range (-1f, 3f)]
    public float speed;
    public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
	}
}

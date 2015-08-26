using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerList;
    //Think about whether to use array or specific GameObject

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnAttacker(attackerList[0], 4));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnAttacker(GameObject attacker, int amount) {
        if (!attacker) {
            Debug.LogError("Attacker not defined!");
        }
        //think if there's a way to calculate the x spawn position based on width of play space
        for (int i = 0; i < amount; i++) {
            Vector3 spawnPos = new Vector3(9f, Random.Range(1, 6));
            GameObject newAtk = Instantiate(attacker, spawnPos, Quaternion.identity) as GameObject;
            newAtk.transform.SetParent(transform);

            yield return new WaitForSeconds(3);
        }

        

    }
}

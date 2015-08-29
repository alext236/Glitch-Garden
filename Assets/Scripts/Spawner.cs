using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject attacker in attackerPrefabArray) {
            if (IsTimeToSpawn(attacker)) {
                Spawn(attacker);
                Debug.Log(attacker.name + " spawned");
            }
        }
	
	}

    bool IsTimeToSpawn(GameObject attacker) {
        Attacker atk = attacker.GetComponent<Attacker>();
        float meanSpawnDelay = atk.appearEverySecond;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        if (Random.value < threshold) {
            return true;
        }

        return false;

    }

    void Spawn(GameObject attacker) {
        GameObject newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as GameObject;
        newAttacker.transform.SetParent(transform);        
    }
}
